using UnityEngine.SceneManagement;

namespace GameLib.Core.Scene
{
    public class GameSceneManager
    {
        public UnityEngine.SceneManagement.Scene GetActiveScene()
        {
            return SceneManager.GetActiveScene();
        }

        public string GetActiveSceneName()
        {
            return SceneManager.GetActiveScene().name;
        }

        public void LoadScene()
        {

        }

        public void UnloadScene()
        {

        }
    }
}
