/// <Licensing>
/// ?2011 (Copyright) Path-o-logical Games, LLC
/// Licensed under the Unity Asset Package Product License (the "License");
/// You may not use this file except in compliance with the License.
/// You may obtain a copy of the License at: http://licensing.path-o-logical.com
/// </Licensing>
using UnityEngine;

namespace GameLib.Core.Support
{

    /// <description>
    /// PoolManager v2.0
    ///  - PoolManager.Pools is not a complete implimentation of the IDictionary interface
    ///    Which enabled:
    ///        * Much more acurate and clear error handling
    ///        * Member access protection so you can't run anything you aren't supposed to.
    ///  - Moved all functions for working with Pools from PoolManager to PoolManager.Pools
    ///    which enabled shorter names to reduces the length of lines of code.
    /// Online Docs: http://docs.poolmanager2.path-o-logical.com
    /// </description>
    public static class PoolManager
    {
        public static readonly SpawnPoolsDict Pools = new SpawnPoolsDict();
    }


    public static class PoolManagerUtils
    {
        internal static void SetActive(GameObject obj, bool state)
        {
#if (UNITY_3_5 || UNITY_3_4 || UNITY_3_3 || UNITY_3_2 || UNITY_3_1 || UNITY_3_0)
        obj.SetActiveRecursively(state);
#else
            obj.SetActive(state);
#endif
        }

        internal static bool activeInHierarchy(GameObject obj)
        {
#if (UNITY_3_5 || UNITY_3_4 || UNITY_3_3 || UNITY_3_2 || UNITY_3_1 || UNITY_3_0)
        return obj.active;
#else
            return obj.activeInHierarchy;
#endif

        }
    }


}