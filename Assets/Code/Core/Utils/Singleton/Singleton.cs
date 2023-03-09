namespace Code.Core.Utils
{
    /// <summary>
    /// 单例类的实现
    /// new()代表这个泛型类CLASS 必须有一个无参的构造函数
    /// </summary>
    /// <typeparam name="CLASS">泛型类</typeparam>
    public abstract class Singleton<CLASS> where CLASS : Singleton<CLASS>, new()
    {
        private static CLASS _classInstance;
        public static CLASS Instance 
        {
            get 
            {
                if (_classInstance == null)
                {
                    _classInstance = new CLASS();
                    _classInstance.OnInitialize();
                }
                return _classInstance;
            }
        }

        public void Destroy()
        {
            if (_classInstance != null)
            {
                _classInstance.OnUnInitialize();
                _classInstance = null;
            }
        }

        public virtual void OnInitialize() { }
        public virtual void OnUnInitialize() { }
    }
}
