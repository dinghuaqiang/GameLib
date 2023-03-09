using UnityEngine;

namespace GameLib.Core.Base
{
    /// <summary>
    /// 应用程序的根节点
    /// </summary>
    public static class AppRoot
    {
        #region //常量
        //Root对象名字
        private const string CN_NAME = "[ProgramRoot]";
        #endregion

        #region//静态私有对象
        //Root对象
        private static GameObject _go = null;
        //Transform
        private static Transform _trans = null;
        private static bool _appIsRunning = true;
        #endregion

        #region//属性信息
        //GameObject
        public static GameObject GameObject
        {
            get
            {
                return _go;
            }
        }

        //Transform
        public static Transform Transform
        {
            get
            {
                return _trans;
            }
        }

        /// <summary>
        /// 游戏正在运行 --- 这个主要适用于在编辑器状态,在调用Application.Quit之后,还有一些设置Transform.parent的操作,会出现各种错误日志.
        /// </summary>
        public static bool AppIsRunning { get { return _appIsRunning; } set { _appIsRunning = value; } }
        #endregion

        #region//静态构造函数
        //静态构造函数
        static AppRoot()
        {
            _go = new GameObject(CN_NAME);
            _trans = _go.transform;
            GameObject.DontDestroyOnLoad(_go);
        }
        #endregion
    }
}
