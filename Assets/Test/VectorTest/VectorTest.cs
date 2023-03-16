using UnityEngine;

namespace Assets.Test.VectorTest
{
    public class VectorTest : MonoBehaviour
    {
        Vector3 posA = new Vector3(1, 2, 3);
        Vector3 posB = new Vector3(4, 5, 6);

        public Transform _palyer;
        public Transform _npc;

        private void Awake()
        {
            // 1. 向量加法   A + B = ((Ax+Bx),(Ay+By),(Az+Bz));
            // 作用：描述物体的位移。
            Vector3 addByFormula = new Vector3(posA.x + posB.x, posA.y + posB.y, posA.z + posB.z);
            Vector3 add = posA + posB;
            Debug.Log(string.Format("公式推导的加法结果:{0},Unity Api的加法结果:{1}", addByFormula, add));

            // 2. 向量减法   A - B = ((Ax-Bx),(Ay-By),(Az-Bz));
            // 作用：描述物体的位移。
            Vector3 subByFormula = new Vector3(posA.x - posB.x, posA.y - posB.y, posA.z - posB.z);
            Vector3 sub = posA - posB;
            Debug.Log(string.Format("公式推导的减法结果:{0},Unity Api的减法结果:{1}", subByFormula, sub));

            // 3. 向量的模   sqrt((posA.x)²,(posA.y)², (posA.z)²)
            // 作用：相当于向量的长度，求距离等。
            float posAMagnitude = Mathf.Sqrt(Mathf.Pow(posA.x, 2) + Mathf.Pow(posA.y, 2) + Mathf.Pow(posA.z, 2));
            float length = posA.magnitude;
            Debug.Log(string.Format("公式推导的模:{0},Unity Api的模:{1}", posAMagnitude, length));

            // 4. 向量归一化  向量/向量的模  V/sqrt((posA.x)²,(posA.y)², (posA.z)²)
            // 作用：主要用作求方向。
            // 之前理解了很久没有理解到这个，其实可以这样想，相当于把向量等比例缩短到值为1的长度上来，不关心向量的长度，只关注它的方向。
            float posaMagnitude = Mathf.Sqrt(Mathf.Pow(posA.x, 2) + Mathf.Pow(posA.y, 2) + Mathf.Pow(posA.z, 2));
            Vector3 normalizedByFormula = posA / posaMagnitude;
            Vector3 normalized = posA.normalized;
            Debug.Log(string.Format("公式推导的归一化结果:{0},Unity Api的归一化结果:{1}", normalizedByFormula, normalized));

            // 5. 向量的点积  公式一：A*B = (Ax,Ay,Az)*(Bx,By,Bz) = (Ax*Bx + Ay*By + Az*Bz)  公式二：|A||B|cosθ
            // 作用:求投影，求角度。参考UnityShader入门精要数学篇
            // 这里只实验第二种用法
            // 先计算出NPC相对自身的位置信息
            Vector3 relativePos = _npc.position - _palyer.position;
            // 再获取自身正方向
            Vector3 dir = _palyer.forward;
            // 如果大于0说明敌人在自身前面 夹角＜90°
            // 如果小于0说明敌人在自身后面 夹角> 90°
            // 如果等于0说明敌人在自身左右 夹角= 90°
            float dotResult = Vector3.Dot(relativePos, dir);
            if (dotResult > 0f)
            {
                Debug.Log("前面");
            }
            else
            {
                Debug.Log("后面");
            }
            // 得到两个向量后，可以直接计算其夹角
            float angle = Vector3.Angle(relativePos, dir);
            // 当两个向量的长度都为1时，点乘的结果就是夹角的余弦值
            float cos = Vector3.Dot(relativePos.normalized, dir.normalized);
            Debug.Log(string.Format("点积的结果:{0}, 两个向量的夹角:{1}, 余弦值Cosθ：{2}", dotResult, angle, cos));

            // 6. 向量的叉积
            // 作用:判断朝向。
            Vector3 crossResult = Vector3.Cross(relativePos, dir);
            if (crossResult.y > 0)
            {
                Debug.Log("左边");
            }
            else
            {
                Debug.Log("右边");
            }

            /**
             *  逻辑开发中:
                点乘可以判断出目标物体在我的前方还是后方。大于零在前方，小于零在后方。
                叉乘可以判断出目标物体在我的左边还是右边。大于零在右方，小于零在左方。
                图形学中：
                点乘可以用来计算夹角余弦值。
                叉乘可以用来计算平面法向量。
             */
        }
    }
}
