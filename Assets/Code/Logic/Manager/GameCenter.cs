using Code.Logic.PreLoad;
using Code.Logic.System;
using GameLib.Core.Event;
using GameLib.Core.UI;
using EventHandler = GameLib.Core.Event.EventManager.EventHandler;

namespace Code.Logic.Manager
{
    public static class GameCenter
    {
        public static GameStateSystem GameStateSystem = null;
        public static UIFormManager UIFormManager = null;
        public static FormStateSystem FormStateSystem = null;
        //窗体预加载处理
        public static PreLoadFormRoot PreLoadFormRoot = null;

        public static void CreateSystem()
        {
            GameStateSystem = new GameStateSystem();
            UIFormManager = new UIFormManager();
            FormStateSystem = new FormStateSystem();
            PreLoadFormRoot = new PreLoadFormRoot();
        }

        public static void Initialize()
        {
            GameStateSystem.Initialize();
            //UIFormManager.Initialize();
            FormStateSystem.Initialize();
        }

        public static void UnInitialize()
        {
            GameStateSystem.UnInitialize();
            //UIFormManager.UnInitialize();
            FormStateSystem.UnInitialize();
        }

        public static void ApplicationQuit()
        {

        }

        public static void Update(float deltaTime)
        {
            GameStateSystem.Update(deltaTime);
            //UIFormManager.Update(deltaTime);
            PreLoadFormRoot.Update();
        }

        public static void FixedUpdate(float deltaTime)
        {

        }

        public static void LateUpdate(float deltaTime)
        {

        }

        #region //静态函数--事件处理
        public static void PushFixEvent(LogicEventDefine eventID, object obj = null, object sender = null)
        {
            EventManager.SharedInstance.PushFixEvent((int)eventID, obj, sender);
        }

        public static void PushFixEvent(UIEventDefine eventID, object obj = null, object sender = null)
        {
            EventManager.SharedInstance.PushFixEvent((int)eventID, obj, sender);
        }

        public static void PushFixEvent(int eventID, object obj = null, object sender = null)
        {
            EventManager.SharedInstance.PushFixEvent(eventID, obj, sender);
        }

        public static EventHandler RegFixEventHandle(LogicEventDefine eventType, EventHandler eventHandler)
        {
            return EventManager.SharedInstance.RegEventHandle((int)eventType, eventHandler);
        }
        public static EventHandler RegFixEventHandle(UIEventDefine eventType, EventHandler eventHandler)
        {
            return EventManager.SharedInstance.RegEventHandle((int)eventType, eventHandler);
        }
        public static EventHandler RegFixEventHandle(int eventType, EventHandler eventHandler)
        {
            return EventManager.SharedInstance.RegEventHandle(eventType, eventHandler);
        }

        public static void UnRegFixEventHandle(LogicEventDefine eventType, EventHandler eventHandler)
        {
            EventManager.SharedInstance.UnRegEventHandle((int)eventType, eventHandler);
        }
        public static void UnRegFixEventHandle(UIEventDefine eventType, EventHandler eventHandler)
        {
            EventManager.SharedInstance.UnRegEventHandle((int)eventType, eventHandler);
        }
        public static void UnRegFixEventHandle(int eventType, EventHandler eventHandler)
        {
            EventManager.SharedInstance.UnRegEventHandle(eventType, eventHandler);
        }

        #endregion
    }
}
