using Code.Logic.Start;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    #region//启动参数
    //语言
    private static string _paramLang = null;
    //平台
    private static int _paramPlatform = -1;
    //是否使用Bundle
    private static bool _paramUseBundle = false;
    //当前调用跳转登录界面
    private static bool _paramChangeToLogin = false;
    #endregion
    private static GameCenterScript _centerScript;
    void Start()
    {
        CreateGameCenterGo();
    }

    void Update()
    {
        
    }

    /// <summary>
    /// 启动函数
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
        ResetParams();
        if (args != null && args.Length > 0)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (0 == string.Compare(args[i], "-lang", true))
                {//语言
                    if (i < args.Length - 1)
                    {
                        string arg = args[i + 1];
                        if (!arg.StartsWith("-"))
                        {

                            if (0 == string.Compare(arg, "false", true))
                            {
                                _paramLang = null;
                            }
                            else
                            {
                                _paramLang = arg;
                            }
                            ++i;
                        }
                    }
                }
                else if (0 == string.Compare(args[i], "-platform", true))
                {//平台
                    if (i < args.Length - 1)
                    {
                        string arg = args[i + 1];
                        if (!arg.StartsWith("-"))
                        {
                            if (!int.TryParse(arg, out _paramPlatform))
                            {
                                _paramPlatform = -1;
                            }
                            ++i;
                        }
                    }
                }
                else if (0 == string.Compare(args[i], "-usebundle", true))
                {//是否使用bundle
                    _paramUseBundle = true;
                }
                else if (0 == string.Compare(args[i], "-tologin", true))
                {//是否跳转
                    _paramChangeToLogin = true;
                }
            }
        }
        CreateGameCenterGo();
    }

    //清理启动参数
    private static void ResetParams()
    {
        _paramLang = null;
        _paramPlatform = -1;
        _paramUseBundle = false;
        _paramChangeToLogin = false;
    }

    //创建游戏中心的对象
    private static void CreateGameCenterGo()
    {

        GameObject go = GameObject.Find("[MainEntry]");
        if (go == null)
        {
            //UnityEngine.Debug.Log("CreateGameCenterGo++++++++++++++");
            go = new GameObject("[MainEntry]");
            go.SetActive(false);
            //go.AddComponent<GameUICenterScript>();
            _centerScript = go.AddComponent<GameCenterScript>();
            GameObject.DontDestroyOnLoad(go);
        }
        else
        {
            UnityEngine.Debug.Log("ChangeToLogin");
            _centerScript = go.GetComponent<GameCenterScript>();
            _centerScript.ChangeToLogin();

        }
        _centerScript.GameStart(_paramLang, _paramUseBundle, _paramPlatform);
        go.SetActive(true);
    }
}
