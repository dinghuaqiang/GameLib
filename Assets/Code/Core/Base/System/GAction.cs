using System.Collections;

namespace GameLib.Core.Base
{
    /// <summary>
    /// 可以通过协程处理的委托---用于替换Action
    /// </summary>
    public delegate IEnumerator ActionEnumerator();
    public delegate void GAction();
    public delegate void GAction<T>(T arg1);
    public delegate void GAction<T1, T2>(T1 arg1, T2 arg2);
    public delegate void GAction<T1, T2, T3>(T1 arg1, T2 arg2, T3 arg3);
    public delegate void GAction<T1, T2, T3, T4>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    public delegate void GAction<T1, T2, T3, T4, T5>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    public delegate void GAction<T1, T2, T3, T4, T5, T6>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
    public delegate void GAction<T1, T2, T3, T4, T5, T6, T7>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
    public delegate void GAction<T1, T2, T3, T4, T5, T6, T7, T8>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8);
}
