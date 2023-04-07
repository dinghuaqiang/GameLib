using GameLib.Core.Base;
using GameLib.Core.Support;
using GameLib.Core.Utils.Path;
using System;
using System.Security;
using FFileReader = GameLib.Core.Utils.FFileReader;
using MonoXmlUtils = GameLib.Core.Utils.MonoXmlUtils;

namespace GameLib.Core.Asset.CachePool
{
    /// <summary>
    /// PoolSettings的xml分析器
    /// </summary>
    public class PoolSettingsXmlReader
    {

        //模型字符串分割符
        private static char[] _splitChar = new char[] { '|' };

        /// <summary>
        /// 读取xml文件
        /// </summary>
        /// <param name="onPrefabSettingsCreate"></param>
        /// <returns></returns>
        public static void ReadXml(GAction<string, SpawnPoolSettings> onSpawnSettingsCreate, GAction<string[], string, PrefabPoolSettings> onPrefabSettingsCreate)
        {
            FFileReader.ReadTextAsync(PathDefines.PoolSettingsPath, text => {

                if (string.IsNullOrEmpty(text))
                {
                    UnityEngine.Debug.LogError(String.Format("dont found file: {0}", PathDefines.PoolSettingsPath));
                }
                else
                {
                    var root = MonoXmlUtils.GetRootNodeFromString(text);
                    if (root == null || root.Children == null)
                    {
                        UnityEngine.Debug.LogError(String.Format("read xml file error: {0}", PathDefines.PoolSettingsPath));
                    }
                    else
                    {
                        for (int i = 0; i < root.Children.Count; i++)
                        {
                            var spawnNode = root.Children[i] as SecurityElement;
                            if (ReadSpawnSettingsXml(spawnNode, onSpawnSettingsCreate))
                            {
                                for (int j = 0; j < spawnNode.Children.Count; j++)
                                {
                                    ReadPrefabSettingsXml(spawnNode.Children[j] as SecurityElement, onPrefabSettingsCreate);
                                }
                            }

                        }
                    }
                }
            });
        }

        //读取SpawnSettings的xml数据
        private static bool ReadSpawnSettingsXml(SecurityElement elment, GAction<string, SpawnPoolSettings> onSpawnSettingsCreate)
        {
            if (elment != null && elment.Tag == "SpawnPool")
            {
                string groupName = elment.Attribute("Name");
                if (!string.IsNullOrEmpty(groupName))
                {
                    SpawnPoolSettings setting = new SpawnPoolSettings();
                    int parsVal;
                    if (int.TryParse(elment.Attribute("StartupAutoCleaner"), out parsVal))
                    {
                        setting.StartupAutoCleaner = parsVal > 0 ? true : false;
                    }
                    if (int.TryParse(elment.Attribute("PrefabLiftTime"), out parsVal))
                    {
                        setting.PrefabLiftTime = parsVal;
                    }
                    if (int.TryParse(elment.Attribute("CleanerTick"), out parsVal))
                    {
                        setting.CleanerTick = parsVal;
                    }

                    if (onSpawnSettingsCreate != null)
                    {
                        onSpawnSettingsCreate(groupName, setting);
                    }
                    return true;
                }
            }
            return false;
        }

        //读取PrefabSettings的xml数据
        private static bool ReadPrefabSettingsXml(SecurityElement elment, GAction<string[], string, PrefabPoolSettings> onPrefabSettingsCreate)
        {
            if (elment != null && elment.Tag == "PrefabPool")
            {
                string groupName = elment.Attribute("Name");
                if (!string.IsNullOrEmpty(groupName))
                {
                    PrefabPoolSettings setting = new PrefabPoolSettings(null);
                    int parsVal;
                    if (int.TryParse(elment.Attribute("CullDespawned"), out parsVal))
                    {
                        setting.CullDespawned = parsVal > 0 ? true : false;
                    }
                    if (int.TryParse(elment.Attribute("CullAbove"), out parsVal))
                    {
                        setting.CullAbove = parsVal;
                    }
                    if (int.TryParse(elment.Attribute("CullDelay"), out parsVal))
                    {
                        setting.CullDelay = parsVal;
                    }
                    if (int.TryParse(elment.Attribute("CullMaxPerPass"), out parsVal))
                    {
                        setting.CullMaxPerPass = parsVal;
                    }

                    if (onPrefabSettingsCreate != null)
                    {

                        string[] prefabNameArr = string.IsNullOrEmpty(elment.Text) ? new string[] { } : elment.Text.Trim().Split(_splitChar, StringSplitOptions.RemoveEmptyEntries);
                        onPrefabSettingsCreate(prefabNameArr, groupName, setting);
                    }
                    return true;
                }
            }
            return false;
        }

    }
}
