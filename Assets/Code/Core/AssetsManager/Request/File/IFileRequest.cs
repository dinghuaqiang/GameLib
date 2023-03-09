using System;
using System.Collections;
using UnityEngine;

namespace GameLib.Core.Asset
{
    /// <summary>
    /// 资源集请求接口
    /// </summary>
    public interface IFileRequest : IDisposable, IEnumerator, IEnumerable
    {
        //进度
        float Progress { get; }
        //是否完成
        bool IsDone { get; }
        //是否错误
        string Error { get; }
        //Bundle
        AssetBundle Bundle { get; }
        //获取资源对象请求
        IAssetRequest GetAssetRequest(string requestName,Type assetType);
    }
}
