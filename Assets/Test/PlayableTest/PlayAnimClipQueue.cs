using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

namespace Assets.Test.PlayableTest
{
    public class PlayAnimClipQueue : MonoBehaviour
    {
        public AnimationClip[] _clips;
        private PlayableGraph _playableGraph;

        private void Start()
        {
            Animator animator = transform.Find("PaiMeng").GetComponent<Animator>();
            _playableGraph = PlayableGraph.Create("PlayAnimClipQueue");
            //创建脚本
            var queuePlayable = ScriptPlayable<PlayableQueueScripts>.Create(_playableGraph);
            PlayableQueueScripts queueScripts = queuePlayable.GetBehaviour();
            queueScripts.Initialize(_clips, queuePlayable, _playableGraph);
            AnimationPlayableOutput animPlayableOutput = AnimationPlayableOutput.Create(_playableGraph, "Output", animator);
            animPlayableOutput.SetSourcePlayable(queuePlayable);
            animPlayableOutput.SetSourceOutputPort(0);

            _playableGraph.Play();
        }

        private void OnDisable()
        {
            _playableGraph.Destroy();
        }
    }
}
