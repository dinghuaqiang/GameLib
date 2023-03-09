using System.Collections.Generic;

namespace Code.Logic.MapLogic
{
    public abstract class CopyLogicBase
    {
        private Dictionary<string, bool> _mainUIStatusDict = new Dictionary<string, bool>();

        //进入场景
        public abstract void OnEnterScene(object data);
        //离开场景
        public abstract void OnLeaveScene(object data);
        //处理帧更新，时间计算等
        public abstract void Update(float deltaTime);
        //处理服务器协议
        public abstract void OnMsgHandle(object copyMsg);

        /// <summary>
        /// 提供给外部设置UI状态
        /// </summary>
        /// <param name="updateStatus"></param>
        protected void SetMainUIStatus(Dictionary<string, bool> updateStatus)
        {
            if (updateStatus != null && _mainUIStatusDict != null)
            {
                var updateIter = updateStatus.GetEnumerator();
                try
                {
                    while (updateIter.MoveNext())
                    {
                        if (_mainUIStatusDict.ContainsKey(updateIter.Current.Key))
                        {
                            _mainUIStatusDict[updateIter.Current.Key] = updateIter.Current.Value;
                        }
                    }
                }
                finally
                {
                    updateIter.Dispose();
                }
            }
        }

        /// <summary>
        /// 获取每个副本需要设置的主界面某些面板是否显示的状态
        /// MainForm.PlayerHead, false
        /// MainForm.TaskPanel, true
        /// MainForm.PlayerBag, true
        /// </summary>
        protected virtual Dictionary<string, bool> GetMainUIStatus() { return _mainUIStatusDict; }
    }
}
