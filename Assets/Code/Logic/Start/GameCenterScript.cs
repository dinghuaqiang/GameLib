using Code.Logic.Manager;
using Code.Logic.System;
using GameLib.Core.Utils;
using System;
using UnityEngine;

namespace Code.Logic.Start
{
    public class GameCenterScript : MonoBehaviour
    {
        private static bool _isCreated = false;
        private static float _pauseTime = 0;

        private void Awake()
        {
            Application.quitting -= DoApplicationQuit;
            Application.quitting += DoApplicationQuit;
        }

        private void Start()
        {
            ScreenSystem.SetDesignContentScale();
        }

        void Update()
        {
            if (_isCreated)
            {
                try
                {
                    GameCenter.Update(Time.deltaTime);
                }
                catch (Exception ex)
                {
                    Debug.LogException(ex);
                }
            }

        }

        void FixedUpdate()
        {
            if (_isCreated)
            {
                GameCenter.FixedUpdate(Time.deltaTime);
            }
        }

        void LateUpdate()
        {
            if (_isCreated)
            {
                GameCenter.LateUpdate(Time.deltaTime);
            }
        }

        private void OnApplicationFocus(bool focus)
        {
            if (_isCreated)
            {
                //GameCenter.IsFocused = focus;
                //GameCenter.PushFixEvent(Global.LogicEventDefine.EID_EVENT_APPFOCUS);
            }
        }

        private void OnApplicationPause(bool paused)
        {
            if (_isCreated)
            {
                if (!paused)
                {
                    ScreenSystem.SetDesignContentScale();
                    if (GameCenter.GameStateSystem != null)
                    {
                        var curState = GameCenter.GameStateSystem.GetCurState();
                        if (curState != null)
                        {
                            //if (curState is LoginState)
                            //{
                            //    //后台没播放音乐，才播放游戏背景音乐
                            //    AudioPlayer.PlayMusic(LoginState.GetLoginMusicName());
                            //}
                            //else
                            //{
                            //    //后台没播放音乐，才播放游戏背景音乐
                            //    GameCenter.GameSceneSystem.PlayBGMusic();
                            //    var deltaTimeWhilePauseResume = Time.realtimeSinceStartup - _pauseTime;
                            //    if (deltaTimeWhilePauseResume >= 2 * 60)
                            //    {
                            //        GameCenter.Networker.Disconnect();
                            //        GameCenter.ReconnectSystem.Reconnect();
                            //    }
                            //}
                        }
                    }
                }
                else
                {
                    //GameCenter.GameSceneSystem.StopBGMusic(true);
                    _pauseTime = Time.realtimeSinceStartup;
                }
            }
        }

        //laucher端调用,设置游戏的启动参数
        public void GameStart(string lang, bool isStream, int buildType)
        {
            //Debug.Log("GameStart lang:" + (lang == null ? "null" : lang));
            if (!string.IsNullOrEmpty(lang))
            {
                //LanguageSystem.SetPackageLang(lang);
            }

            if (PathUtils.IsStreaming())
            {
                //AnimationClipManager.UseAsynLoadAnimClip = true;
                //AnimationClipManager.SyncLoadAnimHandler = null;
            }
#if UNITY_EDITOR  && !FUNCELL_LAUNCHER
            else
            {
                //AnimationClipManager.SyncLoadAnimHandler = x => {
                //    return UnityEditor.AssetDatabase.LoadAssetAtPath<AnimationClip>(x);
                //};
            }
#endif


            if (!_isCreated)
            {
                name = "[MainEntry]";
                DontDestroyOnLoad(gameObject);
                _isCreated = true;
                GameCenter.CreateSystem();
                GameCenter.Initialize();
            }
            else
            {
                Destroy(gameObject);
            }

            /*
            if (gameObject.GetComponent<GameExtentScript>() == null)
            {
                gameObject.AddComponent<GameExtentScript>();
            } */
        }

        //Launcher端调用，直接进入登录状态
        public void ChangeToLogin()
        {
            if (_isCreated)
            {
                if (GameCenter.GameStateSystem != null)
                    GameCenter.GameStateSystem.ChangeState((int)GameStateId.Login);
            }
        }

        void DoApplicationQuit()
        {
            if (_isCreated)
            {
                GameCenter.UnInitialize();
                GameCenter.ApplicationQuit();
            }
        }

#if UNITY_EDITOR
        //在编辑器状态下,当被选择后的一些图形
        void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                //Core.Asset.DynamicBoneSystem.SharedInstance.OnGizmos();
            }
        }
#endif
    }
}
