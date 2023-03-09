using System.Collections;
using UnityEngine;

public class DotCrossTest : MonoBehaviour
{
    public Transform cubeA;//玩家AI
    public Transform cubeB;//敌人

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TestCube(cubeA, cubeB);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawRay(cubeA.position * -10, cubeA.forward * 20);
    }

    void TestCube(Transform a, Transform b)
    {
        Vector3 enermyVec = b.position - a.position;
        Vector3 forwardVec = a.forward;

        float res = Vector3.Dot(enermyVec, forwardVec);
        Debug.Log("点积" + res);
        if (res > 0)
        {
            Debug.Log("敌人在我的前边");
        }
        else if (res == 0)
        {
            Debug.Log("两物体垂直");
        }
        else
        {
            Debug.Log("敌人在我的后边");
        }
        Vector3 cross = Vector3.Cross(forwardVec, enermyVec);
        bool isleft = false;
        if (cross.y >= 0)
        {
            Debug.Log("敌人在我的右边");
            isleft = false;
        }
        else if (cross.y < 0)
        {
            Debug.Log("敌人在我的左边");
            isleft = true;
        }
        //计算玩家AI向敌人转向的角度
        float angle = Vector3.Angle(forwardVec, enermyVec);
        StartCoroutine(ContinueRoate(angle, cubeA, isleft));
    }

    //自动转向
    IEnumerator ContinueRoate(float angle, Transform roateObj, bool isLeft)
    {

        bool isCom = false;
        while (!isCom)
        {
            Vector3 quaternion = roateObj.rotation.eulerAngles;
            if (isLeft)
            {
                float y = quaternion.y - 0.1f;
                roateObj.rotation = Quaternion.Euler(new Vector3(quaternion.x, y, quaternion.z));
            }
            else
            {
                float y = quaternion.y + 0.1f;
                roateObj.rotation = Quaternion.Euler(new Vector3(quaternion.x, y, quaternion.z));
            }

            angle -= 0.1f;
            if (angle - 0.1f <= 0)
            {
                isCom = true;
            }
            yield return null;
        }
    }
}

