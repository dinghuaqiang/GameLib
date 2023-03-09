namespace GameLib.Core.Asset
{
    /// <summary>
    /// 文件的错误码 --- 同步Update的CodeDefine
    /// </summary>
    public enum AsstesRetCode
    {
        /// <summary>
        /// 无效请求，map中不存在这个文件 :RET_BACKDOWNLOAD_INVALIDFILE
        /// </summary>
        RET_INVALIDFILE = -3,

        /// <summary>
        /// 因暂停跳过  -- RET_BACKDOWNLOAD_SKIPBYPAUSE
        /// </summary>
        RET_SKIPBYPAUSE = -2,

        /// <summary>
        /// http下载失败，包括MD5校验失败 -- RET_BACKDOWNLOAD_HTTPFAIL
        /// </summary>
        RET_HTTPFAIL = -1,
        /// <summary>
        /// 后台更新，当个文件下载成功 RET_BACKDOWNLOAD_SUCCESS
        /// </summary>
        RET_OK = 0,
        /// <summary>
        /// 文件不存在
        /// </summary>
        RET_FILE_NOT_EXIST = 1,

        /// <summary>
        /// Bundle是无效的
        /// </summary>
        RET_BUNDLE_INVALID = 2,

        /// <summary>
        /// BundleRequest是无效的 --这里表明请求名字无效
        /// </summary>
        RET_BUNDLE_REQEST_INVALID = 3,

        //加载WWW的异常
        RET_LOADWWW_EXCEPTION = 4,

        //加载Bundle的异常
        RET_LOADBUNDLE_EXCEPTION = 5,

        //加载Object的异常
        RET_LOADOBJECT_EXCEPTION = 6,
    }
}
