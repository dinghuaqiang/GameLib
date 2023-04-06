using UnityEngine;

namespace Assets.Test.PlayerMove
{
    public class TestRigidbodyMove : MonoBehaviour
    {
        [Header("移动速度")]
        public float MoveSpeed = 0.2f;
        [Header("转向速度")]
        public float RotationSpeed = 8f;
        //朝向
        private Vector3 _dir = Vector3.zero;
        private Rigidbody _rigidbody = null;

        private void Start()
        {
            _rigidbody = transform.GetComponent<Rigidbody>();
            if (_rigidbody == null)
            {
                _rigidbody = gameObject.AddComponent<Rigidbody>();
            }
        }

        void Update()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (h != 0 || v != 0)
            {
                _dir = new Vector3(-h, 0, -v);
                Vector3 motion = MoveSpeed * _dir;
                ////1. 插值移动和转向
                //transform.position = Vector3.Lerp(transform.position, transform.position + motion, Time.deltaTime * RotationSpeed);
                //// 通过四元数的线性插值改变游戏物体的转向，当前方向，目标方向，旋转速度
                //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_dir), Time.deltaTime * RotationSpeed);

                //2. 使用刚体进行移动和旋转
                _rigidbody.MovePosition(transform.position + motion);
                _rigidbody.MoveRotation(Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_dir), Time.deltaTime * RotationSpeed));

                //_rigidbody.AddForce(motion);
                //_rigidbody.velocity = motion;
                //_rigidbody.angularVelocity = _dir;
                //_rigidbody.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_dir), Time.deltaTime * RotationSpeed);

                //Physics.RaycastNonAlloc();
            }
        }

        /** 碰撞器的回调和触发器的回调条件：
         OnCollisionEnter方法被触发要符合以下条件:
             1. 碰撞双方必须是碰撞体 
             2. 碰撞的主动方必须是刚体，注意是主动方，而不是被动方 
             3. 刚体不能勾选IsKinematic 
             4. 碰撞体不能够勾选IsTigger
         OnCollisionEnter方法的形参对象指的是碰撞双方中没有携带OnCollisionEnter方法的一方
         
         OnTriggerEnter触发条件：
             1. 碰撞双方都必须是碰撞体 
             2. 碰撞双方其中一个碰撞体必须勾选IsTigger选项 
             3. 碰撞双方其中一个必须是刚体 
             4. 刚体的IsKinematic选项可以勾选也可以不勾选 
        */

        #region 碰撞的回调 Collision
        private void OnCollisionEnter(Collision collision)
        {

        }

        private void OnCollisionStay(Collision collision)
        {

        }

        private void OnCollisionExit(Collision collision)
        {

        }
        #endregion

        #region 触发器的回调 Trigger
        private void OnTriggerEnter(Collider other)
        {

        }

        private void OnTriggerStay(Collider other)
        {

        }

        private void OnTriggerExit(Collider other)
        {

        }
        #endregion
    }
}