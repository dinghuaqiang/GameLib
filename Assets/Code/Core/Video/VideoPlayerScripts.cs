using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace GameLib.Core.Video
{
    /// <summary>
    /// 作者：丁华强
    /// 描述: 视频播放器,外部调用PlayVideo直接播放  
    ///       Example: VideoPlayerScripts.PlayVideo(videoPath, callbackfun);
    /// 时间：2022-12-8 16:16:45
    /// </summary>
    public class VideoPlayerScripts : MonoBehaviour
    {
        //播放完成的回调
        private Action m_onFinishedCall = null;
        //视频原始地址
        private string m_filePath = null;
        //Unity的视频播放组件
        private UnityEngine.Video.VideoPlayer m_videoPlayer = null;
        //播放视频的摄像机
        private Camera m_videoCamera = null;
        private readonly static string CN_VIDEO_GO_NAME = "[VideoRoot]";
        private readonly static string CN_VIDEO_PREFAB_PATH = "Default/Video/VideoRoot";

        /// <summary>
        /// 播放视频
        /// </summary>
        /// <param name="videoPath">视频的地址</param>
        /// <param name="onFinishedCall">播放完成的回调</param>
        /// <param name="isLoop">是否重复播放</param>
        /// <param name="playOnAwake">是否开始就播放</param>
        public static void PlayVideo(string videoPath, Action onFinishedCall, bool isLoop = false, bool playOnAwake = false)
        {
            if (!File.Exists(videoPath))
            {
                if (onFinishedCall != null)
                {
                    onFinishedCall();
                }
                Debug.LogError(string.Format("视频播放失败，文件 {0} 不存在!", videoPath));
                return;
            }
            var videoRoot = GameObject.Find(CN_VIDEO_GO_NAME);
            VideoPlayerScripts m_videoScript = null;
            if (!videoRoot)
            {
                var asset = Resources.Load<GameObject>(CN_VIDEO_PREFAB_PATH);
                if (asset == null)
                {
                    Debug.LogError(string.Format("预设 {0} 查找不到，检查是否缺失文件。", CN_VIDEO_PREFAB_PATH));
                    return;
                }
                videoRoot = Instantiate(asset) as GameObject;
                videoRoot.name = CN_VIDEO_GO_NAME;
                if (videoRoot != null)
                {
                    DontDestroyOnLoad(videoRoot);
                }
            }
            m_videoScript = videoRoot.GetComponent<VideoPlayerScripts>();
            if (m_videoScript == null)
            {
                videoRoot.AddComponent<VideoPlayerScripts>();
            }
            m_videoScript.Play(videoPath, onFinishedCall, isLoop, playOnAwake);
        }

        private void Play(string videoPath, Action onFinishedCall, bool isLoop = false, bool playOnAwake = false)
        {
            m_filePath = videoPath;
            m_onFinishedCall = onFinishedCall;

            if (m_videoPlayer != null)
            {
                m_videoPlayer.url = m_filePath;
                m_videoPlayer.isLooping = isLoop;
                m_videoPlayer.playOnAwake = playOnAwake;
                m_videoPlayer.Prepare();
                m_videoPlayer.Play();
            }
            else
            {
                Debug.LogError("视频播放失败，视频播放组件是空的。");
            }
        }

        private void Awake()
        {
            //获取相机
            Transform videoCameraTrans = transform.Find("VideoCamera");
            if (videoCameraTrans != null)
            {
                m_videoCamera = transform.Find("VideoCamera").GetComponent<Camera>();
            }
            Button skipBtn = transform.Find("Canvas/SkipBtn").GetComponent<Button>();
            if (!skipBtn.gameObject.activeSelf)
            {
                skipBtn.gameObject.SetActive(true);
            }
            //#if UNITY_EDITOR
            //        skipBtn.gameObject.SetActive(true);
            //#else
            //        skipBtn.gameObject.SetActive(false);
            //#endif
            skipBtn.onClick.AddListener(StopPlay);
            //获取Unity播放组件
            m_videoPlayer = transform.GetComponent<UnityEngine.Video.VideoPlayer>();
            if (m_videoPlayer == null)
            {
                m_videoPlayer = gameObject.AddComponent<UnityEngine.Video.VideoPlayer>();
            }
            if (m_videoPlayer != null)
            {
                //使用设置路径的方式播放
                m_videoPlayer.source = VideoSource.Url;
                //近相机平面播放
                m_videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
                //设置播放的拉伸模式
                m_videoPlayer.aspectRatio = VideoAspectRatio.Stretch;
                m_videoPlayer.isLooping = false;
                m_videoPlayer.playOnAwake = false;
                //设置播放的相机
                m_videoPlayer.targetCamera = m_videoCamera;
                //到达循环播放点的回调，这里用作结束
                m_videoPlayer.loopPointReached += OnWillFinshedCall;
            }
        }

        private void StopPlay()
        {
            if (m_videoPlayer != null)
            {
                OnWillFinshedCall(null);
            }
        }

        private void OnWillFinshedCall(UnityEngine.Video.VideoPlayer player)
        {
            //当前播放的视频已经播放完毕了，清理回调，删除视频播放节点
            if (m_onFinishedCall != null)
            {
                m_onFinishedCall();
                m_onFinishedCall = null;
            }
            m_videoPlayer.loopPointReached -= OnWillFinshedCall;
            m_videoPlayer.Stop();
            DestoryVideoPlay();
        }

        private void DestoryVideoPlay()
        {
            GameObject videoRoot = GameObject.Find(CN_VIDEO_GO_NAME);
            if (videoRoot != null)
            {
                DestroyImmediate(videoRoot);
            }
        }

        //private void Update()
        //{
        //    if (m_videoPlayer != null && m_videoPlayer.isPrepared && m_videoPlayer.isPlaying)
        //    {
        //        //根据视频帧率播放进度来结束
        //        if (m_videoPlayer.frame >= (long)m_videoPlayer.frameCount - 1)
        //        {
        //            if (!m_videoPlayer.isLooping)
        //            {
        //                //当前播放的视频已经播放完毕了，清理回调，隐藏视频播放节点
        //                //OnWillFinshedCall(m_videoPlayer);
        //            }
        //        }
        //    }
        //}
    }
}
