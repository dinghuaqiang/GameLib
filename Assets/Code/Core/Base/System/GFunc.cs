namespace GameLib.Core.Base
{
    /// <summary>
    /// 带有参数的委托 ---用于替换Func
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public delegate TResult GFunc<TResult>();
    public delegate TResult GFunc<T, TResult>(T arg);
    public delegate TResult GFunc<T1, T2, TResult>(T1 arg1, T2 arg2);
    public delegate TResult GFunc<T1, T2, T3, TResult>(T1 arg1, T2 arg2, T3 arg3);
    public delegate TResult GFunc<T1, T2, T3, T4, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4);
    public delegate TResult GFunc<T1, T2, T3, T4, T5, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5);
    public delegate TResult GFunc<T1, T2, T3, T4, T5, T6, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6);
    public delegate TResult GFunc<T1, T2, T3, T4, T5, T6, T7, TResult>(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7);
}
