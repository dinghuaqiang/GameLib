using UnityEngine;

public class MoveTest : MonoBehaviour
{
    //移动的目标
    private Transform _targetTrans = null;
    //移动的速度
    private float _moveSpeed = 0.1f;
    //移动到的目标位置
    private Vector3 _endPos = new Vector3(9, 0, 0);
    //是否移动结束
    private bool _isMoveEnd = false;
    private Vector3 _curSpeed;
    private CharacterController _ccCtrl = null;
    private Vector3 _updateMove = new Vector3(0.1f, 0, 0);
    //定义个结束的回调
    private delegate void MoveFinishedCallBack();
    private event MoveFinishedCallBack MoveFinishedEvent;

    void Start()
    {
        //查找出要移动的目标物体
        _targetTrans = transform.Find("Sphere");
        if (_targetTrans != null)
        {
            _ccCtrl = _targetTrans.GetComponent<CharacterController>();
            if (_ccCtrl == null)
            {
                _ccCtrl = _targetTrans.gameObject.AddComponent<CharacterController>();
            }
        }
        MoveFinishedEvent += OnMoveFinished;
    }

    void Update()
    {
        if (_targetTrans != null)
        {
            //1. 使用Translate进行移动
            //使用向量的长度来确定是否移动完成
            //if (_endPos.magnitude >= _targetTrans.position.magnitude && !_isMoveEnd)
            //{
            //    //沿X轴正向进行移动
            //    _targetTrans.Translate(Vector3.right * _moveSpeed);
            //}

            //2. 使用Lerp插值进行移动 [就是在两个位置之前，每次增加剩余距离的百分比]
            //  2.1 先快后慢的运动，因为每次插值之后，剩余的距离在变小
            //_targetTrans.position = Vector3.Lerp(_targetTrans.position, _endPos, 0.05f);
            //  2.2 匀速的移动  用移动的距离差来和时间相乘
            //float distance = 1 / ((_targetTrans.position - _endPos).magnitude);
            //_targetTrans.position = Vector3.Lerp(_targetTrans.position, _endPos, distance * 0.05f);

            //3. SmoothDamp平滑移动 [当前位置，目标位置，移动速度，移动时长]  有点类似于插值，但是是比较平滑的移动
            //_targetTrans.position = Vector3.SmoothDamp(_targetTrans.position, _endPos, ref _curSpeed, 1.0f);

            //4. 使用CharacterController进行移动 【参数就是每帧移动的距离】
            //_ccCtrl.Move(Vector3.right * 2 * Time.deltaTime);

            //5. 直接按每帧进行移动固定的位置
            if (_endPos.magnitude >= _targetTrans.position.magnitude && !_isMoveEnd)
            {
                _targetTrans.position += _updateMove;
            }

            //移动结束的判断
            if (!_isMoveEnd && _targetTrans.position.magnitude >= _endPos.magnitude)
            {
                _isMoveEnd = true;
                if (MoveFinishedEvent != null)
                {
                    MoveFinishedEvent();
                }
            }
        }
    }

    private void OnMoveFinished() 
    {
        Debug.Log("移动完成了，隐藏移动节点!");
        _targetTrans.gameObject.SetActive(false);
    }
}
