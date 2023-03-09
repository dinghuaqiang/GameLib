using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTest : MonoBehaviour
{
    private Transform _targetTrans = null;
    private Transform _targetTrans1 = null;
    float _speed = 0;
    float _newAngle = 0;

    void Start()
    {
        _targetTrans = transform.Find("Cube");
        _targetTrans1 = transform.Find("Target");
    }
    
    void Update()
    {
        //1. 使用欧拉角让物体分别沿着X Y Z轴进行旋转
        //_targetTrans.rotation *= Quaternion.Euler(1,0,0);
        //_targetTrans.rotation *= Quaternion.Euler(0,1,0);
        //_targetTrans.rotation *= Quaternion.Euler(0,0,1);
        // 1.1 死锁问题。将欧拉角存储在一个类变量中，并仅使用该变量作为欧拉角进行应用，但从不依赖于读回欧拉值。若从四元数读取、修改并写入欧拉值会造成万向死锁。
        //var angles = _targetTrans.rotation.eulerAngles;
        //angles.x += Time.deltaTime * 100;
        //_targetTrans.rotation = Quaternion.Euler(angles);
        // 1.2 处理方式
        //_newAngle += Time.deltaTime * 100;
        //_targetTrans.rotation = Quaternion.Euler(_newAngle, 0, 0);
        //2. Rotate函数旋转。每帧旋转的角度和绕的轴；第二个参数：参考坐标系。
        //_targetTrans.Rotate(new Vector3(1, 0, 0), Space.Self);
        //3. RotateAround旋转 第一个参数：物体围绕旋转的位置；第二个参数：旋转绕的轴；第三个参数：角度
        //_targetTrans.RotateAround(_targetTrans.position, _targetTrans.up, Time.deltaTime * 10);
        //4. 给欧拉角赋值 eulerAngles
        //_speed += Time.deltaTime * 100;
        //5. LookAt 看向目标物体按照Y轴进行旋转，旋转到面对目标位置
        _targetTrans.LookAt(_targetTrans1.position, _targetTrans.up);
    }
}
