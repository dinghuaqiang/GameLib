using UnityEngine;

namespace GameLib.Core.Base
{
    /// <summary>
    /// Shader扩展类，提供给外部查找Shader
    /// </summary>
    public static class ShaderEx
    {
        private static GFunc<string, Shader> _findShaderHandler = null;

        /// <summary>
        /// 设置Shader的自定义查找句柄
        /// </summary>
        /// <param name="func"></param>
        public static void SetFindShaderHandler(GFunc<string, Shader> func)
        {
            _findShaderHandler = func;
        }

        /// <summary>
        /// 查找Shader的函数
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Shader Find(string name)
        {
            if (_findShaderHandler != null)
            {
                return _findShaderHandler(name);
            }
            return Shader.Find(name);
        }
    }
}
