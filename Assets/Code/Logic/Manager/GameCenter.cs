using Code.Logic.System;
using GameLib.Core.UI;

namespace Code.Logic.Manager
{
    public static class GameCenter
    {
        public static GameStateSystem GameStateSystem = null;
        public static UIFormManager UIFormManager = null;
        public static void CreateSystem()
        {
            GameStateSystem = new GameStateSystem();
            UIFormManager = new UIFormManager();
        }

        public static void Initialize()
        {
            GameStateSystem.Initialize();
            //UIFormManager.Initialize();
        }

        public static void UnInitialize()
        {
            GameStateSystem.UnInitialize();
            //UIFormManager.UnInitialize();
        }

        public static void ApplicationQuit()
        {

        }

        public static void Update(float deltaTime)
        {
            GameStateSystem.Update(deltaTime);
            //UIFormManager.Update(deltaTime);
        }

        public static void FixedUpdate(float deltaTime)
        {

        }

        public static void LateUpdate(float deltaTime)
        {

        }
        
    }
}
