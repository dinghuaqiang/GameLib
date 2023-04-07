using GameLib.Core.Base;
using UnityEngine;

namespace GameLib.Core.Support
{
    /// <summary>
    /// PrefabPool的Settings类
    /// </summary>
    public class PrefabPoolSettings
    {
        public Transform Prefab;
        public int PreloadAmount;
        public bool PreloadTime;
        public int PreloadFrames;
        public float PreloadDelay;
        public bool LimitInstances;
        public int LimitAmount;
        public bool LimitFIFO;
        public bool CullDespawned;
        public int CullAbove;
        public int CullDelay;
        public int CullMaxPerPass;
        public bool LogMessages;

        public GAction<PrefabPool> OnPreDestroy; // call on this pool has been destroied
        public GAction<PrefabPool> OnPostDestroy; // call on this pool has been destroied
        public GAction<PrefabPool> OnNotifyCulled; // call on this pool has been destroied

        public PrefabPoolSettings(Transform _prefab)
        {
            Prefab = _prefab;
            PreloadAmount = 1;
            PreloadTime = false;
            PreloadFrames = 2;
            PreloadDelay = 0;
            LimitInstances = false;
            LimitAmount = 100;
            LimitFIFO = false;
            CullDespawned = false;
            CullAbove = 50;
            CullDelay = 60;
            CullMaxPerPass = 5;
            LogMessages = false;
            OnPreDestroy = null;
            OnPostDestroy = null;
            OnNotifyCulled = null;
        }
    }
}
