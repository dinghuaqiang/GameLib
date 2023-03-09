using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 添加宏的工具类
/// </summary>
public sealed class SymbolUtils
{
    private static SymbolUtils _instance;
    private static List<string> _savedSymbols;

    public static SymbolUtils Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SymbolUtils();
                InitSymbols();
            }
            return _instance;
        }
    }

    /// <summary>
    /// 先获取到所有的宏定义
    /// </summary>
    /// <returns></returns>
    private static List<string> InitSymbols()
    {
        if (_savedSymbols == null)
        {
            _savedSymbols = new List<string>();
        }
        string defineSymbols = PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup);
        string[] symbols = defineSymbols.Split(';');
        for (int i = 0; i < symbols.Length; i++)
        {
            if (!_savedSymbols.Contains(symbols[i]))
            {
                _savedSymbols.Add(symbols[i]);
            }
        }
        return _savedSymbols;
    }

    /// <summary>
    /// 提供给外部获取当前已存在的宏
    /// </summary>
    public string[] GetDefinedSymbols()
    {
        return _savedSymbols.ToArray();
    }

    /// <summary>
    /// 添加单个宏；此宏不能由分号结尾；
    /// </summary>
    /// <param name="define">宏定义</param>
    /// <returns>是否添加成功</returns>
    public bool AddSymbol(string define)
    {
        if (string.IsNullOrEmpty(define))
        {
            Debug.LogError("要添加的宏是空的!!");
            return false;
        }
        if (_savedSymbols.Contains(define))
        {
            Debug.LogError(string.Format("需要添加的宏:【{0}】已存在，重复添加!", define));
            return false;
        }
        _savedSymbols.Add(define);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, string.Join(";", _savedSymbols.ToArray()));
        return true;
    }

    /// <summary>
    /// 移除单个宏；此宏不能由分号结尾；
    /// </summary>
    /// <param name="define">宏定义</param>
    /// <returns>是否移除成功</returns>
    public bool RemoveSymbol(string define)
    {
        if (!_savedSymbols.Contains(define))
        {
            Debug.LogError(string.Format("需要删除的宏:【{0}】不存在!", define));
            return false;
        }
        _savedSymbols.Remove(define);
        PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, string.Join(";", _savedSymbols.ToArray()));
        return true;
    }
}
