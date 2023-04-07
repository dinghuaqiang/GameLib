using GameLib.Core.Asset;
using GameLib.Core.Base;
using GameLib.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace GameLib.Core.Support
{
    /// <summary>
    /// This class is used to display a more complex user entry interface in the 
    /// Unity Editor so we can collect more options related to each Prefab.
    /// 
    /// See this class documentation for Editor Options.
    /// 
    /// This class is also the primary pool functionality for SpawnPool. SpawnPool
    /// manages the Pool using these settings and methods. See the SpawnPool 
    /// documentation for user documentation and usage.
    /// </summary>
    [System.Serializable]
    public class PrefabPool : IAutoCleanInfo
    {

        #region Public Properties Available in the Editor
        /// <summary>
        /// 关联的文件路径
        /// </summary>
        public string PrefabAssetPath;

        /// <summary>
        /// The prefab to preload
        /// </summary>
        public Transform Prefab;

        /// <summary>
        /// A reference of the prefab's GameObject stored for performance reasons
        /// </summary>
        internal GameObject _prefabGO;  // Hidden in inspector, but not Debug tab

        internal string _prefabName = string.Empty;

        public string PrefabName
        {
            get
            {
                return _prefabName;
            }
        }

        /// <summary>
        /// The number of instances to preload
        /// </summary>
        public int PreloadAmount = 1;

        /// <summary>
        /// Displays the 'preload over time' options
        /// </summary>
        public bool PreloadTime = false;

        /// <summary>
        /// The number of frames it will take to preload all requested instances
        /// </summary>
        public int PreloadFrames = 2;

        /// <summary>
        /// The number of seconds to wait before preloading any instances
        /// </summary>
        public float PreloadDelay = 0;

        /// <summary>
        /// Limits the number of instances allowed in the game. Turning this ON
        ///	means when 'Limit Amount' is hit, no more instances will be created.
        /// CALLS TO SpawnPool.Spawn() WILL BE IGNORED, and return null!
        ///
        /// This can be good for non-critical objects like bullets or explosion
        ///	Flares. You would never want to use this for enemies unless it makes
        ///	sense to begin ignoring enemy spawns in the context of your game.
        /// </summary>
        public bool LimitInstances = false;

        /// <summary>
        /// This is the max number of instances allowed if 'limitInstances' is ON.
        /// </summary>
        public int LimitAmount = 100;

        /// <summary>
        /// FIFO stands for "first-in-first-out". Normally, limiting instances will
        /// stop spawning and return null. If this is turned on (set to true) the
        /// first spawned instance will be despawned and reused instead, keeping the
        /// total spawned instances limited but still spawning new instances.
        /// </summary>
        public bool LimitFIFO = false;  // Keep after limitAmount for auto-inspector

        /// <summary>
        /// Turn this ON to activate the culling feature for this Pool. 
        /// Use this feature to remove despawned (inactive) instances from the pool
        /// if the size of the pool grows too large. 
        ///	
        /// DO NOT USE THIS UNLESS YOU NEED TO MANAGE MEMORY ISSUES!
        /// This should only be used in extreme cases for memory management. 
        /// For most pools (or games for that matter), it is better to leave this 
        /// off as memory is more plentiful than performance. If you do need this
        /// you can fine tune how often this is triggered to target extreme events.
        /// 
        /// A good example of when to use this would be if you you are Pooling 
        /// projectiles and usually never need more than 10 at a time, but then
        /// there is a big one-off fire-fight where 50 projectiles are needed. 
        /// Rather than keep the extra 40 around in memory from then on, set the 
        /// 'Cull Above' property to 15 (well above the expected max) and the Pool 
        /// will Destroy() the extra instances from the game to free up the memory. 
        /// 
        /// This won't be done immediately, because you wouldn't want this culling 
        /// feature to be fighting the Pool and causing extra Instantiate() and 
        /// Destroy() calls while the fire-fight is still going on. See 
        /// "Cull Delay" for more information about how to fine tune this.
        /// </summary>
        public bool cullDespawned = false;

        /// <summary>
        /// The number of TOTAL (spawned + despawned) instances to keep. 
        /// </summary>
        public int CullAbove = 50;

        /// <summary>
        /// The amount of time, in seconds, to wait before culling. This is timed 
        /// from the moment when the Queue's TOTAL count (spawned + despawned) 
        /// becomes greater than 'Cull Above'. Once triggered, the timer is repeated 
        /// until the count falls below 'Cull Above'.
        /// </summary>
        public int CullDelay = 60;

        /// <summary>
        /// The maximum number of instances to destroy per this.cullDelay
        /// </summary>
        public int CullMaxPerPass = 5;

        /// <summary>
        /// Prints information during run-time to make debugging easier. This will 
        /// be set to true if the owner SpawnPool is true, otherwise the user's setting
        /// here will be used
        /// </summary>
        public bool _logMessages = false;  // Used by the inspector
        public bool LogMessages            // Read-only
        {
            get
            {
                if (_forceLoggingSilent)
                    return false;

                if (this.SpawnPool.LogMessages)
                    return this.SpawnPool.LogMessages;
                else
                    return this._logMessages;
            }
        }

        // Forces logging to be silent regardless of user settings.
        private bool _forceLoggingSilent = false;


        /// <summary>
        /// Used internally to reference back to the owner spawnPool for things like
        /// anchoring co-routines.
        /// </summary>
        public SpawnPool SpawnPool;
        #endregion Public Properties Available in the Editor


        #region Constructor and Self-Destruction
        /// <description>
        ///	Constructor to require a prefab Transform
        /// </description>
        public PrefabPool(Transform prefab)
        {
            this.Prefab = prefab;
            this._prefabGO = prefab.gameObject;
        }
        /// <description>
        ///	Constructor to require a prefab Transform
        /// </description>
        public PrefabPool(PrefabPoolSettings settings)
        {
            this.Prefab = settings.Prefab;
            this._prefabGO = settings.Prefab.gameObject;
            this._spawned = new List<Transform>();
            this._despawned = new List<Transform>();
            this._spawnedSet = new HashSet<Transform>();
            this._despawnedSet = new HashSet<Transform>();
            ApplySettings(settings);
        }
        /// <description>
        ///	Apply settings to this pool
        /// </description>
        public void ApplySettings(PrefabPoolSettings settings)
        {
            PreloadAmount = settings.PreloadAmount;
            PreloadTime = settings.PreloadTime;
            PreloadFrames = settings.PreloadFrames;
            PreloadDelay = settings.PreloadDelay;
            LimitInstances = settings.LimitInstances;
            LimitAmount = settings.LimitAmount;
            LimitFIFO = settings.LimitFIFO;
            cullDespawned = settings.CullDespawned;
            CullAbove = settings.CullAbove;
            CullDelay = settings.CullDelay;
            CullMaxPerPass = settings.CullMaxPerPass;
            _logMessages = settings.LogMessages;
            OnPreDestroy = settings.OnPreDestroy;
            OnPostDestroy = settings.OnPostDestroy;
            OnNotifyCulled = settings.OnNotifyCulled;
        }
        /// <description>
        ///	Constructor for Serializable inspector use only
        /// </description>
        public PrefabPool() { }

        /// <description>
        ///	A pseudo constructor to init stuff not init by the serialized inspector-created
        ///	instance of this class.
        /// </description>
        internal void inspectorInstanceConstructor()
        {
            this._prefabGO = this.Prefab.gameObject;
            this._spawned = new List<Transform>();
            this._despawned = new List<Transform>();
            this._spawnedSet = new HashSet<Transform>();
            this._despawnedSet = new HashSet<Transform>();
        }

        public bool CullingActived
        {
            get
            {
                return _cullingActive;
            }
        }

        internal void markActiveTrimInCulling()
        {
            if (_cullingActive == true)
            {
                _activeTrimInCulling = true;
            }
        }

        /// <summary>
        /// Run by a SpawnPool when it is destroyed
        /// </summary>
        internal void SelfDestruct()
        {
            //把名字给还原回去
            if (this.Prefab != null)
                this.Prefab.name = System.IO.Path.GetFileNameWithoutExtension(this.Prefab.name);

            if (this.OnPreDestroy != null)
            {
                this.OnPreDestroy(this);
            }
            // Probably overkill but no harm done
            if (this._prefabGO != null)
            {
                //GameObject.Destroy( prefabGO );
                _prefabGO = null;
            }

            this.Prefab = null;
            this.SpawnPool = null;


            // Go through both lists and destroy everything
            for (int i = 0, count = this._despawned.Count; i < count; ++i)
            {
                var inst = this._despawned[i];
                if (inst != null)
                {
                    Object.Destroy(inst.gameObject);
                }
            }

            for (int i = 0, count = this._spawned.Count; i < count; ++i)
            {
                var inst = this._spawned[i];
                if (inst != null)
                {
                    Object.Destroy(inst.gameObject);
                }
            }

            this._spawned.Clear();
            this._despawned.Clear();
            this._spawnedSet.Clear();
            this._despawnedSet.Clear();

            if (this.OnPostDestroy != null)
            {
                this.OnPostDestroy(this);
            }
        }
        #endregion Constructor and Self-Destruction



        #region Pool Functionality
        /// <summary>
        /// Is set to true when the culling coroutine is started so another one
        /// won't be
        /// </summary>
        bool _cullingActive = false;
        bool _activeTrimInCulling = false;
        public GAction<PrefabPool> OnPreDestroy = null;
        public GAction<PrefabPool> OnPostDestroy = null;
        public GAction<PrefabPool> OnNotifyCulled = null;

        /// <summary>
        /// The active instances associated with this prefab. This is the pool of
        /// instances created by this prefab.
        /// 
        /// Managed by a SpawnPool
        /// </summary>
        internal List<Transform> _spawned = new List<Transform>();
        internal HashSet<Transform> _spawnedSet = new HashSet<Transform>();
        public List<Transform> Spawned { get { return new List<Transform>(this._spawned); } }

        /// <summary>
        /// The deactive instances associated with this prefab. This is the pool of
        /// instances created by this prefab.
        /// 
        /// Managed by a SpawnPool
        /// </summary>
        internal List<Transform> _despawned = new List<Transform>();
        internal HashSet<Transform> _despawnedSet = new HashSet<Transform>();
        public List<Transform> Despawned { get { return new List<Transform>(this._despawned); } }


        /// <summary>
        /// Returns the total count of instances in the PrefabPool
        /// </summary>
        public int TotalCount
        {
            get
            {
                // Add all the items in the pool to get the total count
                int count = 0;
                count += this._spawned.Count;
                count += this._despawned.Count;
                return count;
            }
        }


        /// <summary>
        /// Used to make PreloadInstances() a one-time event. Read-only.
        /// </summary>
        private bool _preloaded = false;
        internal bool Preloaded
        {
            get { return this._preloaded; }
            private set { this._preloaded = value; }
        }


        /// <summary>
        /// Move an instance from despawned to spawned, set the position and 
        /// rotation, activate it and all children and return the transform
        /// </summary>
        /// <returns>
        /// True if successfull, false if xform isn't in the spawned list
        /// </returns>
        internal bool DespawnInstance(Transform xform)
        {
            return DespawnInstance(xform, true);
        }

        internal bool DespawnInstance(Transform xform, bool sendEventMessage)
        {
            if (this.LogMessages)
                Debug.Log(string.Format("SpawnPool {0} ({1}): Despawning '{2}'",
                                       this.SpawnPool.PoolName,
                                       this.Prefab.name,
                                       xform.name));

            // Switch to the despawned list
            this._spawned.Remove(xform);
            this._spawnedSet.Remove(xform);
            this._despawned.Add(xform);
            this._despawnedSet.Add(xform);
            // Notify instance of event OnDespawned for custom code additions.
            //   This is done before handling the deactivate and enqueue incase 
            //   there the user introduces an unforseen issue.
            //这里可以不要，没地方用
            //if (sendEventMessage)
            //    xform.gameObject.BroadcastMessage("OnDespawned", SendMessageOptions.DontRequireReceiver);

            
            // Deactivate the instance and all children
            PoolManagerUtils.SetActive(xform.gameObject, false);
            _usedTimeInfo.EndUsed();
            FLogger.DebugLogWarning("DespawnInstance:", _prefabName, _usedTimeInfo.RefCount);
            
            // Trigger culling if the feature is ON and the size  of the 
            //   overall pool is over the Cull Above threashold.
            //   This is triggered here because Despawn has to occur before
            //   it is worth culling anyway, and it is run fairly often.
            if (!this._cullingActive &&   // Cheap & Singleton. Only trigger once!
                this.cullDespawned &&    // Is the feature even on? Cheap too.
                this.TotalCount > this.CullAbove)   // Criteria met?
            {                
                this._cullingActive = true;             
                if (this.SpawnPool.gameObject.activeInHierarchy)
                {
                    this.SpawnPool.StartCoroutine(CullDespawned(0));
                }
            }
            return true;
        }

        public void Sweep()
        {
            // Trigger culling if the feature is ON and the size  of the 
            //   overall pool is over the Cull Above threashold.
            //   This is triggered here because Despawn has to occur before
            //   it is worth culling anyway, and it is run fairly often.
            if (!this._cullingActive &&   // Cheap & Singleton. Only trigger once!
                this.cullDespawned &&    // Is the feature even on? Cheap too.
                this.TotalCount > this.CullAbove)   // Criteria met?
            {                                
                this._cullingActive = true;
                this.SpawnPool.StartCoroutine(CullDespawned(1));
            }
        }

        /// <summary>
        /// Waits for 'cullDelay' in seconds and culls the 'despawned' list if 
        /// above 'cullingAbove' amount. 
        /// 
        /// Triggered by DespawnInstance()
        /// </summary>
        internal IEnumerator CullDespawned(int tag)
        {
            bool _logMessages = this.LogMessages;
            string poolName = string.Empty;
            string prefabName = this.PrefabName;
            int _tag = tag;
            if (this.Prefab != null)
            {
                FLogger.DebugAssert(prefabName == this.Prefab.name, "CullDespawned",prefabName,this.Prefab.name);
            }
            var _spawnPool = this.SpawnPool;
            if (_logMessages)
            {
                poolName = this.SpawnPool.PoolName;
                Debug.Log(string.Format("SpawnPool {0} ({1}): CULLING TRIGGERED! " +
                                          "Waiting {2}sec to begin checking for despawns...",
                                        poolName,
                                        prefabName,
                                        this.CullDelay));
            }
            if (this.Prefab == null)
            {
                this._cullingActive = false;
                yield break;
            }

            yield return new WaitForEndOfFrame();
            
            // First time always pause, then check to see if the condition is
            //   still true before attempting to cull.
            yield return new WaitForSeconds(this.CullDelay);
            
            while (this.TotalCount > this.CullAbove)
            {
                // Attempt to delete an amount == this.cullMaxPerPass
                for (int i = 0; i < this.CullMaxPerPass; i++)
                {
                    if (this.Prefab == null)
                    {
                        // this pool has been destroied
                        goto BREAK_LOOP;
                    }
                    // Break if this.cullMaxPerPass would go past this.cullAbove
                    if (this.TotalCount <= this.CullAbove)
                        break;  // The while loop will stop as well independently

                    // Destroy the last item in the list
                    if (this._despawned.Count > 0)
                    {
                        Transform inst = this._despawned[0];
                        this._despawned.RemoveAt(0);
                        this._despawnedSet.Remove(inst);
                        MonoBehaviour.Destroy(inst.gameObject);
                        if (this.LogMessages)
                        {
                            Debug.Log(string.Format("SpawnPool {0} ({1}): " +
                                                    "CULLING to {2} instances. Now at {3}.",
                                                this.SpawnPool.PoolName,
                                                prefabName,
                                                this.CullAbove,
                                                this.TotalCount));
                        }
                        if (OnNotifyCulled != null)
                        {
                            OnNotifyCulled(this);
                        }
                    }
                    else if (_logMessages)
                    {
                        Debug.Log(string.Format("SpawnPool {0} ({1}): " +
                                                    "CULLING waiting for despawn. " +
                                                    "Checking again in {2}sec",
                                                poolName,
                                                prefabName,
                                                this.CullDelay));

                        break;
                    }
                }
                if (this._despawned.Count == 0)
                {
                    break;
                }
                // Check again later
                yield return new WaitForSeconds(this.CullDelay);
            }
        BREAK_LOOP:
            if (_logMessages)
            {
                Debug.Log(string.Format("SpawnPool {0} ({1}): CULLING FINISHED! Stopping",
                                        poolName,
                                        prefabName));
            }
            try
            {
                if (this._activeTrimInCulling)
                {
                    this._activeTrimInCulling = false;
                    if (this.Spawned.Count == 0 && this.Prefab != null)
                    {
                        Transform x = null;
                        _spawnPool.Prefabs.TryGetValue(prefabName, out x);
                        if (x != this.Prefab)
                        {
                            FLogger.DebugAssert(false);
                        }
                        bool a = _spawnPool.Prefabs._Remove(prefabName);
                        bool b = _spawnPool._prefabPools.Remove(this);
                        this.SelfDestruct();
                        if (a != b)
                        {
                            FLogger.DebugAssert(false);
                            Debug.ClearDeveloperConsole();
                            FLogger.DebugLogErrorFormat("CullDespawned.error for remove {0}, {1}-{2}", prefabName, a, b);
                            FLogger.DebugLog("Dump prefabPools");
                            var spool = _spawnPool.LockPrefabPoolsRef();
                            try
                            {
                                for (int i = 0; i < spool.Count; ++i)
                                {
                                    var pool = spool[i];
                                    FLogger.DebugLogFormat("name = {0}, prefab = {1}", pool._prefabName, pool.Prefab);
                                }
                            }
                            finally
                            {
                                _spawnPool.UnlockPrefabPoolsRef();
                            }
                            FLogger.DebugLog("Dump prefabsDict");
                            foreach (var item in _spawnPool.Prefabs)
                            {
                                FLogger.DebugLogFormat("\tname = {0}, prefab = {1}", item.Key, item.Value != null ? item.Value.name : "null");
                            }
                        }
                        if (_logMessages)
                        {
                            Debug.Log(string.Format("SpawnPool {0} ({1}): has been trimed!",
                                                    poolName,
                                                    prefabName));
                        }
                    }
                }
            }
            finally
            {
                // Reset the singleton so the feature can be used again if needed.
                this._cullingActive = false;
            }
        }



        /// <summary>
        /// Move an instance from despawned to spawned, set the position and 
        /// rotation, activate it and all children and return the transform.
        /// 
        /// If there isn't an instance available, a new one is made.
        /// </summary>
        /// <returns>
        /// The new instance's Transform. 
        /// 
        /// If the Limit option was used for the PrefabPool associated with the
        /// passed prefab, then this method will return null if the limit is
        /// reached.
        /// </returns>    
        internal Transform SpawnInstance(Vector3 pos, Quaternion rot,bool spawnActive)
        {
            // Handle FIFO limiting if the limit was used and reached.
            //   If first-in-first-out, despawn item zero and continue on to respawn it
            if (this.LimitInstances && this.LimitFIFO &&
                this._spawned.Count >= this.LimitAmount)
            {
                Transform firstIn = this._spawned[0];

                if (this.LogMessages)
                {
                    Debug.Log(string.Format
                    (
                        "SpawnPool {0} ({1}): " +
                            "LIMIT REACHED! FIFO=True. Calling despawning for {2}...",
                        this.SpawnPool.PoolName,
                        this.Prefab.name,
                        firstIn
                    ));
                }

                this.DespawnInstance(firstIn);

                // Because this is an internal despawn, we need to re-sync the SpawnPool's
                //  internal list to reflect this
                this.SpawnPool._spawnedPoolDict.Remove(firstIn);
            }

            Transform inst;

            // If nothing is available, create a new instance
            if (this._despawned.Count == 0)
            {
                // This will also handle limiting the number of NEW instances
                inst = this.SpawnNew(pos, rot);
            }
            else
            {
                // Switch the instance we are using to the spawned list
                // Use the first item in the list for ease
                inst = this._despawned[0];
                this._despawned.RemoveAt(0);
                this._despawnedSet.Remove(inst);
                if (inst == null)
                {
                    var msg = "Make sure you didn't delete a despawned instance directly.return null;" + this.Prefab.name;
                    Debug.LogError(msg);
                    return null;
                }
                this._spawned.Add(inst);
                this._spawnedSet.Add(inst);

                // This came up for a user so this was added to throw a user-friendly error
                //if (inst == null)
                //{
                //    var msg = "Make sure you didn't delete a despawned instance directly."+ this.Prefab.name;
                //    throw new MissingReferenceException(msg);
                //}

                if (this.LogMessages)
                    Debug.Log(string.Format("SpawnPool {0} ({1}): respawning '{2}'.",
                                            this.SpawnPool.PoolName,
                                            this.Prefab.name,
                                            inst.name));

                // Get an instance and set position, rotation and then 
                //   Reactivate the instance and all children
                inst.position = pos;
                inst.rotation = rot;
                
                PoolManagerUtils.SetActive(inst.gameObject, spawnActive);
                _usedTimeInfo.BeginUsed();
                FLogger.DebugLogWarning("SpawnInstance:", _prefabName, this._spawned.Count, _usedTimeInfo.RefCount);
            }

            // Only == null if the limit option is used and the limit reached
            if (inst != null)
            {
                
               
                // Notify instance it was spawned so it can manage it's state
                inst.gameObject.BroadcastMessage("OnSpawned",
                                             SendMessageOptions.DontRequireReceiver);
            }
            return inst;
        }



        /// <summary>
        /// Spawns a NEW instance of this prefab and adds it to the spawned list.
        /// The new instance is placed at the passed position and rotation
        /// </summary>
        /// <param name="pos">Vector3</param>
        /// <param name="rot">Quaternion</param>
        /// <returns>
        /// The new instance's Transform. 
        /// 
        /// If the Limit option was used for the PrefabPool associated with the
        /// passed prefab, then this method will return null if the limit is
        /// reached.
        /// </returns>
        public Transform SpawnNew() { return this.SpawnNew(Vector3.zero, Quaternion.identity); }
        public Transform SpawnNew(Vector3 pos, Quaternion rot)
        {
            // Handle limiting if the limit was used and reached.
            if (this.LimitInstances && this.TotalCount >= this.LimitAmount)
            {
                if (this.LogMessages)
                {
                    Debug.Log(string.Format
                    (
                        "SpawnPool {0} ({1}): " +
                                "LIMIT REACHED! Not creating new instances! (Returning null)",
                            this.SpawnPool.PoolName,
                            this.Prefab.name
                    ));
                }

                return null;
            }

            // Use the SpawnPool group as the default position and rotation
            if (pos == Vector3.zero)
                pos = this.SpawnPool.Group.position;
            if (rot == Quaternion.identity)
                rot = this.SpawnPool.Group.rotation;

            
            var inst = (Transform)Object.Instantiate(this.Prefab, pos, rot);            
            this.nameInstance(inst);  // Adds the number to the end
            inst.parent = this.SpawnPool.Group;  // The group is the parent by default

            if (this.SpawnPool.MatchPoolScale)
                inst.localScale = Vector3.one;

            if (this.SpawnPool.MatchPoolLayer)
                this.SetRecursively(inst, this.SpawnPool.gameObject.layer);

            // Start tracking the new instance
            this._spawned.Add(inst);
            this._spawnedSet.Add(inst);
            if (this.LogMessages)
                Debug.Log(string.Format("SpawnPool {0} ({1}): Spawned new instance '{2}'.",
                                        this.SpawnPool.PoolName,
                                        this.Prefab.name,
                                        inst.name));

            _usedTimeInfo.BeginUsed();
            FLogger.DebugLogWarning("SpawnNew:", _prefabName, this._spawned.Count, _usedTimeInfo.RefCount);

            return inst;
        }


        /// <summary>
        /// Sets the layer of the passed transform and all of its children
        /// </summary>
        /// <param name="xform">The transform to process</param>
        /// <param name="layer">The new layer</param>
        private void SetRecursively(Transform xform, int layer)
        {
            xform.gameObject.layer = layer;
            foreach (Transform child in xform)
                SetRecursively(child, layer);
        }


        /// <summary>
        /// Used by a SpawnPool to add an existing instance to this PrefabPool.
        /// This is used during game start to pool objects which are not 
        /// instantiated at runtime
        /// </summary>
        /// <param name="inst">The instance to add</param>
        /// <param name="despawn">True to despawn on add</param>
        internal void AddUnpooled(Transform inst, bool despawn)
        {
            this.nameInstance(inst);   // Adds the number to the end

            if (despawn)
            {
                // Deactivate the instance and all children
                PoolManagerUtils.SetActive(inst.gameObject, false);

                // Start Tracking as despawned
                this._despawned.Add(inst);
                this._despawnedSet.Add(inst);
            }
            else
            {
                this._spawned.Add(inst);
                this._spawnedSet.Add(inst);
            }
        }


        /// <summary>
        /// Preload PrefabPool.preloadAmount instances if they don't already exist. In 
        /// otherwords, if there are 7 and 10 should be preloaded, this only creates 3.
        /// This is to allow asynchronous Spawn() usage in Awake() at game start
        /// </summary>
        /// <returns></returns>
        internal void PreloadInstances()
        {
            // If this has already been run for this PrefabPool, there is something
            //   wrong!
            if (this.Preloaded)
            {
                Debug.Log(string.Format("SpawnPool {0} ({1}): " +
                                          "Already preloaded! You cannot preload twice. " +
                                          "If you are running this through code, make sure " +
                                          "it isn't also defined in the Inspector.",
                                        this.SpawnPool.PoolName,
                                        this.Prefab.name));

                return;
            }

            if (this.Prefab == null)
            {
                Debug.LogError(string.Format("SpawnPool {0} ({1}): Prefab cannot be null.",
                                             this.SpawnPool.PoolName,
                                             this.Prefab.name));

                return;
            }

            // Protect against preloading more than the limit amount setting
            //   This prevents an infinite loop on load if FIFO is used.
            if (this.LimitInstances && this.PreloadAmount > this.LimitAmount)
            {
                Debug.LogWarning
                (
                    string.Format
                    (
                        "SpawnPool {0} ({1}): " +
                            "You turned ON 'Limit Instances' and entered a " +
                            "'Limit Amount' greater than the 'Preload Amount'! " +
                            "Setting preload amount to limit amount.",
                         this.SpawnPool.PoolName,
                         this.Prefab.name
                    )
                );

                this.PreloadAmount = this.LimitAmount;
            }

            // Notify the user if they made a mistake using Culling
            //   (First check is cheap)
            if (this.cullDespawned && this.PreloadAmount > this.CullAbove)
            {
                Debug.LogWarning(string.Format("SpawnPool {0} ({1}): " +
                    "You turned ON Culling and entered a 'Cull Above' threshold " +
                    "greater than the 'Preload Amount'! This will cause the " +
                    "culling feature to trigger immediatly, which is wrong " +
                    "conceptually. Only use culling for extreme situations. " +
                    "See the docs.",
                    this.SpawnPool.PoolName,
                    this.Prefab.name
                ));
            }

            if (this.PreloadTime)
            {
                if (this.PreloadFrames > this.PreloadAmount)
                {
                    Debug.LogWarning(string.Format("SpawnPool {0} ({1}): " +
                        "Preloading over-time is on but the frame duration is greater " +
                        "than the number of instances to preload. The minimum spawned " +
                        "per frame is 1, so the maximum time is the same as the number " +
                        "of instances. Changing the preloadFrames value...",
                        this.SpawnPool.PoolName,
                        this.Prefab.name
                    ));

                    this.PreloadFrames = this.PreloadAmount;
                }

                this.SpawnPool.StartCoroutine(this.PreloadOverTime());
            }
            else
            {
                // Reduce debug spam: Turn off this.logMessages then set it back when done.
                this._forceLoggingSilent = true;

                Transform inst;
                while (this.TotalCount < this.PreloadAmount) // Total count will update
                {
                    // Preload...
                    // This will parent, position and orient the instance
                    //   under the SpawnPool.group
                    inst = this.SpawnNew();
                    this.DespawnInstance(inst, false);
                }

                // Restore the previous setting
                this._forceLoggingSilent = false;
            }
        }

        private IEnumerator PreloadOverTime()
        {
            yield return new WaitForSeconds(this.PreloadDelay);

            Transform inst;

            // subtract anything spawned by other scripts, just in case
            int amount = this.PreloadAmount - this.TotalCount;
            if (amount <= 0)
                yield break;

            // This does the division and sets the remainder as an out value.
            int remainder;
            int numPerFrame = System.Math.DivRem(amount, this.PreloadFrames, out remainder);

            // Reduce debug spam: Turn off this.logMessages then set it back when done.
            this._forceLoggingSilent = true;

            int numThisFrame;
            for (int i = 0; i < this.PreloadFrames; i++)
            {
                // Add the remainder to the *last* frame
                numThisFrame = numPerFrame;
                if (i == this.PreloadFrames - 1)
                {
                    numThisFrame += remainder;
                }

                for (int n = 0; n < numThisFrame; n++)
                {
                    // Preload...
                    // This will parent, position and orient the instance
                    //   under the SpawnPool.group
                    inst = this.SpawnNew();
                    if (inst != null)
                        this.DespawnInstance(inst, false);

                    yield return null;
                }

                // Safety check in case something else is making instances. 
                //   Quit early if done early
                if (this.TotalCount > this.PreloadAmount)
                    break;
            }

            // Restore the previous setting
            this._forceLoggingSilent = false;
        }

        #endregion Pool Functionality



        #region Utilities
        /// <summary>
        /// Appends a number to the end of the passed transform. The number
        /// will be one more than the total objects in this PrefabPool, so 
        /// name the object BEFORE adding it to the spawn or depsawn lists.
        /// </summary>
        /// <param name="instance"></param>
        private void nameInstance(Transform instance)
        {
            // Rename by appending a number to make debugging easier
            //   ToString() used to pad the number to 3 digits. Hopefully
            //   no one has 1,000+ objects.
            instance.name += (this.TotalCount + 1).ToString("#000");
        }


        #endregion Utilities


        #region //IAutoCleanInfo接口
        private ObjectUsedInfo _usedTimeInfo = new ObjectUsedInfo();
        public bool WillBeCleared
        {
            get {
                return (_spawned.Count == 0) && (_despawned.Count > 0) && !_cullingActive;
            }
        }

        public ObjectUsedInfo UsedTimeInfo
        {
            get { return _usedTimeInfo; }
        }
        
        #endregion
    }

}
