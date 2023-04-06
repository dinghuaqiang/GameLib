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
            }
        }
    }
}
