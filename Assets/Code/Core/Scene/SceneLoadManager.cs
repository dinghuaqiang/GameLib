using GameLib.Core.Utils;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameLib.Core.Scene
{
    //public class SceneLoadManager : ISceneManager
    public class SceneLoadManager
    {
        public void LoadSceneAsyncByName(string sceneName)
        {
            CollectGC();
            SceneManager.LoadSceneAsync(sceneName);
        }

        /// <summary>
        /// 加载一个新场景附加到当前的场景
        /// </summary>
        /// <param name="sceneName"></param>
        public void LoadAdditiveScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        private void CollectGC()
        {
            Resources.UnloadUnusedAssets();
            System.GC.Collect();
        }

        //public Coroutine LoadSceneAsync(SceneInfo sceneInfo, Action callback = null)
        //{
            
        //}

        //public Coroutine LoadSceneAsync(SceneInfo sceneInfo, Action<float> progress, Action callback = null)
        //{
            
        //}

        //public Coroutine LoadSceneAsync(SceneInfo sceneInfo, Func<bool> condition, Action callback = null)
        //{
            
        //}

        //public Coroutine LoadSceneAsync(SceneInfo sceneInfo, Action<float> progress, Func<bool> condition, Action callback = null)
        //{
            
        //}

        //public Coroutine LoadSceneAsync(SceneInfo sceneInfo, Func<float> progressProvider, Action<float> progress, Action callback = null)
        //{
            
        //}

        //public Coroutine LoadSceneAsync(SceneInfo sceneInfo, Func<float> progressProvider, Action<float> progress, Func<bool> condition, Action callback = null)
        //{
            
        //}

        //public Coroutine UnloadSceneAsync(SceneInfo sceneInfo, Action callback = null)
        //{
            
        //}

        //public Coroutine UnloadSceneAsync(SceneInfo sceneInfo, Action<float> progress, Action callback = null)
        //{
            
        //}

        //public Coroutine UnloadSceneAsync(SceneInfo sceneInfo, Func<bool> condition, Action callback = null)
        //{
            
        //}

        public Coroutine UnloadSceneAsync(SceneInfo sceneInfo, Action<float> progress, Func<bool> condition, Action callback = null)
        {
            return CoroutinePool.AddTask(UnloadSceneAsyncImpl(sceneInfo, progress, condition, callback));
        }

        private IEnumerator UnloadSceneAsyncImpl(SceneInfo sceneInfo, Action<float> progress, Func<bool> condition, Action callback = null)
        {
            SceneManager.LoadSceneAsync(sceneInfo.SceneName);
            SceneManager.UnloadSceneAsync(sceneInfo.SceneName);
            yield return new WaitForEndOfFrame();
        }
    }
}
