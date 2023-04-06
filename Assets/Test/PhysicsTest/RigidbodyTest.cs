using UnityEngine;

public class RigidbodyTest : MonoBehaviour
{
    [Header("推力系数")]
    public float ForceThreshold = 10f;
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
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        //if (h != 0 || v != 0)
        //{
        //    float up = Vector3.Magnitude(new Vector3(h, 0, v));
        //    if (up > 0.1)
        //    {
        //        //刚体的速度向量
        //        //_rigidbody.velocity = new Vector3(h, up, v);
        //        //添加推力
        //        //_rigidbody.AddForce(new Vector3(h, 0, v) * ForceThreshold);
        //    }
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //添加爆炸力,爆炸力度，爆炸点，范围
            _rigidbody.AddExplosionForce(300, new Vector3(0, 0.5f, 0), 10);
        }
    }
}
