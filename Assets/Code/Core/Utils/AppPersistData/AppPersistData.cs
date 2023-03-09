using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// 应用的持续化信息
    /// 这通过一些特定的字符串来PlayerPrefs来获取数据
    /// 这里只读不写
    /// </summary>
    public class AppPersistData
    {
        private static string _appName;
        //应用名字
        public static string AppName
        {
            get
            {
                if (_appName == null)
                {
                    _appName = PlayerPrefs.GetString(AppPersistKeyDefine.CN_APP_NAME_KEY, "");
                }
                return _appName;
            }
            set
            {
                _appName = value;
                PlayerPrefs.SetString(AppPersistKeyDefine.CN_APP_NAME_KEY, value);
                PlayerPrefs.Save();
            }
        }

        private static string _appVersion;
        //应用版本
        public static string AppVersion
        {
            get
            {
                if (_appVersion == null)
                {
                    _appVersion = PlayerPrefs.GetString(AppPersistKeyDefine.CN_APP_VERSION_KEY, "");
                }
                return _appVersion;
            }
            set
            {
                _appVersion = value;
                PlayerPrefs.SetString(AppPersistKeyDefine.CN_APP_VERSION_KEY, value);
                PlayerPrefs.Save();
            }
        }

        private static string _resVersion;
        //资源版本
        public static string ResVersion
        {
            get
            {
                if (_resVersion == null)
                {
                    _resVersion = PlayerPrefs.GetString(AppPersistKeyDefine.CN_RES_VERSION_KEY, "");
                }
                return _resVersion;
            }
            set
            {
                _resVersion = value;
                PlayerPrefs.SetString(AppPersistKeyDefine.CN_RES_VERSION_KEY, value);
                PlayerPrefs.Save();
            }
        }

        private static string _userName;
        //玩家输入的用户名或者SDK的用户名ID
        public static string UserName
        {
            get
            {
                if (_userName == null)
                {
                    _userName = PlayerPrefs.GetString(AppPersistKeyDefine.CN_ACCOUNT_NAME_KEY, "");
                }
                return _userName;
            }
            set
            {
                _userName = value;
                PlayerPrefs.SetString(AppPersistKeyDefine.CN_ACCOUNT_NAME_KEY, value);
                PlayerPrefs.Save();
            }
        }

        private static string _gameUserID;
        //游戏内部的用户ID
        public static string GameUserID
        {
            get
            {
                if (_gameUserID == null)
                {
                    _gameUserID = PlayerPrefs.GetString(AppPersistKeyDefine.CN_LAST_USER_ID_KEY, "");
                }
                return _gameUserID;
            }
            set
            {
                _gameUserID = value;
                PlayerPrefs.SetString(AppPersistKeyDefine.CN_LAST_USER_ID_KEY, value);
                PlayerPrefs.Save();
            }
        }

        private static string _lastRoleID;
        //最后一次登陆的角色ID
        public static string LastRoleID
        {
            get
            {
                if (_lastRoleID == null)
                {
                    _lastRoleID = PlayerPrefs.GetString(AppPersistKeyDefine.CN_LAST_ROLE_ID_KEY, "");
                }
                return _lastRoleID;
            }
            set
            {
                _lastRoleID = value;
                PlayerPrefs.SetString(AppPersistKeyDefine.CN_LAST_ROLE_ID_KEY, value);
                PlayerPrefs.Save();
            }
        }

        private static string _lastRoleName;
        //最后一个的角色名字
        public static string LastRoleName
        {
            get
            {
                if (_lastRoleName == null)
                {
                    _lastRoleName = PlayerPrefs.GetString(AppPersistKeyDefine.CN_LAST_ROLE_NAME_KEY, "");
                }
                return _lastRoleName;
            }
            set
            {
                _lastRoleName = value;
                PlayerPrefs.SetString(AppPersistKeyDefine.CN_LAST_ROLE_NAME_KEY, value);
                PlayerPrefs.Save();
            }
        }

        private static string _lastServerID;
        //最后一次的服务器ID
        public static string LastServerID
        {
            get
            {
                if (_lastServerID == null)
                {
                    _lastServerID = PlayerPrefs.GetString(AppPersistKeyDefine.CN_LAST_GAME_SERVER_ID_KEY, "");
                }
                return _lastServerID;
            }
            set
            {
                _lastServerID = value;
                PlayerPrefs.SetString(AppPersistKeyDefine.CN_LAST_GAME_SERVER_ID_KEY, value);
                PlayerPrefs.Save();
            }
        }


        //最后一次的服务器名字
        private static string _lastServerName;
        public static string LastServerName
        {
            get
            {
                if (_lastServerName == null)
                {
                    _lastServerName = PlayerPrefs.GetString(AppPersistKeyDefine.CN_LAST_GAME_SERVER_NAME_KEY, "");
                }
                return _lastServerName;
            }
            set
            {
                _lastServerName = value;
                PlayerPrefs.SetString(AppPersistKeyDefine.CN_LAST_GAME_SERVER_NAME_KEY, value);
                PlayerPrefs.Save();
            }
        }


        private static int _lastCacheResBaseCode = -1;
        //最后缓存资源的基础码
        public static int LastCacheResBaseCode
        {
            get
            {
                if (_lastCacheResBaseCode < 0)
                {
                    _lastCacheResBaseCode = PlayerPrefs.GetInt(AppPersistKeyDefine.CN_LAST_CACHE_RES_BASE_CODE, 1000);
                }
                return _lastCacheResBaseCode;
            }
            set
            {
                _lastCacheResBaseCode = value;
                PlayerPrefs.SetInt(AppPersistKeyDefine.CN_LAST_CACHE_RES_BASE_CODE, value);
                PlayerPrefs.Save();
            }
        }

        private static string _useLanguage;
        //当前使用的语言
        public static string UseLanguage
        {
            get
            {
                if (_useLanguage == null)
                {
                    _useLanguage = PlayerPrefs.GetString(AppPersistKeyDefine.CN_USE_LANGUAGE_KEY, "");
                }
                return _useLanguage;
            }
            set
            {
                _useLanguage = value;
                PlayerPrefs.SetString(AppPersistKeyDefine.CN_USE_LANGUAGE_KEY, value);
                PlayerPrefs.Save();
            }
        }

        private static int _isShowLoadingBar = -1;
        //当前是否显示Loading条
        public static bool IsShowLoadingBar
        {
            get
            {
                if (_isShowLoadingBar < 0)
                {
                    _isShowLoadingBar = PlayerPrefs.GetInt(AppPersistKeyDefine.CN_IS_SHOW_LOADING_BAR_KEY, 0);
                }
                return _isShowLoadingBar > 0;
            }
            set
            {

                _isShowLoadingBar = value ? 1 : 0;
                Debug.LogError("AppPersistData:Set:" + value + "::" + _isShowLoadingBar);
                PlayerPrefs.SetInt(AppPersistKeyDefine.CN_IS_SHOW_LOADING_BAR_KEY, _isShowLoadingBar);
                PlayerPrefs.Save();
            }
        }
        //尝试退出返回值
        public static bool WantExitResult = true;
    }
}
