using GameLib.Core.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLib.Core.Base
{
    /// <summary>
    /// Shader工厂代理
    /// 这里是方便ShaderFactory类放在其他动态库里面，可能需要剥离ShaderFactory类出去
    /// </summary>
    public class ShaderFactoryProxy
    {
        private GameObject _go;
        private MonoBehaviour _script;
        private Type _type;
        private Dictionary<string, Shader> _shaderDict = null;

        internal bool CheckReadyOK()
        {
            return _type != null;
        }

        public void Initialize(GameObject go)
        {
            _shaderDict = null;
            _go = go;
            _script = go.GetComponent<MonoBehaviour>();
            if (_script == null)
            {
                DevLog.LogError("ShaderFactory的GO没有脚本!");
            }
            _type = _script.GetType();
            DevLog.Log("FactoryType:" + _type.Name);
        }

        public void UnInitialize()
        {
            _shaderDict = null;
            _script = null;
            _type = null;
        }

        public Shader Find(string shaderName)
        {
            Shader foundShader;
            Dictionary<string, Shader> shaderDict = GetShaderTable();
            if (shaderDict != null && shaderDict.ContainsKey(shaderName))
            {
                foundShader = shaderDict[shaderName];
            }
            else
            {
                foundShader = Shader.Find(shaderName);
                if (foundShader == null)
                {
                    DevLog.LogError("在ShaderFactory和包体内都没有找到此Shader:" + shaderName);
                }
            }
            return foundShader;
        }

        public Dictionary<string, Shader> GetShaderTable()
        {
            if (_shaderDict == null)
            {
                if (_type != null && _script != null)
                {
                    try
                    {
                        //反射获取ShaderFactory的GetShadersDict函数，获取到Shader字典
                        _shaderDict = AssemblyUtils.InvokePublicMemberMethod(_script, "GetShadersDict", new object[] {}) as Dictionary<string, Shader>;
                    }
                    catch (Exception ex)
                    {
                        DevLog.LogError(ex.Message);
                    }
                }
                else
                {
                    DevLog.LogError("ShaderFactoryProxy的类型和对象都没有被初始化!!");
                }
            }
            return _shaderDict;
        }

        public void FillShaderInfo(Dictionary<string, ShaderInfo> shaderDict, Dictionary<int, ShaderInfo> shaderTypeDict, Dictionary<string, ShaderPropertyInfo> propertyDict, Dictionary<int, ShaderPropertyInfo> propertyIDDict)
        {
            if (_type != null && _script != null)
            {
                shaderDict.Clear();
                propertyDict.Clear();
                propertyIDDict.Clear();
                List<ShaderPropertyInfo> propInfoList = new List<ShaderPropertyInfo>();

                //Action<string, int> propertyCallback = data[0] as Action<string, int>;
                //Action<Shader, int[], Vector4[]> shaderInfoCallback = data[1] as Action<Shader, int[], Vector4[]>;
                Action<string, int> propertyCallback = (name, type) =>
                {
                    ShaderPropertyInfo spi = new ShaderPropertyInfo(name, type);
                    propInfoList.Add(spi);
                    propertyDict[name] = spi;
                    propertyIDDict[spi.ID] = spi;
                };

                Action<Shader, int[], Vector4[]> shaderInfoCallback = (curShader, props, vector4) =>
                {
                    if (curShader != null)
                    {
                        ShaderInfo si = new ShaderInfo();
                        si.Name = curShader.name;
                        si.RealShader = curShader;
                        si.PropertyValueArray = vector4;
                        si.PropertyNameArray = Array.ConvertAll<int, string>(props, i => { return propInfoList[i].Name; });
                        shaderDict[si.Name] = si;
                        shaderTypeDict[si.RealShader.GetInstanceID()] = si;
                    }
                };

                //反射调用ShaderFactory的FillShaderInfo函数
                try
                {
                    AssemblyUtils.InvokePublicMemberMethod(_script, "FillShaderInfo", new object[] { propertyCallback, shaderInfoCallback });
                }
                catch (Exception ex)
                {
                    DevLog.LogError(ex.Message);
                }
            }
            else
            {
                DevLog.LogError("ShaderFactoryProxy的类型和对象都没有被初始化!!");
            }
        }
    }
}
