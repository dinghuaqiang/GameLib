using System;

namespace Code.Core.AI.BehaviorTree.Task
{
    public class ActionTask : Task
    {
        #region 枚举
        public enum Result
        {
            //成功
            SUCCESS,
            //失败
            FAILED,
            //行为还没有准备好
            BLOCKED,
            //忙着这个行为的时候
            PROGRESS,
        }

        public enum Request
        {
            //准备数据，表示它是您的操作或返回结果的第一个标记或者是Result.BLOCKED最后一个标记
            START,
            //更新数据，表示您最后一次返回Request.PROGRESS
            UPDATE,
            //关闭任务，意味着需要取消操作并返回结果。`Result.SUCCESS`或`Result.FAILED`
            CANCEL,
        }
        #endregion

        #region 变量
        private const string NAME = "ActionTask";
        //立即执行的回调
        private Action _action = null;
        //单帧执行的回调
        private Func<bool> _singleFrameFunc = null;
        //多帧执行的回调,执行结果返回（成功，失败）
        private Func<bool, Result> _multiFrameFunc = null;
        //多帧执行的回调,执行结果能返回个状态信息【准备，更新，结束】
        private Func<Request, Result> _multiFrameFuncReq = null;
        private bool _isBlocked = false;
        #endregion

        #region 构造函数
        /// <summary>
        /// 总是立即成功完成任务
        /// </summary>
        public ActionTask(Action action) : base(NAME)
        {
            _action = action;
        }

        /// <summary>
        /// 可以成功或失败的操作(返回true or false)
        /// </summary>
        public ActionTask(Func<bool> singleFunc) : base(NAME)
        {
            _singleFrameFunc = singleFunc;
        }

        /// <summary>
        /// 可以在多个帧上执行的操作
        /// </summary>
        public ActionTask(Func<bool, Result> multiFrameFunc) : base(NAME)
        {
            _multiFrameFunc = multiFrameFunc;
        }

        /// <summary>
        /// 可以在多个帧上执行的操作,但是Request会给你一个状态信息
        /// 当考虑使用这种类型的Action时，应该考虑创建一个自定义的`Task`子类来代替。
        /// </summary>
        public ActionTask(Func<Request, Result> multiFrameFuncReq) : base(NAME)
        {
            _multiFrameFuncReq = multiFrameFuncReq;
        }
        #endregion

        #region 计时轮训回调检测
        private void OnUpdateFunc()
        {
            if (_multiFrameFunc != null)
            {
                Result result = _multiFrameFunc(false);
                if (result != Result.PROGRESS && result != Result.BLOCKED)
                {
                    RootNode.Clock.RemoveUpdateObserver(OnUpdateFunc);
                    Stopped(result == Result.SUCCESS);
                }
            }
        }

        private void OnUpdateFuncReq()
        {
            if (_multiFrameFuncReq != null)
            {
                Result result = _multiFrameFuncReq(_isBlocked ? Request.START : Request.UPDATE);
                switch (result)
                {
                    case Result.BLOCKED:
                        _isBlocked = true;
                        break;
                    case Result.PROGRESS:
                        _isBlocked = false;
                        break;
                    default:
                        RootNode.Clock.RemoveUpdateObserver(OnUpdateFuncReq);
                        Stopped(result == Result.SUCCESS);
                        break;
                }
            }
        }
        #endregion

        #region 开始结束的处理
        protected override void DoStart()
        {
            if (_action != null)
            {
                _action();
                Stopped(true);
            }
            else if (_multiFrameFunc != null)
            {
                Result result = _multiFrameFunc(false);
                switch (result)
                {
                    case Result.SUCCESS:
                        Stopped(true);
                        break;
                    case Result.BLOCKED:
                        _isBlocked = true;
                        RootNode.Clock.AddUpdateObserver(OnUpdateFunc);
                        break;
                    case Result.PROGRESS:
                        RootNode.Clock.AddUpdateObserver(OnUpdateFunc);
                        break;
                    default:
                        Stopped(false);
                        break;
                }
            }
            else if (_multiFrameFuncReq != null)
            {
                Result result = _multiFrameFuncReq(Request.START);
                switch (result)
                {
                    case Result.SUCCESS:
                        Stopped(true);
                        break;
                    case Result.BLOCKED:
                        _isBlocked = true;
                        RootNode.Clock.AddUpdateObserver(OnUpdateFunc);
                        break;
                    case Result.PROGRESS:
                        RootNode.Clock.AddUpdateObserver(OnUpdateFunc);
                        break;
                    default:
                        Stopped(false);
                        break;
                }
            }
            else if (_singleFrameFunc != null)
            {
                Stopped(_singleFrameFunc());
            }
        }

        protected override void DoStop()
        {
            if (_multiFrameFunc != null)
            {
                Result result = _multiFrameFunc(true);
                if (result != Result.PROGRESS)
                {
                    RootNode.Clock.RemoveUpdateObserver(OnUpdateFunc);
                    Stopped(result == Result.SUCCESS);
                }
            }
            else if (_multiFrameFuncReq != null)
            {
                Result result = _multiFrameFuncReq(Request.CANCEL);
                if (result != Result.PROGRESS)
                {
                    RootNode.Clock.RemoveUpdateObserver(OnUpdateFuncReq);
                    Stopped(result == Result.SUCCESS);
                }
            }
        }
        #endregion
    }
}
