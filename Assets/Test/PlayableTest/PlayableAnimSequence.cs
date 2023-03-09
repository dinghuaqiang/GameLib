using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Assets.Test.PlayableTest
{
    /// <summary>
    /// AnimationClip序列播放
    /// </summary>
    public class PlayableAnimSequence : MonoBehaviour
    {
        /// <summary>
        /// Animation的源数据
        /// </summary>
        public AnimationClip[] _clips;

        private PlayableGraph _playableGraph;
        private AnimationMixerPlayable _animMixerPlayable;
        private List<AnimationClipPlayable> _animPlayableList;
        private int _curPlayClipIndex = -1;
        private AnimationClipPlayable _curClipPlayable;

        private void Start()
        {
            if (_clips == null || _clips.Length <= 0)
            {
                Debug.LogError("没有给Clips赋值，去拖点动作片上去。");
                return;
            }
            //初始化数据
            _curPlayClipIndex = 0;
            _animPlayableList = new List<AnimationClipPlayable>(_clips.Length);

            //获取Animator
            Animator animator = transform.Find("PaiMeng").GetComponent<Animator>();
            //创建播放图
            _playableGraph = PlayableGraph.Create("AnimSequenceGraph");
            //设置需要混合的动作片数量
            _animMixerPlayable = AnimationMixerPlayable.Create(_playableGraph, _clips.Length);
            //创建Anim的Playable输出，指定Animator
            AnimationPlayableOutput animOutput = AnimationPlayableOutput.Create(_playableGraph, "AnimOutput", animator);
            //设置混合器
            animOutput.SetSourcePlayable(_animMixerPlayable);
            //对AnimationClip进行连接
            for (int i = 0; i < _clips.Length; i++)
            {
                AnimationClipPlayable clipPlayable = AnimationClipPlayable.Create(_playableGraph, _clips[i]);
                _playableGraph.Connect(clipPlayable, 0, _animMixerPlayable, i);
                _animPlayableList.Add(clipPlayable);
            }
            _animMixerPlayable.SetInputWeight(0, 1);
            _playableGraph.Play();
        }

        private void Update()
        {
            //按 -> 右方向键进行动作的切换
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (_curPlayClipIndex >= _clips.Length)
                {
                    _curPlayClipIndex = 0;
                    return;
                }
                if (_curPlayClipIndex >= 0)
                {
                    //input	要更改的已连接 Playable。 weight 权重。值应在 0 到 1 之间。
                    //更改连接到当前 Playable 的 Playable 的权重。
                    //停掉
                    _animMixerPlayable.SetInputWeight(_curPlayClipIndex, 0);
                }
                //下一个动作从头开始播放
                _animMixerPlayable.SetInputWeight(_curPlayClipIndex, 1);
                //取下一个动作片段来播放
                AnimationClipPlayable curClipPlayable = _animPlayableList[_curPlayClipIndex];
                //重置动画时间，让下一个动画片段从头开始播放，这个有点类似于AnimationClip的duration
                curClipPlayable.SetTime(0);
                if (!_playableGraph.IsPlaying())
                {
                    _playableGraph.Play();
                }
                _curPlayClipIndex++;
            }
        }
    }
}
