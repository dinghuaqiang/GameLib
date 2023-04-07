/// <Licensing>
/// ?2011 (Copyright) Path-o-logical Games, LLC
/// Licensed under the Unity Asset Package Product License (the "License");
/// You may not use this file except in compliance with the License.
/// You may obtain a copy of the License at: http://licensing.path-o-logical.com
/// </Licensing>
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameLib.Core.Utils;
using GameLib.Core.Base;
using GameLib.Core.Asset;

namespace GameLib.Core.Support
{
    /// <description>
    /// Online Docs: 
    ///     http://docs.poolmanager2.path-o-logical.com/code-reference/spawnpool
    ///     
    ///	A special List class that manages object pools and keeps the scene 
    ///	organized.
    ///	
    ///  * Only active/spawned instances are iterable. Inactive/despawned
    ///    instances in the pool are kept internally only.
    /// 
    ///	 * Instanciated objects can optionally be made a child of this GameObject
    ///	   (reffered to as a 'group') to keep the scene hierachy organized.
    ///		 
    ///	 * Instances will get a number appended to the end of their name. E.g. 
    ///	   an "Enemy" prefab will be called "Enemy(Clone)001", "Enemy(Clone)002", 
    ///	   "Enemy(Clone)003", etc. Unity names all clones the same which can be
    ///	   confusing to work with.
    ///		   
    ///	 * Objects aren't destroyed by the Despawn() method. Instead, they are
    ///	   deactivated and stored to an internal queue to be used again. This
    ///	   avoids the time it takes unity to destroy gameobjects and helps  
    ///	   performance by reusing GameObjects. 
    ///		   
    ///  * Two events are implimented to enable objects to handle their own reset needs. 
    ///    Both are optional.
    ///      1) When objects are Despawned BroadcastMessage("OnDespawned()") is sent.
    ///		 2) When reactivated, a BroadcastMessage("OnRespawned()") is sent. 
    ///		    This 
    /// </description>
    [AddComponentMenu("Path-o-logical/PoolManager/SpawnPool")]
    public sealed class SpawnPool : MonoBehaviour, IList<Transform>
    {
        #region Inspector Parameters
        /// <summary>
        /// Returns the name of this pool used by PoolManager. This will always be the
        /// same as the name in Unity, unless the name contains the work "Pool", which
        /// PoolManager will strip out. This is done so you can name a prefab or
        /// GameObject in a way that is development friendly. For example, "EnemiesPool" 
        /// is easier to understand than just "Enemies" when looking through a project.
        /// </summary>
        public string PoolName = "";

        /// <summary>
        /// Matches new instances to the SpawnPool GameObject's scale.
        /// </summary>
        public bool MatchPoolScale = false;

        /// <summary>
        /// Matches new instances to the SpawnPool GameObject's layer.
        /// </summary>
        public bool MatchPoolLayer = false;

        /// <summary>
        /// If true, this GameObject will be set to Unity's Object.DontDestroyOnLoad()
        /// </summary>
        public bool dontDestroyOnLoad = false;

        /// <summary>
        /// Print information to the Unity Console
        /// </summary>
        public bool LogMessages = false;

        /// <summary>
        /// A list of PreloadDef options objects used by the inspector for user input
        /// </summary>
        public List<PrefabPool> PerPrefabPoolOptions = new List<PrefabPool>();

        /// <summary>
        /// Used by the inspector to store this instances foldout states.
        /// </summary>
        public Dictionary<object, bool> PrefabsFoldOutStates = new Dictionary<object, bool>();
        #endregion Inspector Parameters



        #region Public Code-only Parameters
        /// <summary>
        /// The time in seconds to stop waiting for particles to die.
        /// A warning will be logged if this is triggered.
        /// </summary>
        [HideInInspector]
        public float MaxParticleDespawnTime = 60f;

        /// <summary>
        /// The group is an empty game object which will be the parent of all
        /// instances in the pool. This helps keep the scene easy to work with.
        /// </summary>
        private Transform _group;
        public Transform Group 
        { 
            get
            {
                if (_group == null)
                {
                    _group = this.transform;
                }

                return _group;
            }
            private set
            {
                _group = value;
            }
        }

        /// <summary>
        /// Returns the prefab of the given name (dictionary key)
        /// </summary>
        public PrefabsDict Prefabs = new PrefabsDict();

        // Keeps the state of each individual foldout item during the editor session
        public Dictionary<object, bool> EditorListItemStates = new Dictionary<object, bool>();

        /// <summary>
        /// Readonly access to prefab pools via a dictionary<string, PrefabPool>.
        /// </summary>
        public Dictionary<string, PrefabPool> PrefabPools
        {
            get
            {
                var dict = new Dictionary<string, PrefabPool>();
                for (int i = 0, count = this._prefabPools.Count; i < count; ++i)
                {
                    var pool = this._prefabPools[i];
                    dict[pool._prefabGO.name] = pool;
                }
                return dict;
            }
        }
        /// <summary>
        /// Readonly access to prefab pools via a dictionary<string, PrefabPool>.
        /// </summary>
        public List<PrefabPool> LockPrefabPoolsRef()
        {
            _prefabPools_locker = true;
            return this._prefabPools;
        }

        public void UnlockPrefabPoolsRef()
        {
            _prefabPools_locker = false;
        }
        #endregion Public Code-only Parameters



        #region Private Properties
        internal bool _prefabPools_locker = false;
        internal List<PrefabPool> _prefabPools = new List<PrefabPool>();
        internal bool _spawnedPoolDict_locker = false;
        internal Dictionary<Transform, PrefabPool> _spawnedPoolDict = new Dictionary<Transform, PrefabPool>();
        #endregion Private Properties



        #region Constructor and Init
        private void Awake()
        {
            // Make this GameObject immortal if the user requests it.
            if (this.dontDestroyOnLoad)
                Object.DontDestroyOnLoad(this.gameObject);

            this.Group = this.transform;

            // Default name behavior will use the GameObject's name without "Pool" (if found)
            if (this.PoolName == "")
            {
                // Automatically Remove "Pool" from names to allow users to name prefabs in a 
                //   more development-friendly way. E.g. "EnemiesPool" becomes just "Enemies".
                //   Notes: This will return the original string if "Pool" isn't found.
                //          Do this once here, rather than a getter, to avoide string work
                this.PoolName = this.Group.name.Replace("Pool", "");
                this.PoolName = this.PoolName.Replace("(Clone)", "");
            }


            if (this.LogMessages)
                Debug.Log(string.Format("SpawnPool {0}: Initializing..", this.PoolName));

            // Only used on items defined in the Inspector
            for (int i = 0, count = PerPrefabPoolOptions.Count; i < count; ++i)
            {
                var prefabPool = PerPrefabPoolOptions[i];
                if (prefabPool.Prefab == null)
                {
                    Debug.LogWarning(string.Format("Initialization Warning: Pool '{0}' " +
                              "contains a PrefabPool with no prefab reference. Skipping.",
                               this.PoolName));
                    continue;
                }

                // Init the PrefabPool's GameObject cache because it can't do it.
                //   This is only needed when created by the inspector because the constructor
                //   won't be run.
                prefabPool.inspectorInstanceConstructor();
                this.CreatePrefabPool(prefabPool);
            }

            // Add this SpawnPool to PoolManager for use. This is done last to lower the 
            //   possibility of adding a badly init pool.
            PoolManager.Pools.Add(this);
           
        }


        /// <summary>
        /// Runs when this group GameObject is destroyed and executes clean-up
        /// </summary>
        private void OnDestroy()
        {
            if (this.LogMessages)
                Debug.Log(string.Format("SpawnPool {0}: Destroying...", this.PoolName));
            
            UnInstallAutoCleaner();

            PoolManager.Pools.Remove(this);

            this.StopAllCoroutines();

            // We don't need the references to spawns which are about to be destroyed
            this._spawnedPoolDict.Clear();
            // Clean-up
            var _pools = new List<PrefabPool>(_prefabPools.Count);
            for (int i = 0, count = _prefabPools.Count; i < count; ++i)
            {
                _pools.Add(_prefabPools[i]);
            }
            for (int i = 0, count = _pools.Count; i < count; ++i)
            {
                var pool = _pools[i];
                pool.SelfDestruct();
            }
            _pools.Clear();
            _pools = null;
            // Probably overkill, and may not do anything at all, but...
            this._prefabPools.Clear();
            this.Prefabs._Clear();
        }


        /// <summary>
        /// Creates a new PrefabPool in this Pool and instances the requested 
        /// number of instances (set by PrefabPool.preloadAmount). If preload 
        /// amount is 0, nothing will be spawned and the return list will be empty.
        /// 
        /// It is rare this function is needed during regular usage.
        /// This function should only be used if you need to set the preferences
        /// of a new PrefabPool, such as culling or pre-loading, before use. Otherwise, 
        /// just use Spawn() and if the prefab is used for the first time a PrefabPool 
        /// will automatically be created with defaults anyway.
        /// 
        /// Note: Instances with ParticleEmitters can be preloaded too because 
        ///       it won't trigger the emmiter or the coroutine which waits for 
        ///       particles to die, which Spawn() does.
        ///       
        /// Usage Example:
        ///     // Creates a prefab pool and sets culling options but doesn't
        ///     //   need to spawn any instances (this is fine)
        ///     PrefabPool prefabPool = new PrefabPool()
        ///     prefabPool.prefab = myPrefabReference;
        ///     prefabPool.preloadAmount = 0;
        ///     prefabPool.cullDespawned = True;
        ///     prefabPool.cullAbove = 50;
        ///     prefabPool.cullDelay = 30;
        ///     
        ///     // Enemies is just an example. Any pool is fine.
        ///     PoolManager.Pools["Enemies"].CreatePrefabPool(prefabPool);
        ///     
        ///     // Then, just use as normal...
        ///     PoolManager.Pools["Enemies"].Spawn(myPrefabReference);
        /// </summary>
        /// <param name="prefabPool">A PrefabPool object</param>
        /// <returns>A List of instances spawned or an empty List</returns>
        public void CreatePrefabPool(PrefabPool prefabPool)
        {
            // Only add a PrefabPool once. Uses a GameObject comparison on the prefabs
            //   This will rarely be needed and will almost Always run at game start, 
            //   even if user-executed. This really only fails If a user tries to create 
            //   a PrefabPool using a prefab which already has a PrefabPool in the same
            //   SpawnPool. Either user created twice or PoolManager went first or even 
            //   second in cases where a user-script beats out PoolManager's init during 
            //   Awake();
            //int retry = 0;
            //RETRY:
            bool isAlreadyPool = this.GetPrefab(prefabPool.Prefab) == null ? false : true;
            if (!isAlreadyPool)
            {
                // Used internally to reference back to this spawnPool for things 
                //   like anchoring co-routines.
                prefabPool.SpawnPool = this;
                //Thousandto.UDebug.LogEx( "this._prefabPools.Count = {0}", this._prefabPools.Count );
                //Thousandto.UDebug.LogEx( "this.prefabs.Count = {0}, {1}", this.prefabs.Count, prefabPool.prefab.name );
                Utils.FLogger.DebugAssert(_prefabPools_locker == false);
                this._prefabPools.Add(prefabPool);
                // Add to the prefabs dict for convenience
                //Thousandto.UDebug.Assert( this.prefabs.ContainsKey( prefabPool.prefab.name ) == false );
                this.Prefabs._Add(prefabPool.Prefab.name, prefabPool.Prefab);
                //UnityEngine.Debug.LogError( "SpawnPool", "prefabs._Add{0}, {1}", prefabPool.prefab.name, prefabPool.prefab.GetInstanceID() );
                prefabPool._prefabName = prefabPool.Prefab.name;
            }

            // Preloading (uses a singleton bool to be sure this is only done once)
            if (prefabPool.Preloaded != true)
            {
                if (this.LogMessages)
                    Debug.Log(string.Format("SpawnPool {0}: Preloading {1} {2}",
                                               this.PoolName,
                                               prefabPool.PreloadAmount,
                                               prefabPool.Prefab.name));

                prefabPool.PreloadInstances();
            }
        }

        public void CreatePrefabPool(PrefabPoolSettings settings)
        {
            var prefabPool = new PrefabPool(settings);
            CreatePrefabPool(prefabPool);
        }


        /// <summary>
        /// Add an existing instance to this pool. This is used during game start 
        /// to pool objects which are not instanciated at runtime
        /// </summary>
        /// <param name="instance">The instance to add</param>
        /// <param name="prefabName">
        /// The name of the prefab used to create this instance
        /// </param>
        /// <param name="despawn">True to depawn on start</param>
        /// <param name="parent">True to make a child of the pool's group</param>
        public void Add(Transform instance, string prefabName, bool despawn, bool parent)
        {
            PrefabPool prefabPool = null;
            if (this._spawnedPoolDict.TryGetValue(instance, out prefabPool))
            {
                if (prefabPool._prefabGO == null)
                {
                    Debug.LogError("Unexpected Error: PrefabPool.prefabGO is null");
                    return;
                }
                if (prefabPool._prefabGO.name == prefabName)
                {
                    prefabPool.AddUnpooled(instance, despawn);
                    if (this.LogMessages)
                        Debug.Log(string.Format(
                                "SpawnPool {0}: Adding previously unpooled instance {1}",
                                                this.PoolName,
                                                instance.name));
                    if (parent)
                        instance.parent = this.Group;
                    // New instances are active and must be added to the internal list 
                    if (!despawn)
                    {
                        this._spawnedPoolDict.Add(instance, prefabPool);
                    }
                    return;
                }
            }
            else
            {
                // Log an error if a PrefabPool with the given name was not found
                Debug.LogError(string.Format("SpawnPool {0}: PrefabPool {1} not found.",
                                             this.PoolName,
                                             prefabName));
            }
        }
        #endregion Constructor and Init



        #region List Overrides
        /// <summary>
        /// Not Implimented. Use Spawn() to properly add items to the pool.
        /// This is required because the prefab needs to be stored in the internal
        /// data structure in order for the pool to function properly. Items can
        /// only be added by instencing them using SpawnInstance().
        /// </summary>
        /// <param name="item"></param>
        public void Add(Transform item)
        {
            string msg = "Use SpawnPool.Spawn() to properly add items to the pool.";
            throw new System.NotImplementedException(msg);
        }


        /// <summary>
        /// Not Implimented. Use Despawn() to properly manage items that should remain 
        /// in the Queue but be deactivated. There is currently no way to safetly
        /// remove items from the pool permentantly. Destroying Objects would
        /// defeat the purpose of the pool.
        /// </summary>
        /// <param name="item"></param>
        public void Remove(Transform item)
        {
            string msg = "Use Despawn() to properly manage items that should " +
                         "remain in the pool but be deactivated.";
            throw new System.NotImplementedException(msg);
        }

        #endregion List Overrides



        #region Pool Functionality
        /// <description>
        ///	Spawns an instance or creates a new instance if none are available.
        ///	Either way, an instance will be set to the passed position and 
        ///	rotation.
        /// 
        /// Detailed Information:
        /// Checks the Data structure for an instance that was already created
        /// using the prefab. If the prefab has been used before, such as by
        /// setting it in the Unity Editor to preload instances, or just used
        /// before via this function, one of its instances will be used if one
        /// is available, or a new one will be created.
        /// 
        /// If the prefab has never been used a new PrefabPool will be started 
        /// with default options. 
        /// 
        /// To alter the options on a prefab pool, use the Unity Editor or see
        /// the documentation for the PrefabPool class and 
        /// SpawnPool.SpawnPrefabPool()
        ///		
        /// Broadcasts "OnSpawned" to the instance. Use this instead of Awake()
        ///		
        /// This function has the same initial signature as Unity's Instantiate() 
        /// that takes position and rotation. The return Type is different though.
        /// </description>
        /// <param name="prefab">
        /// The prefab used to spawn an instance. Only used for reference if an 
        /// instance is already in the pool and available for respawn. 
        /// NOTE: Type = Transform
        /// </param>
        /// <param name="pos">The position to set the instance to</param>
        /// <param name="rot">The rotation to set the instance to</param>
        /// <returns>
        /// The instance's Transform. 
        /// 
        /// If the Limit option was used for the PrefabPool associated with the
        /// passed prefab, then this method will return null if the limit is
        /// reached. You DO NOT need to test for null return values unless you 
        /// used the limit option.
        /// </returns>
        public Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot, ref PrefabPool outPool, bool spawnActive)
        {
            Transform inst;

            #region Use from Pool
            for (int i = 0; i < this._prefabPools.Count; ++i)
            {
                PrefabPool prefabPool = this._prefabPools[i];
                // Determine if the prefab was ever used as explained in the docs
                //   I believe a comparison of two references is processor-cheap.
                if (prefabPool._prefabGO == prefab.gameObject)
                {
                    FLogger.DebugLogWarning("SpawnPool:Spawn Start", prefabPool._prefabGO.name);
                    //Thousandto.UDebug.Log( prefabPool.prefabGO.name );
                    //Thousandto.UDebug.Log( prefab.gameObject.name );
                    // Now we know the prefabPool for this prefab exists. 
                    // Ask the prefab pool to setup and activate an instance.
                    // If there is no instance to spawn, a new one is instanced
                    inst = prefabPool.SpawnInstance(pos, rot, spawnActive);

                    // This only happens if the limit option was used for this
                    //   Prefab Pool.
                    if (inst == null)
                        return null;

                    // If a new instance was created, it won't be grouped
                    if (inst.parent != this.Group)
                        inst.parent = this.Group;

                    // Add to internal list - holds only active instances in the pool
                    // 	 This isn't needed for Pool functionality. It is just done 
                    //	 as a user-friendly feature which has been needed before.
                    this._spawnedPoolDict.Add(inst, prefabPool);
                    FLogger.DebugLogWarning("SpawnPool:Spawn End", prefabPool._prefabGO.name);
                    // Done!
                    return inst;
                }
            }
            #endregion Use from Pool



            #region New PrefabPool
            // The prefab wasn't found in any PrefabPools above. Make a new one
            PrefabPool newPrefabPool = new PrefabPool(prefab);
            this.CreatePrefabPool(newPrefabPool);
            outPool = newPrefabPool;

            // Spawn the new instance (Note: prefab already set in PrefabPool)
            inst = newPrefabPool.SpawnInstance(pos, rot, spawnActive);
            inst.parent = this.Group;  // Add to this parent group

            // New instances are active and must be added to the internal list 
            this._spawnedPoolDict.Add(inst, newPrefabPool);
            #endregion New PrefabPool


            return inst;
        }



        /// <summary>
        /// See primary Spawn method for documentation.
        /// 
        /// Overload to take only a prefab and instance using an 'empty' 
        /// position and rotation.
        /// </summary>
        /// <param name="prefab"></param>
        /// <returns>
        /// The instance's Transform. 
        /// 
        /// If the Limit option was used for the PrefabPool associated with the
        /// passed prefab, then this method will return null if the limit is
        /// reached. You DO NOT need to test for null return values unless you 
        /// used the limit option.
        /// </returns>
        public Transform Spawn(Transform prefab, ref PrefabPool outPool, bool spawnActive)
        {
            return this.Spawn(prefab, Vector3.zero, Quaternion.identity, ref outPool,spawnActive);
        }

        // ParticleSystem (Shuriken) Version...
        public ParticleSystem Spawn(ParticleSystem prefab,
                                     Vector3 pos, Quaternion quat, bool spawnActive)
        {
            // Instance using the standard method before doing particle stuff
            PrefabPool prefabPool = null;
            Transform inst = Spawn(prefab.transform, pos, quat, ref prefabPool, spawnActive);

            // Can happen if limit was used
            if (inst == null)
                return null;

            // Get the emitter and start it
            var emitter = inst.GetComponent<ParticleSystem>();
            //emitter.Play(true);  // Seems to auto-play on activation so this may not be needed

            // Coroutines MUST be run on a MonoBehaviour. Use PoolManager.
            //   This will not affect PoolManager in any way. It is just used
            //   to host the coroutine
            this.StartCoroutine(this.ListenForEmitDespawn(emitter));

            return emitter;
        }

        /// <description>
        ///	If the passed object is managed by the SpawnPool, it will be 
        ///	deactivated and made available to be spawned again.
        ///		
        /// Despawned instances are removed from the primary list.
        /// </description>
        /// <param name="item">The transform of the gameobject to process</param>
        public void Despawn(Transform xform)
        {
            // Find the item and despawn it
            bool despawned = false;
            PrefabPool prefabPool = null;
            if (this._spawnedPoolDict.TryGetValue(xform, out prefabPool))
            {
                if (prefabPool._spawnedSet.Contains(xform))
                {
                    despawned = prefabPool.DespawnInstance(xform);
                }  // Protection - Already despawned?
                else if (prefabPool._despawnedSet.Contains(xform))
                {
                    Debug.LogError(
                        string.Format("SpawnPool {0}: {1} has already been despawned. " +
                                       "You cannot despawn something more than once!",
                                        this.PoolName,
                                        xform.name));
                    return;
                }
            }
            // If still false, then the instance wasn't found anywhere in the pool
            if (!despawned)
            {
                Debug.LogError(string.Format("SpawnPool {0}: {1} not found in SpawnPool",
                               this.PoolName,
                               xform.name));
                return;
            }

            // Remove from the internal list. Only active instances are kept. 
            // 	 This isn't needed for Pool functionality. It is just done 
            //	 as a user-friendly feature which has been needed before.
            this._spawnedPoolDict.Remove(xform);
        }


        /// <description>
        /// See docs for Despawn(Transform instance). This expands that functionality.
        ///   If the passed object is managed by this SpawnPool, it will be 
        ///   deactivated and made available to be spawned again.
        /// </description>
        /// <param name="item">The transform of the instance to process</param>
        /// <param name="seconds">The time in seconds to wait before despawning</param>
        public void Despawn(Transform instance, float seconds)
        {
            this.StartCoroutine(this.DoDespawnAfterSeconds(instance, seconds));
        }

        /// <summary>
        /// Waits X seconds before despawning. See the docs for DespawnAfterSeconds()
        /// </summary>
        private IEnumerator DoDespawnAfterSeconds(Transform instance, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            this.Despawn(instance);
        }


        /// <description>
        /// Despawns all active instances in this SpawnPool
        /// </description>
        public void DespawnAll()
        {
            var spawned = new List<Transform>(this._spawnedPoolDict.Keys);
            for (int i = 0, count = spawned.Count; i < count; ++i)
            {
                this.Despawn(spawned[i]);
            }
        }

        public bool IsTrimingUnusedPools()
        {
            bool retval = false;
            var _pools = new List<PrefabPool>(_prefabPools.Count);
            for (int i = 0, count = _prefabPools.Count; i < count; ++i)
            {
                _pools.Add(_prefabPools[i]);
            }
            for (int i = 0, count = _pools.Count; i < count; ++i)
            {
                var pool = _pools[i];
                if (pool.CullingActived)
                {
                    retval = true;
                    break;
                }
            }
            return retval;
        }


        public int TrimUnusedPools(GAction<Transform> preCallDeletePool, List<string> IgnorePools)
        {
            int trimCount = 0;
            // safe iteration
            var _pools = new List<PrefabPool>(_prefabPools.Count);
            for (int i = 0, count = _prefabPools.Count; i < count; ++i)
            {
                FLogger.DebugLog("PrefabPoolsInfo:",
                    _prefabPools[i].PrefabName,
                    _prefabPools[i].UsedTimeInfo.UsedFirstTime,
                    _prefabPools[i].UsedTimeInfo.UsedLastTime,
                    _prefabPools[i].UsedTimeInfo.UsedTimes,
                    _prefabPools[i].UsedTimeInfo.RefCount,
                    _prefabPools[i]._despawned.Count,
                    _prefabPools[i]._spawned.Count
                    );
                
                if (IgnorePools == null || IgnorePools.IndexOf(_prefabPools[i].PrefabName) < 0)
                {
                    _pools.Add(_prefabPools[i]);
                }
            }
            List<KeyValuePair<string, PrefabPool>> removeList = null;
            for (int i = 0, count = _pools.Count; i < count; ++i)
            {
                var pool = _pools[i];
                if (pool._spawned.Count == 0 && pool.CullingActived == false)
                {
                    ++trimCount;
                    if (pool.Prefab == null)
                    {
                        continue;
                    }
                    // callback is unsafe for _prefabPools's iterator!!
                    string prefabName = pool.Prefab.name;
                    if (preCallDeletePool != null && pool.Prefab != null)
                    {
                        preCallDeletePool(pool.Prefab);
                    }
                    pool.SelfDestruct();
                    if (removeList == null)
                    {
                        removeList = new List<KeyValuePair<string, PrefabPool>>();
                    }
                    removeList.Add(new KeyValuePair<string, PrefabPool>(prefabName, pool));
                }
                else
                {
                    pool.markActiveTrimInCulling();
                }
            }
            if (removeList != null)
            {
                for (int i = 0, count = removeList.Count; i < count; ++i)
                {
                    bool a = Prefabs._Remove(removeList[i].Key);
                    bool b = _prefabPools.Remove(removeList[i].Value);
                    if (a != b)
                    {
                        FLogger.DebugLog(string.Format("SpawnPool.TrimUnusedPools: remove pool: {0}, {1}-{2}", removeList[i].Key, a, b));
                        FLogger.DebugLog("Dump PrefabsDict");
                        foreach (var item in Prefabs)
                        {
                            FLogger.DebugLog(item.Key);
                        }
                        FLogger.DebugLog("Dump PrefabsDict End.");
                        FLogger.DebugAssert(false);
                    }
                }
                removeList.Clear();
                removeList = null;
                FLogger.DebugLogFormat("SpawnPool[{0}]: TrimUnusedPools: {1}", PoolName, trimCount.ToString());
            }
            _pools.Clear();
            _pools = null;
            return trimCount;
        }

        /// <description>
        ///	Returns true if the passed transform is currently spawned.
        /// </description>
        /// <param name="item">The transform of the gameobject to test</param>
        public bool IsSpawned(Transform instance)
        {
            return this._spawnedPoolDict.ContainsKey(instance);
        }

        #endregion Pool Functionality



        #region Utility Functions
        /// <summary>
        /// Returns the prefab used to create the passed instance. 
        /// This is provided for convienince as Unity doesn't offer this feature.
        /// </summary>
        /// <param name="prefab">The Transform of an instance</param>
        /// <returns>Transform</returns>
        public Transform GetPrefab(Transform prefab)
        {
            for (int i = 0; i < this._prefabPools.Count; ++i)
            {
                PrefabPool prefabPool = this._prefabPools[i];
                if (prefabPool._prefabGO == null)
                    Debug.LogError(string.Format("SpawnPool {0}-{1}: PrefabPool.prefabGO is null",
                                                 this.PoolName ?? "...", prefabPool._prefabName));

                if (prefabPool._prefabGO == prefab.gameObject)
                    return prefabPool.Prefab;
            }

            // Nothing found
            return null;
        }


        /// <summary>
        /// Returns the prefab used to create the passed instance. 
        /// This is provided for convienince as Unity doesn't offer this feature.
        /// </summary>
        /// <param name="prefab">The GameObject of an instance</param>
        /// <returns>GameObject</returns>
        public GameObject GetPrefab(GameObject prefab)
        {
            for (int i = 0; i < this._prefabPools.Count; ++i)
            {
                PrefabPool prefabPool = this._prefabPools[i];
                if (prefabPool._prefabGO == null)
                    Debug.LogError(string.Format("SpawnPool {0}: PrefabPool.prefabGO is null",
                                                 this.PoolName));

                if (prefabPool._prefabGO == prefab)
                    return prefabPool._prefabGO;
            }

            // Nothing found
            return null;
        }

        public bool IsInPool(Transform prefab)
        {
            return GetPrefab(prefab) != null;
        }

        public bool IsInPool(GameObject prefab)
        {
            return GetPrefab(prefab) != null;
        }

        // ParticleSystem (Shuriken) Version...
        private IEnumerator ListenForEmitDespawn(ParticleSystem emitter)
        {
            // Wait for the delay time to complete
            // Waiting the extra frame seems to be more stable and means at least one 
            //  frame will always pass
            yield return new WaitForSeconds(emitter.main.startDelayMultiplier + 0.25f);

            // Do nothing until all particles die or the safecount hits a max value
            float safetimer = 0;   // Just in case! See Spawn() for more info
            while (emitter.IsAlive(true))
            {
                if (!PoolManagerUtils.activeInHierarchy(emitter.gameObject))
                {
                    emitter.Clear(true);
                    yield break;  // Do nothing, already despawned. Quit.
                }
                safetimer += Time.deltaTime;
                if (safetimer > this.MaxParticleDespawnTime)
                    Debug.LogWarning
                    (
                        string.Format
                        (
                            "SpawnPool {0}: " +
                                "Timed out while listening for all particles to die. " +
                                "Waited for {1}sec.",
                            this.PoolName,
                            this.MaxParticleDespawnTime
                        )
                    );

                yield return null;
            }

            // Turn off emit before despawning
            //emitter.Clear(true);
            this.Despawn(emitter.transform);
        }

        #endregion Utility Functions



        /// <summary>
        /// Returns a formatted string showing all the spawned member names
        /// </summary>
        public override string ToString()
        {
            // Get a string[] array of the keys for formatting with join()
            var name_list = new List<string>();
            foreach (Transform item in this._spawnedPoolDict.Keys)
                name_list.Add(item.name);

            // Return a comma-sperated list inside square brackets (Pythonesque)
            return System.String.Join(", ", name_list.ToArray());
        }


        /// <summary>
        /// Read-only index access. You can still modify the instance at the given index.
        /// Read-only reffers to setting an index to a new instance reference, which would
        /// change the list. Setting via index is never needed to work with index access.
        /// </summary>
        /// <param name="index">int address of the item to get</param>
        /// <returns></returns>
        public Transform this[int index]
        {
            get { throw new System.NotImplementedException("use-less"); }
            set { throw new System.NotImplementedException("Read-only."); }
        }

        /// <summary>
        /// The name "Contains" is misleading so IsSpawned was implimented instead.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(Transform item)
        {
            string message = "Use IsSpawned(Transform instance) instead.";
            throw new System.NotImplementedException(message);
        }


        /// <summary>
        /// Used by OTHERList.AddRange()
        /// This adds this list to the passed list
        /// </summary>
        /// <param name="array">The list AddRange is being called on</param>
        /// <param name="arrayIndex">
        /// The starting index for the copy operation. AddRange seems to pass the last index.
        /// </param>
        public void CopyTo(Transform[] array, int arrayIndex)
        {
            var _spawned = new List<Transform>(_spawnedPoolDict.Keys);
            _spawned.CopyTo(array, arrayIndex);
        }


        /// <summary>
        /// Returns the number of items in this (the collection). Readonly.
        /// </summary>
        public int Count
        {
            get { return this._spawnedPoolDict.Count; }
        }


        /// <summary>
        /// Impliments the ability to use this list in a foreach loop
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Transform> GetEnumerator()
        {
            foreach (Transform instance in this._spawnedPoolDict.Keys)
                yield return instance;
        }

        /// <summary>
        /// Impliments the ability to use this list in a foreach loop
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (Transform instance in this._spawnedPoolDict.Keys)
                yield return instance;
        }

        // Not implemented
        public int IndexOf(Transform item) { return -1; }
        public void Insert(int index, Transform item) {  }
        public void RemoveAt(int index) {}
        public void Clear() { }
        public bool IsReadOnly { get { return false; } }
        bool ICollection<Transform>.Remove(Transform item) { return true; }

        #region//AutoCleaner
        public void InstallAutoCleaner(float liftTime, float tick,int remainCnt = 0)
        {
            FLogger.DebugLog("Spawn Pool InstallAutoCleaner:", name, liftTime, tick, remainCnt);

            AutoCleanerManager.SharedInstance.AddCleaner<PrefabPool>(_prefabPools, (x) =>
            {
                FLogger.DebugLog("PrefabPool AutoClear:", x._prefabName);
                var despawned = x.cullDespawned;
                var cullAbove = x.CullAbove;
                var cullDelay = x.CullDelay;
                var maxPerPass = x.CullMaxPerPass;

                x.cullDespawned = true;
                x.CullAbove = remainCnt;
                x.CullDelay = 1;
                x.CullMaxPerPass = 100;
                
                x.Sweep();
                x.markActiveTrimInCulling();

                x.cullDespawned = despawned;
                x.CullAbove = cullAbove;
                x.CullDelay = cullDelay;
                x.CullMaxPerPass = maxPerPass;

                return false;
            }, liftTime, tick);
 
        }
        public void UnInstallAutoCleaner()
        {
            AutoCleanerManager.SharedInstance.RemoveCleaner(_prefabPools);
        }
        #endregion

    }










    
}