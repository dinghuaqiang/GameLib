using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Assets.Test.PlayableTest
{
    /// <summary>
    /// 继承PlayableBehaviour，实现AnimationClip的序列化播放
    /// </summary>
    public class PlayableQueueScripts : PlayableBehaviour
    {
        private int _curClipIndex = -1;
        private float _timeToNextClip = 0f;
        private Playable _mixer;

        public void Initialize(AnimationClip[] clips, Playable ownerPlayable, PlayableGraph graph) 
        {
            //改变Playable支持的输入数量
            ownerPlayable.SetInputCount(1);
            //根据Clips的数量初始化混合器
            _mixer = AnimationMixerPlayable.Create(graph, clips.Length);
            graph.Connect(_mixer, 0, ownerPlayable, 0);
            ownerPlayable.SetInputWeight(0, 1);
            for (int i = 0; i < _mixer.GetInputCount(); i++)
            {
                AnimationClipPlayable clipPlayable = AnimationClipPlayable.Create(graph, clips[i]);
                graph.Connect(clipPlayable, 0, _mixer, i);
                _mixer.SetInputWeight(i, 1);
            }
        }

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            base.OnBehaviourPlay(playable, info);
            Debug.Log("PlayableQueueScripts OnBehaviourPlay");
        }

        public override void PrepareData(Playable playable, FrameData info)
        {
            base.PrepareData(playable, info);
            Debug.Log("PlayableQueueScripts PrepareData");
        }

        public override void PrepareFrame(Playable playable, FrameData info)
        {
            base.PrepareFrame(playable, info);
            Debug.Log("PlayableQueueScripts PrepareFrame");
            if (_mixer.GetInputCount() == 0)
            {
                return;
            }
            _timeToNextClip -= info.deltaTime;
            if (_timeToNextClip <= 0.0f)
            {
                _curClipIndex++;
                if (_curClipIndex >= _mixer.GetInputCount())
                {
                    _curClipIndex = 0;
                }
                AnimationClipPlayable curClipPlayable = (AnimationClipPlayable)_mixer.GetInput(_curClipIndex);
                //重置本地时间，这个类似于clip的持续时间，这里设置开始播放的帧时间
                curClipPlayable.SetTime(0);
                //获取到Clip的时长
                _timeToNextClip = curClipPlayable.GetAnimationClip().length;
            }
            //调整播放权重
            for (int i = 0; i < _mixer.GetInputCount(); i++)
            {
                if (i == _curClipIndex)
                {
                    _mixer.SetInputWeight(i, 1.0f);
                }
                else
                {
                    _mixer.SetInputWeight(i, 0.0f);
                }
            }
        }

        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            base.ProcessFrame(playable, info, playerData);
            Debug.Log("PlayableQueueScripts ProcessFrame");
        }
    }
}
