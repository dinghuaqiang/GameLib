using UnityEngine;

namespace Assets.Test.PlayerMove
{
    /// <summary>
    /// 角色移动的测试脚本
    /// </summary>
    public class TestPlayerMove : MonoBehaviour
    {
        public CharacterController _characterController = null;
        [Header("移动速度")]
        public float MoveSpeed = 0.2f;
        [Header("转向速度")]
        public float RotationSpeed = 8f;
        //朝向
        private Vector3 _dir = Vector3.zero;

        private Animator _animator;
        private bool _isMoving = false;
        private delegate void MoveHandler(bool isMoving);
        private MoveHandler _onPlayerMoveCallback;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _onPlayerMoveCallback = OnPlayerMoving;
        }

        private void OnPlayerMoving(bool isMoving)
        {
            //切换Animator状态机的动画，设置Move的值播放跑步动画
            //Debug.Log("OnPlayerMoving : " + isMoving);
            _animator.SetBool("Move", isMoving);
        }

        void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (h != 0 || v != 0)
            {
                _dir = new Vector3(-h, 0, -v);
                Vector3 motion = MoveSpeed * _dir;
                _characterController.Move(motion);
                // 通过四元数的线性插值改变游戏物体的转向，当前方向，目标方向，旋转速度
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_dir), Time.deltaTime * RotationSpeed);
                if (!_isMoving)
                {
                    _isMoving = true;
                    _onPlayerMoveCallback?.Invoke(_isMoving);
                }
            }
            else
            {
                if (_isMoving)
                {
                    _isMoving = false;
                    _onPlayerMoveCallback?.Invoke(_isMoving);
                }
            }

            ////设置播放攻击动画
            //if (Input.GetMouseButton(0))
            //{
            //    _animator.SetTrigger("Attack");
            //}
        }
    }
}
