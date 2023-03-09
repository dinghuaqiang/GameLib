using UnityEngine;

namespace Assets.Test.BitOperationsTest
{
    /// <summary>
    /// 位运算测试
    /// 与（&）：只有两个位都是1，结果才是1；
    /// 或（|）：只要两个位有一个是1，结果就是1；
    /// 非（~）：如果位为0，结果是1，如果位为1，结果是0；
    /// 异或（^）：两个操作数的位中，相同则结果为0，不同则结果为1；
    /// <<（左移）：左移表示乘以2，左移多少位表示乘以2的几次幂；
    /// >>（右移）：移动多少位表示除以2的几次幂。
    /// &= ~ 是关闭的意思  |= 是打开的意思
    /// </summary>
    public class BitOperationsTest : MonoBehaviour
    {
        private void Awake()
        {
            //int a = 43, b = 21; //a = 1101 0101
            //int i = 5;
            //if ((1 << (i - 1)) & a)
            //    Debug.Log("yes");
            //Debug.Log("%d\n", a | (1 << (i - 1)));
            //Debug.Log("%d\n", a & (a - 1)); // 去掉最后一个1
            //Debug.Log("%d\n", a & (~(1 << 1))); // 第i个位置变
            //                                 //判断a的第i个位置是否为1 (1<<(i-1))&a
            //                                 //将a的第i个位置变成1  a|(1<<(i-1))
            //                                 //将a的最后一个1改为0 这里用的是补码的知识  a&(a-1)
            //                                 //将a的第i位变成0 a&(~(1<< i))
            //Debug.Log("%d", (1 << 1) & ~(1 << 1));//他是一元运算符，用于求整数的二进制反码，即分别将操作数各二进制位上的1变为0，0变为1。
        }

        public void TestAND()
        {
            Debug.Log("1&0" + (1 & 0));
        }

        public void TestOR()
        {
            Debug.Log("1|0" + (1 | 0));
        }
    }
}
