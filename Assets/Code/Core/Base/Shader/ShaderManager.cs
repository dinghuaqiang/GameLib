using Code.Core.Utils;
using System.Collections.Generic;
using UnityEngine;

namespace GameLib.Core.Base
{
    /// <summary>
    /// Shader的管理
    /// </summary>
    public class ShaderManager : Singleton<ShaderManager>
    {
        #region 单例的初始化和反初始化
        public override void OnInitialize()
        {
            base.OnInitialize();
            Initialize();
        }

        public override void OnUnInitialize()
        {
            base.OnUnInitialize();
        }
        #endregion
        
        /// <summary>
        /// 是否使用动态Shader
        /// </summary>
        public static bool IsDynamicShader = true;
        #region  //私有变量    
        /// <summary>
        /// 是否初始化完毕
        /// </summary>
        private bool _initialized = false;
        //private ShaderFactoryProxy _factoryProxy = new ShaderFactoryProxy();

        //Shader的定义
        private Dictionary<string, ShaderInfo> _shaderDefines = new Dictionary<string, ShaderInfo>();
        private Dictionary<int, ShaderInfo> _shaderTypeDefines = new Dictionary<int, ShaderInfo>();

        //属性的信息
        private Dictionary<string, ShaderPropertyInfo> _propertyDefines = new Dictionary<string, ShaderPropertyInfo>();
        private Dictionary<int, ShaderPropertyInfo> _propertyIdDefines = new Dictionary<int, ShaderPropertyInfo>();
        #endregion

        public void Initialize()
        {
            if (_initialized)
            {
                return;
            }
            _initialized = true;
        }

        public void CreateShaderFactory()
        {
            if (_initialized && IsDynamicShader)
            {
                //TODO 加载ShaderFactory prefab资源
                //ShaderAssetsLoader.Initialize(OnShaderFactoryLoadFinished);
                //ShaderEx.SetFindShaderHandler(_factoryProxy.Find);
                ShaderEx.SetFindShaderHandler(ShaderFactory.Find);
            }
        }

        public void DestoryShaderFactory()
        {

        }

        public void OnShaderFactoryLoadFinished(GameObject factoryGo)
        {
            if (factoryGo != null)
            {
                Debug.Log("开始初始化ShaderFactory!");
                //_factoryProxy.Initialize(factoryGo);
                //_factoryProxy.FillShaderInfo(_shaderDefines, _shaderTypeDefines, _propertyDefines, _propertyIdDefines);
                Debug.Log("初始化ShaderFactory完毕!");
            }
            else
            {
                Debug.LogError("没有找到ShaderFactory资源.或者加载失败.");
            }
        }

        //获取Shader的属性类型
        public ShaderPropertyType GetShaderPropertyType(int id)
        {
            ShaderPropertyInfo info;
            _propertyIdDefines.TryGetValue(id, out info);
            if (info != null)
            {
                return info.GetShaderPropertyType();
            }
            return ShaderPropertyType.None;
        }
    }
}
