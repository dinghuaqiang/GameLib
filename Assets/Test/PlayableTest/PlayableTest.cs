using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.Playables;

/// <summary>
/// https://blog.csdn.net/js0907/article/details/108331489
/// https://www.cnblogs.com/sailJs/p/16989878.html
/// https://docs.unity3d.com/ScriptReference/Playables.Playable.html
/// https://www.cnblogs.com/caiger-blog/p/13700821.html
/// https://zhuanlan.zhihu.com/p/97826181
/// https://blog.csdn.net/LWR_Shadow/article/details/128217136
/// </summary>
public class PlayableTest : MonoBehaviour
{
    public AnimationClip _animClip1;
    public AnimationClip _animClip2;
    public AnimationClip _animClip3;

    public AnimationClip[] animationClips;

    private readonly string CN_PLAYABLE_GRAPH_NAME = "PlayableTest";
    private readonly string CN_ANIMCLIP_OUTPUT_NAME = "AnimOutputTest";
    private readonly string CN_AUDIO_OUTPUT_NAME = "AudioOutputTest";

    private Transform _paimengTrans;
    private PlayableGraph _playableGraph;
    private AnimationPlayableOutput _animclipOutput;
    private AudioPlayableOutput _audioOutput;
    private Animator _animator = null;
    AnimationMixerPlayable _mixerPlayable;

    public RuntimeAnimatorController _controller;

    public AudioClip _audioClip;

    [Range(0, 1)]
    public float _weight;

    void Start()
    {
        _paimengTrans = transform.Find("PaiMeng");
        _animator = _paimengTrans.GetComponent<Animator>();
        AudioSource audioSource = transform.GetComponent<AudioSource>();

        _playableGraph = PlayableGraph.Create(CN_PLAYABLE_GRAPH_NAME);
        _animclipOutput = AnimationPlayableOutput.Create(_playableGraph, CN_ANIMCLIP_OUTPUT_NAME, _animator);
        _audioOutput = AudioPlayableOutput.Create(_playableGraph, CN_AUDIO_OUTPUT_NAME, audioSource);
        //CreateSingleAnim();
        //CreateMixAnim();
        //CreateControllerMixAnim();
        //CreateAudioAnimMixer();
        //PauseAnimMixer();
    }

    #region 接口封装
    public void PlayAnimClip(PlayableGraph playableGraph, Animator animator, AnimationClip animClip, string outputName = "AnimOutput")
    {
        // 创建一个Output节点，类型是Animation，名字是Animation，目标对象是物体上的Animator组件
        AnimationPlayableOutput playableOutput = AnimationPlayableOutput.Create(playableGraph, outputName, animator);
        // 创建一个动画剪辑Playable，将clip传入进去
        AnimationClipPlayable clipPlayable = AnimationClipPlayable.Create(playableGraph, animClip);
        // 将可播放项连接到输出
        playableOutput.SetSourcePlayable(clipPlayable);
        // 播放这个graph
        playableGraph.Play();
    }

    public void DestoryPlayable(PlayableGraph playableGraph)
    {
        playableGraph.Destroy();
    }
    #endregion

    //1. 播放单独的一个动画片段
    private void CreateSingleAnim()
    {
        // 创建一个PlayableGraph并给它命名
        //_playableGraph = PlayableGraph.Create(CN_PLAYABLE_GRAPH_NAME);
        // 创建一个Output节点，类型是Animation，名字是Animation，目标对象是物体上的Animator组件
        //AnimationPlayableOutput playableOutput = AnimationPlayableOutput.Create(_playableGraph, CN_PLAYABLE_OUTPUT_NAME, _animator);
        // 创建一个动画剪辑Playable，将clip传入进去
        AnimationClipPlayable clipPlayable = AnimationClipPlayable.Create(_playableGraph, _animClip1);
        // 将可播放项连接到输出
        _animclipOutput.SetSourcePlayable(clipPlayable);
        // 播放这个graph
        _playableGraph.Play();

        //播放动画  和上面一堆代码一样的效果
        //AnimationPlayableUtilities.PlayClip(_animator, _animClip, out _playableGraph);
    }

    //2. 多个动画同时播放，我们也可以用AnimationMixerPlayable实现Blend Tree来混合动画
    private void CreateMixAnim()
    {
        //_playableGraph = PlayableGraph.Create(CN_PLAYABLE_GRAPH_NAME);
        //_playableGraph.SetTimeUpdateMode(DirectorUpdateMode.GameTime);
        //AnimationPlayableOutput playableOutput = AnimationPlayableOutput.Create(_playableGraph, CN_PLAYABLE_OUTPUT_NAME, _animator);
        //传入动画节点数量
        _mixerPlayable = AnimationMixerPlayable.Create(_playableGraph, 2);
        _animclipOutput.SetSourcePlayable(_mixerPlayable);
        //创建AnimationClipPlayable并且连接到混合器
        AnimationClipPlayable clipPlayable1 = AnimationClipPlayable.Create(_playableGraph, _animClip1);
        AnimationClipPlayable clipPlayable2 = AnimationClipPlayable.Create(_playableGraph, _animClip2);
        //连接Playable节点，第一个节点的第0个输出接口连接到mixerPlayable的第0个接口
        _playableGraph.Connect(clipPlayable1, 0, _mixerPlayable, 0);
        _playableGraph.Connect(clipPlayable2, 0, _mixerPlayable, 1);
        //播放图
        _playableGraph.Play();

        //动画状态机的切换
        //RuntimeAnimatorController animatorController = _animator.runtimeAnimatorController;
        //var animatorPlayable = AnimatorControllerPlayable.Create(_playableGraph, animatorController);
        //_playableGraph.Connect(animatorPlayable, 0, _mixerPlayable, 1);
    }

    //3. 创建AnimatiorController的混合器
    private void CreateControllerMixAnim()
    {
        _mixerPlayable = AnimationMixerPlayable.Create(_playableGraph, 2);
        _animclipOutput.SetSourcePlayable(_mixerPlayable);
        //创建Clip和Controller并且连接到混合器进行播放
        AnimationClipPlayable clipPlayable1 = AnimationClipPlayable.Create(_playableGraph, _animClip1);
        AnimatorControllerPlayable controllerPlayable = AnimatorControllerPlayable.Create(_playableGraph, _controller);
        _playableGraph.Connect(clipPlayable1, 0, _mixerPlayable, 0);
        _playableGraph.Connect(controllerPlayable, 0, _mixerPlayable, 1);
        _playableGraph.Play();
    }

    //4. 混合音频和动作
    private void CreateAudioAnimMixer()
    {
        //创建可播放项
        var clipPlayable = AnimationClipPlayable.Create(_playableGraph, _animClip1);
        var audioPlayable = AudioClipPlayable.Create(_playableGraph, _audioClip, true);
        //将可播放项连接到输出
        _animclipOutput.SetSourcePlayable(clipPlayable);
        _audioOutput.SetSourcePlayable(audioPlayable);
        //播放图
        _playableGraph.Play();
    }

    private void PauseAnimMixer() 
    {
        _mixerPlayable = AnimationMixerPlayable.Create(_playableGraph, 2);
        _animclipOutput.SetSourcePlayable(_mixerPlayable);
        //创建和连接动作片
        AnimationClipPlayable clipPlayable1 = AnimationClipPlayable.Create(_playableGraph, _animClip1);
        AnimationClipPlayable clipPlayable2 = AnimationClipPlayable.Create(_playableGraph, _animClip2);
        _playableGraph.Connect(clipPlayable1, 0, _mixerPlayable, 0);
        _playableGraph.Connect(clipPlayable2, 0, _mixerPlayable, 1);
        //设置权重
        _mixerPlayable.SetInputWeight(0, 1.0f);
        _mixerPlayable.SetInputWeight(1, 1.0f);
        //暂停第二个动作,不参与混合了
        clipPlayable2.Pause();
        //控制时间，设置某个动画片段播放的第几秒
        clipPlayable2.SetTime(0.8f);
        //播放
        _playableGraph.Play();
    }

    private void Update()
    {
        ////设置融合的时间点，比如前面的动画占比多少
        //_weight = Mathf.Clamp01(_weight);
        //_mixerPlayable.SetInputWeight(0, 1.0f - _weight);
        //_mixerPlayable.SetInputWeight(1, _weight);
    }

    private void OnDisable()
    {
        // 销毁该图创建的可播放项和PlayableOutput
        _playableGraph.Destroy();
    }
}
