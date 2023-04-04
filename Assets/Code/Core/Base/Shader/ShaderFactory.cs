using GameLib.Core.MagicCube.SimpleStruct;
using GameLib.Core.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace GameLib.Core.Base
{
    /// <summary>
    /// Shader工厂类，提供Find函数获取Shader
    /// 在Editor模式可以创建变体文件，收集所有的Keywords进行分帧预热
    /// </summary>
    [ExecuteAlways]
    public class ShaderFactory : MonoBehaviour
    {
        #region 变量
        [Header("重新刷新ShaderFactory中的Shader列表和变体的资源对象")]
        public bool RefeshShaderList = false;

        [Header("将所有变体保存在这里")]
        [SerializeField]
        private List<ShaderVariantCollection> _warmupVariantCollections;
        [SerializeField]
        private List<ShaderVariantCollection> _unWarmupVariantCollection;

        /// <summary>
        /// 所有的Shader
        /// </summary>
        private Dictionary<string, Shader> _shaderDict = null;

        [Header("将所有要用到的Shader绑定到这里")]
        [SerializeField]
        private List<FactoryShaderInfo> _shadersInfo = null;

        /// <summary>
        /// 属性名字
        /// </summary>
        [Header("所有的属性名字和类型列表")]
        [SerializeField]
        private List<StringIntegerPair> _propertys;

        //处理Keyword分割的字符数组
        private readonly char[] CN_SPLIT_CHAR_ARR = new char[] { ' ', '\t' };
        //Shader的保存位置
        private readonly string CN_SHADER_PATH = "Assets/GameAssets/Resources/Graphics/Shader";
        //Shader变体文件的保存位置，也是Shader的集合
        private readonly string CN_SHADER_VARIANT_COLLECTION_PATH = "Assets/GameAssets/Resources/Prefabs/Shader/ShaderCollect_{0}.shadervariants";
        #endregion

        #region 静态查找入口
#if UNITY_EDITOR
        private bool _useFactoryShader = false;
#else
        private bool _useFactoryShader = true;
#endif
        private static ShaderFactory _instance = null;

        public static Shader Find(string shaderName)
        {
            if (_instance != null)
            {
                if (_instance._useFactoryShader)
                {
                    Dictionary<string, Shader> dict = _instance.GetShadersDict();
                    if (dict != null && dict.ContainsKey(shaderName))
                    {
                        return dict[shaderName];
                    }
                }
            }
            return Shader.Find(shaderName);
        }

        private void Awake()
        {
            if (_instance != null)
            {
                DevLog.LogError("重复创建ShaderFactory!!");
            }
            _instance = this;
        }
        #endregion

        #region 预热Shader
        private void Start()
        {
            if (Application.isPlaying)
            {
                DontDestroyOnLoad(gameObject);
            }
            //使用协程分帧预热Shader
            StartCoroutine(WarmupAllShaders());
            //CoroutinePool.AddTask(WarmupAllShaders());
        }

        private IEnumerator WarmupAllShaders()
        {
            yield return null;
            if (_useFactoryShader)
            {
                for (int i = 0; i < _warmupVariantCollections.Count; i++)
                {
                    _warmupVariantCollections[i].WarmUp();
                    yield return null;
                }
            }
            else
            {
                Shader.WarmupAllShaders();
            }
            yield return null;
        }
        #endregion

        /// <summary>
        /// 获取Shader字典
        /// </summary>
        public Dictionary<string, Shader> GetShadersDict()
        {
            if (_shaderDict == null && _shadersInfo != null)
            {
                _shaderDict = new Dictionary<string, Shader>();
                if (_useFactoryShader)
                {
                    for (int i = 0; i < _shadersInfo.Count; i++)
                    {
                        if (_shadersInfo[i] != null && _shadersInfo[i].Shader != null)
                        {
                            Shader shader = _shadersInfo[i].Shader;
                            _shaderDict[shader.name] = shader;
                        }
                    }
                    DevLog.Log("ShaderFactory生成了Shader字典了。");
                }
            }
            return _shaderDict;
        }

        /// <summary>
        /// 运行时填充格式化数据
        /// </summary>
        /// <param name="data"></param>
        public void FillShaderInfo(object[] data)
        {
            if (data != null && data.Length >= 2)
            {
                Action<string, int> propertyCallback = data[0] as Action<string, int>;
                Action<Shader, int[], Vector4[]> shaderInfoCallback = data[1] as Action<Shader, int[], Vector4[]>;
                if (propertyCallback != null && shaderInfoCallback != null)
                {
                    for (int i = 0; i < _propertys.Count; i++)
                    {
                        propertyCallback(_propertys[i].Key, _propertys[i].Value);
                    }

                    for (int i = 0; i < _shadersInfo.Count; i++)
                    {
                        FactoryShaderInfo shaderInfo = _shadersInfo[i];
                        if (shaderInfo != null && shaderInfo.Shader != null)
                        {
                            Shader curShader = shaderInfo.Shader;
                            if (!_useFactoryShader)
                            {
                                curShader = Shader.Find(curShader.name);
                            }
                            int[] props = Array.ConvertAll(shaderInfo.Properties, x=> { return x.Key; });
                            Vector4[] vector4 = Array.ConvertAll(shaderInfo.Properties, x=> { return x.Value; });
                            shaderInfoCallback(curShader, props, vector4);
                        }
                    }
                }
                else
                {
                    DevLog.LogError("FillShaderInfo的回调是Null.数据填充失败.");
                }
            }
            else
            {
                DevLog.LogError("FillShaderInfo的参数是Null.数据填充失败.");
            }
        }

        /// <summary>
        /// 创建变体资源文件，收集Shader文件
        /// </summary>
        /// <param name="svc"></param>
        /// <returns></returns>
        private List<Shader> Execute(List<ShaderVariantCollection> svc)
        {
            string[] ignoreSubPath = new string[] 
            {
                "Gonbest/Shadertoy/",
                "Gonbest/PBR/",
                "Gonbest/Legacy/",
                "Gonbest/Function/",
                "Gonbest/Experiment/",
                "Gonbest/Include/",
                "Base/",
                "External/T4M"
            };
            return CreateShaderVariantAssets(svc, ignoreSubPath);
        }

        /// <summary>
        /// 创建一个ShaderVariantCollection资源
        /// </summary>
        /// <param name="svcList"></param>
        /// <param name="ignoreSubPath"></param>
        /// <returns></returns>
        private List<Shader> CreateShaderVariantAssets(List<ShaderVariantCollection> svcList, string[] ignoreSubPath = null)
        {
            List<Shader> shaderList = DoScanShaders(ignoreSubPath, new string[] { "Ares/SpecialEffect/FS_Shadow" });
            List<ShaderVariantCollection.ShaderVariant> shaderVariants = DoScanVariant(shaderList);
            Dictionary<string, ShaderVariantCollection> svcDict = new Dictionary<string, ShaderVariantCollection>();
            foreach (ShaderVariantCollection.ShaderVariant variant in shaderVariants)
            {
                string[] shaderName = variant.shader.name.Split('/');
                string key = shaderName[0];
                if (!svcDict.ContainsKey(key))
                {
                    //拼接变体文件的路径
                    string shaderVariantAssetsPath = string.Format(CN_SHADER_VARIANT_COLLECTION_PATH, key);
                    ShaderVariantCollection svcAssets = AssetDatabase.LoadAssetAtPath<ShaderVariantCollection>(shaderVariantAssetsPath);
                    if (svcAssets == null)
                    {
                        //没文件就创建
                        svcAssets = new ShaderVariantCollection();
                        AssetDatabase.CreateAsset(svcAssets, shaderVariantAssetsPath);
                        svcAssets = AssetDatabase.LoadAssetAtPath<ShaderVariantCollection>(shaderVariantAssetsPath);
                    }
                    svcDict[key] = svcAssets;
                }
                svcDict[key].Add(variant);
            }
            svcList.AddRange(svcDict.Values);
            //保存变体文件
            AssetDatabase.SaveAssets();
            return shaderList;
        }

        /// <summary>
        /// 收集Shader
        /// </summary>
        private List<Shader> DoScanShaders(string[] ignoreSubPath = null, string[] appendShaders = null)
        {
            List<Shader> shadersList = new List<Shader>();
            string[] files = Directory.GetFiles(CN_SHADER_PATH, "*.shader", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                string filePath = file.Replace('\\', '/');
                //1. 处理需要忽略的Shader
                bool ignore = false;
                if (ignoreSubPath != null)
                {
                    foreach (var igonrePath in ignoreSubPath)
                    {
                        if (filePath.IndexOf(igonrePath) >= 0)
                        {
                            DevLog.LogWarning("忽略Shader:" + filePath);
                            ignore = true;
                            break;
                        }
                    }
                }
                if (!ignore)
                {
                    DevLog.Log("开始处理Shader:" + filePath);
                    Shader shader = UnityEditor.AssetDatabase.LoadAssetAtPath<Shader>(filePath);
                    if (shader != null)
                    {
                        shadersList.Add(shader);
                    }
                }

                //2. 处理需要追加的Shader
                if (appendShaders != null)
                {
                    foreach (var append in appendShaders)
                    {
                        Shader shader = Shader.Find(append);
                        if (shader != null)
                        {
                            int index = shadersList.IndexOf(shader);
                            if (index < 0)
                            {
                                shadersList.Add(shader);
                            }
                        }
                    }
                }
            }
            return shadersList;
        }

        /// <summary>
        /// 收集Shader的变体
        /// </summary>
        private List<ShaderVariantCollection.ShaderVariant> DoScanVariant(List<Shader> shaders)
        {
            List<ShaderVariantCollection.ShaderVariant> shaderVariants = new List<ShaderVariantCollection.ShaderVariant>();
            foreach (Shader shader in shaders)
            {
                ShaderVariantCollection.ShaderVariant variant = new ShaderVariantCollection.ShaderVariant();
                HashSet<string[]> shadersAllKeywords = GetShadersAllKeywords(shader);
                if (shadersAllKeywords.Count > 0)
                {
                    foreach (var keywords in shadersAllKeywords)
                    {
                        variant = new ShaderVariantCollection.ShaderVariant();
                        variant.shader = shader;
                        variant.passType = UnityEngine.Rendering.PassType.Normal;
                        variant.keywords = keywords;
                        shaderVariants.Add(variant);
                    }
                    // 说明没有任何的Keywords
                    if (variant.shader == null)
                    {
                        variant = new ShaderVariantCollection.ShaderVariant();
                        variant.shader = shader;
                        variant.passType = UnityEngine.Rendering.PassType.Normal;
                        shaderVariants.Add(variant);
                    }
                }
            }
            DevLog.Log("ShaderVariantCollection Shader Count:" + shaderVariants.Count);
            return shaderVariants;
        }

        /// <summary>
        /// 获取一个Shader的所有Keywords
        /// </summary>
        /// <param name="shader"></param>
        private HashSet<string[]> GetShadersAllKeywords(Shader shader)
        {
            HashSet<string[]> keysSet = new HashSet<string[]>();
            //List<string[]> keysSet = new List<string[]>();
            GetShaderVariantEntries(shader, out int[] types, out string[] keywords);
            if (keywords != null)
            {
                List<string[]> varList = new List<string[]>();
                foreach (var keys in keywords)
                {
                    if (string.IsNullOrEmpty(keys) && keys.IndexOf("FOG_EXP") < 0)
                    {
                        var arr = keys.Split(CN_SPLIT_CHAR_ARR, StringSplitOptions.RemoveEmptyEntries);
                        keysSet.Add(arr);
                    }
                }
            }
            return keysSet;
        }

        /// <summary>
        /// 通过反射获取当前Shader的所有变体
        /// GetShaderVariantEntries用于获取指定Shader变体收集中的所有Shader变体条目。
        /// 它的参数是一个ShaderVariantCollection对象，返回一个ShaderVariantCollection.ShaderVariantEntry的列表，每个条目都包含了一个Shader和一个变体列表。
        /// 这个函数通常用于在运行时动态加载和管理Shader变体，以优化游戏性能。
        /// </summary>
        private void GetShaderVariantEntries(Shader shader, out int[] types, out string[] keywords)
        {
            ShaderVariantCollection svc = new ShaderVariantCollection();
            try
            {
                object[] param = new object[] { shader, svc, null, null };
                Type shaderUtil = typeof(UnityEditor.ShaderUtil);
                shaderUtil.InvokeMember
                (
                    "GetShaderVariantEntries", 
                    System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.InvokeMethod,
                    null,
                    null,
                    param
                );
                types = (int[])param[2];
                keywords = (string[])param[3];
            }
            finally
            {
                DestroyImmediate(svc);
                svc = null;
            }
        }

        /// <summary>
        /// 处理Shader的属性类型和属性的值
        /// </summary>
        /// <param name="allShadersList"></param>
        /// <param name="shadersInfoList"></param>
        /// <param name="propertysList"></param>
        private void DoProgressShader(List<Shader> allShadersList, out List<FactoryShaderInfo> shadersInfoList, out List<StringIntegerPair> propertysList)
        {
            shadersInfoList = new List<FactoryShaderInfo>();
            propertysList = new List<StringIntegerPair>();
            Dictionary<string, int> propertyDict = new Dictionary<string, int>();
            Dictionary<string, int> propertyIndexDict = new Dictionary<string, int>();
            foreach (Shader shader in allShadersList)
            {
                if (shader != null && !string.IsNullOrEmpty(shader.name))
                {
                    Material mat = new Material(shader);
                    //获取属性的数量
                    int count = ShaderUtil.GetPropertyCount(shader);
                    FactoryShaderInfo defaultValArr = new FactoryShaderInfo(count);
                    defaultValArr.Shader = shader;
                    for (int i = 0; i < count; i++)
                    {
                        //获取属性名字和类型
                        string propName = ShaderUtil.GetPropertyName(shader, i);
                        //ShaderUtil.ShaderPropertyType propType = ShaderUtil.GetPropertyType(shader, i);
                        int propType = (int)ShaderUtil.GetPropertyType(shader, i);
                        if (propertyDict.TryGetValue(propName, out int shaderPropType))
                        {
                            //如果是Range和Float，就设定默认为Float
                            if (shaderPropType != propType)
                            {
                                if ((shaderPropType == (int)ShaderUtil.ShaderPropertyType.Float && propType == (int)ShaderUtil.ShaderPropertyType.Range) ||
                                    (shaderPropType == (int)ShaderUtil.ShaderPropertyType.Range && propType == (int)ShaderUtil.ShaderPropertyType.Float))
                                {
                                    propertyDict[propName] = (int)ShaderUtil.ShaderPropertyType.Float;
                                }
                                //else if (shaderPropType > 100 && propType == (shaderPropType / 100))
                                //{
                                //    //获取着色器属性的纹理尺寸。
                                //    //UnityEngine.Rendering.TextureDimension texDim = ShaderUtil.GetTexDim(shader, i);
                                //    int texDim = (int)ShaderUtil.GetTexDim(shader, i);
                                //    if (texDim != shaderPropType % 100)
                                //    {
                                //        DevLog.LogErrorFormat("在Shader[{0}]中发现纹理属性[{1}]的维度是:{2};;而其他的是{3}", shader.name, propName, texDim, (shaderPropType % 100));
                                //    }
                                //    else
                                //    {
                                //        DevLog.LogErrorFormat("在Shader[{0}]中发现属性[{1}]是类型:{2};;而其他的是{3}", shader.name, propName, propType, shaderPropType);
                                //    }
                                //}
                            }
                        }
                        else
                        {
                            //如果类型是纹理类型
                            if (propType == (int)ShaderUtil.ShaderPropertyType.TexEnv)
                            {
                                int texDim = (int)ShaderUtil.GetTexDim(shader, i);
                                propType = propType * 100 + texDim;
                            }
                            propertyDict[propName] = propType;
                            //存Shader的属性类型信息
                            propertysList.Add(new StringIntegerPair() { Key = propName, Value = propType });
                            propertyIndexDict[propName] = propertysList.Count - 1;
                        }

                        Vector4 propDefaultVal = Vector4.zero;
                        switch ((ShaderUtil.ShaderPropertyType)propType)
                        {
                            case ShaderUtil.ShaderPropertyType.Color:
                                propDefaultVal = mat.GetColor(propName);
                                break;
                            case ShaderUtil.ShaderPropertyType.Vector:
                                propDefaultVal = mat.GetVector(propName);
                                break;
                            case ShaderUtil.ShaderPropertyType.TexEnv:
                                Vector2 offset = mat.GetTextureOffset(propName);
                                Vector2 scale = mat.GetTextureScale(propName);
                                propDefaultVal = new Vector4(offset.x, offset.y, scale.x, scale.y);
                                break;
                            case ShaderUtil.ShaderPropertyType.Float:
                            case ShaderUtil.ShaderPropertyType.Range:
                                propDefaultVal = new Vector4(mat.GetFloat(propName), 0, 0, 0);
                                break;
                        }
                        //构建存储Shader的属性值信息
                        defaultValArr.Properties[i] = new IntegerVectorPair() { Key = propertyIndexDict[propName], Value = propDefaultVal };
                    }
                    shadersInfoList.Add(defaultValArr);
                    //销毁临时取值创建的材质球
                    DestroyImmediate(mat);
                }
                else
                {
                    shadersInfoList.Add(null);
                }
            }
        }

        /// <summary>
        /// 清空变体的数据
        /// </summary>
        private void ClearVariantCollect(List<ShaderVariantCollection> svcList)
        {
            for (int i = 0; i < svcList.Count; i++)
            {
                if (svcList[i] != null)
                {
                    svcList[i].Clear();
                }
            }
            svcList.Clear();
        }

        #region 编辑器使用，收集Shader
#if UNITY_EDITOR
        private void Update()
        {
            //重新收集变体数据信息
            if (RefeshShaderList)
            {
                RefeshShaderList = false;
                //清理原来的变体数据
                ClearVariantCollect(_unWarmupVariantCollection);
                ClearVariantCollect(_warmupVariantCollections);
                //收集Shader，创建变体文件
                List<Shader> shaderList = Execute(_warmupVariantCollections);
                //收集需要预热的Shader集合
                for (int i = 0; i < _warmupVariantCollections.Count; i++)
                {
                    if (_warmupVariantCollections[i].name.IndexOf("_Hidden") >= 0)
                    {
                        _unWarmupVariantCollection.Add(_warmupVariantCollections[i]);
                        _warmupVariantCollections.RemoveAt(i);
                    }
                }
                //处理属性类型和值
                DoProgressShader(shaderList, out _shadersInfo, out _propertys);
            }
        }
#endif
        #endregion
    }

    #region Shader的信息，存储属性值
    [Serializable]
    public class FactoryShaderInfo
    {
        [SerializeField]
        public Shader Shader;

        [SerializeField]
        public IntegerVectorPair[] Properties;

        public FactoryShaderInfo(int count)
        {
            Properties = new IntegerVectorPair[count];
        }
    }
    #endregion
}
