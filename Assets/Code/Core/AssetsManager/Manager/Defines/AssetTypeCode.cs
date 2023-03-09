namespace GameLib.Core.Asset
{
    /// <summary>
    /// 资源类型
    /// </summary>
    public enum AssetTypeCode
    {
        None,        
        AnimationClip,  //动作片段
        Texture,        //纹理
        Material,       //材质
        Mesh,           //网格
        AudioClip,      //声音片段        
        Prefab,         //预制    
        Scene,          //场景关卡       
        PlayableAsset,  //Timeline 资源
        Video,          //视频资源
        Count,
    }
}
