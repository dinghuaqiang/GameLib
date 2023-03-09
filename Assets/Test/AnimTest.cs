using System.Collections.Generic;
using UnityEngine;

public class AnimTest : MonoBehaviour
{
    // Start is called before the first frame update
    private Animation anim = null;
    List<AnimationState> animations = null;
    private float _fontTime = 0;
    private float _curTime = 0;
    bool _isPlayFinished = false;
    float _delta = 1;
    AnimationState _curClipState = null;
    void Start()
    {
        anim = GetComponent<Animation>();
        var iter = anim.GetEnumerator();
        animations = new List<AnimationState>(anim.GetClipCount());
        while (iter.MoveNext())
        {
            animations.Add((AnimationState)iter.Current);
        }
        anim.clip.wrapMode = WrapMode.Loop;
    }

    // Update is called once per frame
    void Update()
    {
        _curTime += Time.deltaTime;
        if (animations != null)
        {
            if (animations.Count > 0)
            {
                if (_curClipState != null && _curClipState != animations[0])
                {
                    if (_curTime >= _fontTime)
                    {
                        _fontTime = 0;
                        _curTime = 0;
                        _curClipState = null;
                    }
                    else
                    {
                        return;
                    }
                }
                if (_curClipState == null || _curClipState != animations[0])
                {
                    _curClipState = animations[0];
                    _fontTime = _curClipState.length;
                    Debug.LogError("当前时间:" + _curTime + "播放:" + _curClipState.name);
                    anim.Play(_curClipState.name);
                    animations.Remove(_curClipState);
                }
            }
            else
            {
                if (_fontTime >= _curTime)
                {
                    anim.Stop();
                    _isPlayFinished = true;
                }
            }
        }
        if (_isPlayFinished)
        {
            _delta = Mathf.Lerp(_delta, 0f, Time.deltaTime);
            transform.localScale = new Vector3(_delta, _delta, _delta);
        }
    }
}
