using Code.Core.Utils;
using GameLib.Core.Asset;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

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
            DestoryShaderFactory();
            _initialized = false;
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
        private ShaderFactoryProxy _factoryProxy = new ShaderFactoryProxy();

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

        /// <summary>
        /// 在游戏启动或者预加载资源的时候执行ShaderFactory节点的创建，预热Shader
        /// </summary>
        public void CreateShaderFactory()
        {
            if (_initialized && IsDynamicShader)
            {
                //加载ShaderFactory prefab资源
                ShaderAssetsLoader.Initialize(OnShaderFactoryLoadFinished);
                ShaderEx.SetFindShaderHandler(_factoryProxy.Find);
                //ShaderEx.SetFindShaderHandler(ShaderFactory.Find);
            }
        }

        public void DestoryShaderFactory()
        {
            ShaderAssetsLoader.Uninitialize();
            ShaderEx.SetFindShaderHandler(null);
        }

        //判断Shader准备好了吗?
        public bool CheckReadyOK()
        {
            if (_initialized && IsDynamicShader)
            {
                //如果没有找到资源,或者已经创建完毕都说明初始化完成
                return _factoryProxy.CheckReadyOK() || ShaderAssetsLoader.CheckShaderAssetNotFound();
            }
            return true;
        }

        //获取Shader定义
        public ShaderInfo GetShaderDefine(string name)
        {
            ShaderInfo result;
            _shaderDefines.TryGetValue(name, out result);
            return result;
        }

        //获取Shader的定义信息
        public ShaderInfo GetShaderDefine(Shader s)
        {
            if (s == null) return null;
            ShaderInfo result;
            if (!_shaderTypeDefines.TryGetValue(s.GetInstanceID(), out result))
            {
                _shaderDefines.TryGetValue(s.name, out result);
            }
            return result;
        }

        //是否包含属性名字
        public bool HasPropertyName(string name)
        {
            ShaderPropertyInfo info;
            return _propertyDefines.TryGetValue(name, out info);
        }

        //获取Shader的属性类型
        public ShaderPropertyType GetShaderPropertyType(string name)
        {
            ShaderPropertyInfo info;
            _propertyDefines.TryGetValue(name, out info);
            if (info != null)
            {
                return info.GetShaderPropertyType();
            }
            return ShaderPropertyType.None;
        }

        //是否包含属性名字
        public bool HasPropertyName(int id)
        {
            ShaderPropertyInfo info;
            return _propertyIdDefines.TryGetValue(id, out info);
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

        //获取Shader的纹理维度
        public TextureDimension GetShaderTexDim(int id)
        {
            ShaderPropertyInfo info;
            _propertyIdDefines.TryGetValue(id, out info);
            if (info != null)
            {
                return info.GetShaderTexDim();
            }
            return TextureDimension.None;
        }

        //获取Shader的纹理维度
        public TextureDimension GetShaderTexDim(string name)
        {
            ShaderPropertyInfo info;
            _propertyDefines.TryGetValue(name, out info);
            if (info != null)
            {
                return info.GetShaderTexDim();
            }
            return TextureDimension.None;
        }

        /// <summary>
        /// ShaderFactory.prefab加载完成的回调
        /// </summary>
        /// <param name="factoryGo">创建的GameObject</param>
        public void OnShaderFactoryLoadFinished(GameObject factoryGo)
        {
            if (factoryGo != null)
            {
                Debug.Log("开始初始化ShaderFactory!");
                _factoryProxy.Initialize(factoryGo);
                _factoryProxy.FillShaderInfo(_shaderDefines, _shaderTypeDefines, _propertyDefines, _propertyIdDefines);
                Debug.Log("初始化ShaderFactory完毕!");
            }
            else
            {
                Debug.LogError("没有找到ShaderFactory资源.或者加载失败.");
            }
        }
    }
}
