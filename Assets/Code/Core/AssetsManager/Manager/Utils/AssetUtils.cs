//using GameLib.Core.Utils;
//using System;
//using System.IO;

//namespace GameLib.Core.Asset
//{
//    /// <summary>
//    /// 资源相关的工具函数
//    /// </summary>
//    public class AssetUtils
//    {
//        private static char[] CN_SPLIT_CHARS = new char[] { '_' };

//        //路径的规范化
//        public static string PathNormalize(string requestPath)
//        {
//            return requestPath.Replace('\\', '/');
//        }

//        //静态方法获取玩家的骨骼信息
//        public static int GetPlayerBoneIndex(int modelID)
//        {
//            return modelID / 100;
//        }

//        /// <summary>
//        /// 获取从GameAssets开始的相对路径
//        /// 比如:GameAssets/Resources/Texture/UI/abc.unity3d
//        /// </summary>
//        /// <param name="requestPath">Texture/UI/abc</param>
//        /// <returns></returns>
//        public static string GetGameAssetsPath(string requestPath, AssetsRequestTypeCode requestCode, string extension = AssetConstDefine.ExtUnity3d)
//        {
//            if (string.IsNullOrEmpty(requestPath))
//            {
//                return string.Empty;
//            }
//            switch (requestCode)
//            {
//                case FileRequestTypeCode.BytesFile: //只读文件路径
//                case FileRequestTypeCode.EnableWriteBytesFile: //可写文件路径
//                    return System.IO.Path.Combine(AssetConstDefine.PathAssetsRoot, requestPath);
//                default:
//                    //把路径中的文件名部分,修改为小写.-- 以适应Unity5.5的新的打包工具,会把所有的bundle名字都打成小写.
//                    return AssetUtils.MakeFileNameToLower(Path.Combine(AssetConstDefine.PathAssetsRoot, Path.ChangeExtension(requestPath, extension)));
//            }
//        }

//        /// <summary>
//        /// 获取AssetsPath 
//        ///   资源全路径fullPath, 扩展名为.unity3d
//        ///   file://..../assets/GameAssets/Resources/Texture/UI/abc.unity3d
//        /// </summary>
//        /// <param name="requestPath">Texture/UI/abc</param>
//        /// <param name="requestCode"></param>
//        /// <returns></returns>
//        public static string GetAssetsPath(string requestPath, AssetsRequestTypeCode requestCode, string extension = AssetConstDefine.ExtUnity3d)
//        {
//            if (string.IsNullOrEmpty(requestPath))
//            {
//                return string.Empty;
//            }
//            switch (requestCode)
//            {
//                case FileRequestTypeCode.BytesFile: //只读文件路径
//                    return PathUtils.GetStreamingRootPath(requestPath);
//                case FileRequestTypeCode.EnableWriteBytesFile: //可写文件路径
//                    return PathUtils.GetWritePath(requestPath);
//                default:
//                    //把路径中的文件名部分,修改为小写.-- 以适应Unity5.5的新的打包工具,会把所有的bundle名字都打成小写.
//                    return AssetUtils.MakeFileNameToLower(PathUtils.GetResourcePath((Path.ChangeExtension(requestPath, extension))));
//            }
//        }

//        /// <summary>
//        /// 获取场景路径
//        /// </summary>
//        /// <param name="name"></param>
//        /// <returns></returns>
//        public static string GetSceneFilePath(string name)
//        {
//            return StringUtils.CombineString(AssetConstDefine.PathScene, name, AssetConstDefine.ExtUnity);
//        }

//        //获取声音文件路径
//        public static string GetAudioFilePath(string name, AudioTypeCode code)
//        {
//            switch (code)
//            {
//                case AudioTypeCode.Ambient://环境音
//                    return string.Format("Sound/Ambient/{0}", name);
//                case AudioTypeCode.Music://场景背景音乐
//                    return string.Format("Sound/Music/{0}", name);
//                case AudioTypeCode.Sfx: //技能的声音特效
//                    return string.Format("Sound/Sfx/{0}/{1}", LanguageSystem.Lang, name);
//                case AudioTypeCode.Speech://语音 --- 这里没有使用LangPostfix是因为语音一般都是根据语言来分,不会根据渠道来区分,并且音频一般都太大,尤其是对话更多.所以这里特殊处理.
//                    return string.Format("Sound/Speech/{0}/{1}", LanguageSystem.Lang, name);
//                case AudioTypeCode.UI: //UI声音
//                    return string.Format("Sound/UI/{0}", name);
//            }
//            return name;
//        }

//        //获取视频的路径
//        public static string GetVideoFilePath(string name)
//        {
//            return string.Format("Video/{0}", name);
//        }

//        //获取动作路径
//        public static string GetAnimationPath(string /*ModelTypeCode*/ ownerTypr, string boneIndex, string animClipName)
//        {
//            switch (ownerTypr)
//            {
//                case "Mount":
//                    return string.Format("Animation/mount/mount_{0}/animation/mount_{0}_{1}", boneIndex, animClipName);
//                case "Player":
//                    return string.Format("Animation/player/player_{0}/animation/player_{0}_{1}", boneIndex, animClipName);
//                case "Monster":
//                    return string.Format("Animation/monster/m_{0}/animation/m_{0}_{1}", boneIndex, animClipName);
//                default:
//                    return string.Format("Animation/{0}/{0}_{1}/{0}_{1}_{2}", ownerTypr.ToLower(), boneIndex, animClipName);
//            }
//        }

//        //判断文件当前路径是否为UI
//        public static bool IsUIRes(string filePath)
//        {
//            return filePath.IndexOf("GameUI") >= 0;
//        }

//        public static bool IsTexture(string filePath)
//        {
//            return filePath.IndexOf("Texture") >= 0;
//        }


//        /// <summary>
//        /// 获取模型类型
//        /// </summary>
//        /// <param name="modelName">模型的名字</param>
//        /// <param name="idx">返回模型的索引</param>
//        /// <returns></returns>
//        public static ModelTypeCode GetModelType(string modelName, out int idx)
//        {
//            idx = 0;
//            if (string.IsNullOrEmpty(modelName)) return ModelTypeCode.None;
//            string[] arr = modelName.Split(CN_SPLIT_CHARS);
//            if (arr.Length > 0)
//            {
//                //获取通用的模型的ID
//                if (arr.Length > 1)
//                {
//                    int.TryParse(arr[1], out idx);
//                }

//                switch (arr[0])
//                {
//                    case "player":
//                    case "splayer":
//                        return ModelTypeCode.Player;
//                    case "m":
//                    case "sm":
//                        return ModelTypeCode.Mount;
//                    case "obj":
//                    case "sobj":
//                        return ModelTypeCode.Object;
//                    case "pet":
//                    case "spet":
//                        return ModelTypeCode.Pet;
//                    case "w":
//                    case "sw":
//                        return ModelTypeCode.Weapon;
//                    case "gw":
//                    case "sgw":
//                        return ModelTypeCode.GodWeapon;
//                    case "mount":
//                    case "smount":
//                        return ModelTypeCode.Mount;
//                    case "wing":
//                    case "swing":
//                        return ModelTypeCode.Wing;
//                    case "e":
//                        if (arr.Length > 1)
//                        {
//                            //获取特效的ID
//                            if (arr.Length > 2)
//                            {
//                                int.TryParse(arr[2], out idx);
//                            }

//                            switch (arr[1])
//                            {
//                                case "body":
//                                    return ModelTypeCode.BodyVFX;
//                                case "weapon":
//                                    return ModelTypeCode.WeaponVFX;
//                                case "mount":
//                                    return ModelTypeCode.MountVFX;
//                                case "pet":
//                                    return ModelTypeCode.PetVFX;
//                                case "monster":
//                                    return ModelTypeCode.MountVFX;
//                                case "skill":
//                                    return ModelTypeCode.SkillVFX;
//                                case "ui":
//                                    return ModelTypeCode.UIVFX;
//                                case "object":
//                                    return ModelTypeCode.CollectionVFX;
//                                case "other":
//                                    return ModelTypeCode.OtherVFX;
//                            }
//                        }
//                        return ModelTypeCode.None;
//                }

//            }
//            return ModelTypeCode.None;
//        }

//        /// <summary>
//        /// 获取模型类型
//        /// </summary>
//        /// <param name="modelName"></param>
//        /// <returns></returns>
//        public static ModelTypeCode GetModelType(string modelName)
//        {
//            int idx;
//            return GetModelType(modelName, out idx);
//        }
//        /// <summary>
//        /// 获取模型资源路径
//        /// </summary>
//        /// <param name="type">模型类型</param>
//        /// <param name="code">模型ID</param>
//        /// <param name="isShow">是否展示</param>
//        /// <returns></returns>
//        public static string GetModelAssetPath(ModelTypeCode type, int code, bool isShow = false)
//        {
//            if (code <= 0)
//            {
//                return String.Empty;
//            }

//            switch (type)
//            {
//                case ModelTypeCode.Player:
//                    if (isShow) return string.Format("Prefab/Show/Player/player_{0}/splayer_{1:D3}", code / 100, code);
//                    return string.Format("Prefab/Player/player_{0}/player_{1:D3}", code / 100, code);
//                case ModelTypeCode.Monster:
//                case ModelTypeCode.Npc:
//                    if (isShow) return string.Format("Prefab/Show/Monster/sm_{0:D3}", code);
//                    return string.Format("Prefab/Monster/m_{0:D3}", code);
//                case ModelTypeCode.Object:
//                    if (isShow) return string.Format("Prefab/Show/Object/sobj_{0:D3}", code);
//                    return string.Format("Prefab/Object/obj_{0:D3}", code);
//                case ModelTypeCode.Pet:
//                    if (isShow) return string.Format("Prefab/Show/Pet/spet_{0:D3}", code);
//                    return string.Format("Prefab/Pet/pet_{0:D3}", code);
//                case ModelTypeCode.Weapon:
//                    if (isShow) return string.Format("Prefab/Show/Player/weapon/sw_{0:D3}", code);
//                    return string.Format("Prefab/Player/weapon/gw_{0:D3}", code);
//                case ModelTypeCode.GodWeapon:
//                    if (isShow) return string.Format("Prefab/Show/Player/weapon/gsw_{0:D3}", code);
//                    return string.Format("Prefab/Player/weapon/gw_{0:D3}", code);
//                case ModelTypeCode.Mount:
//                    if (isShow) return string.Format("Prefab/Show/Mount/smount_{0:D3}", code);
//                    return string.Format("Prefab/Mount/mount_{0:D3}", code);
//                case ModelTypeCode.BodyVFX:
//                    return string.Format("VFX/Player/Body/e_body_{0:D3}", code);
//                case ModelTypeCode.WeaponVFX:
//                    return string.Format("VFX/Player/Weapon/e_weapon_{0:D3}", code);
//                case ModelTypeCode.MountVFX:
//                    return string.Format("VFX/Mount/e_mount_{0:D3}", code);
//                case ModelTypeCode.PetVFX:
//                    return string.Format("VFX/Monster/e_pet_{0:D3}", code);
//                case ModelTypeCode.MonsterVFX:
//                    return string.Format("VFX/Monster/e_monster_{0:D3}", code);
//                case ModelTypeCode.SkillVFX:
//                    return string.Format("VFX/Skill/e_skill_{0:D3}", code);
//                case ModelTypeCode.UIVFX:
//                    return string.Format("VFX/UI/e_ui_{0:D3}", code);
//                case ModelTypeCode.OtherVFX:
//                    return string.Format("VFX/Other/e_other_{0:D3}", code);
//                case ModelTypeCode.CollectionVFX:
//                    return string.Format("VFX/Object/e_object_{0:D3}", code);
//                case ModelTypeCode.BuffVFX:
//                    return string.Format("VFX/Buff/e_buff_{0:D3}", code);
//                case ModelTypeCode.StrengthenVfx:
//                    return string.Format("VFX/Player/Body/e_body_{0:D3}", code);
//                case ModelTypeCode.Wing:
//                    if (isShow) return string.Format("Prefab/Show/Player/wing/swing_{0:D3}", code);
//                    return string.Format("Prefab/Player/wing/wing_{0:D3}", code);
//                case ModelTypeCode.UISceneModel:
//                    if (isShow) return string.Format("Prefab/Show/UIScene/uis_{0:D3}", code);
//                    return string.Format("Prefab/UIScene/uis_{0:D3}", code);
//                case ModelTypeCode.Emoji:
//                    return string.Format("VFX/Bubble/e_bubble_{0:D3}", code);
//                case ModelTypeCode.Timeline:
//                    return string.Format("TimeLine/{0}/timeline_{1:D3}", LanguageSystem.Lang, code);
//                default:
//                    if (isShow) return string.Format("Prefab/Show/Monster/sm_{0:D3}", code);
//                    return string.Format("Prefab/Monster/m_{0:D3}", code);
//            }
//        }

//        /// <summary>
//        /// 获取模型的默认资源路径
//        /// </summary>
//        /// <param name="type">模型类型</param>
//        /// <param name="param">
//        /// 1.在获取角色的默认模型时的,职业参数信息.
//        /// </param>
//        /// <returns></returns>
//        public static string GetPlaceHolderModelAssetPath(ModelTypeCode type, int param = 1)
//        {
//            switch (type)
//            {
//                case ModelTypeCode.Player:
//                    return string.Format(AssetConstDefine.Empty_PlayerModel, param);
//                case ModelTypeCode.Monster:
//                    return AssetConstDefine.Empty_MonsterModel;
//                case ModelTypeCode.Npc:
//                    return AssetConstDefine.Empty_NpcModel;
//                case ModelTypeCode.UISceneModel:
//                case ModelTypeCode.Object:
//                    return AssetConstDefine.Empty_Object;
//                case ModelTypeCode.Pet:
//                    return AssetConstDefine.Empty_PetModel;
//                case ModelTypeCode.Weapon:
//                case ModelTypeCode.GodWeapon:
//                    return AssetConstDefine.Empty_WeaponModel;
//                case ModelTypeCode.Mount:
//                    return AssetConstDefine.Empty_MountModel;
//                case ModelTypeCode.WeaponVFX:
//                    return AssetConstDefine.Empty_VFXffect;
//                default:
//                    UnityEngine.Debug.LogError(string.Format("GetDefaultModelAssetPath,ModelTypeCode:{0};Param:{1}", type, param));
//                    return string.Empty;
//            }
//        }

//        /// <summary>
//        /// 获取图片的资源路径
//        /// </summary>
//        /// <param name="code">图片类型</param>
//        /// <param name="name">图片名字</param>
//        /// <returns></returns>
//        public static string GetImageAssetPath(ImageTypeCode code, string name)
//        {
//            switch (code)
//            {
//                case ImageTypeCode.UI:
//                    return string.Format("Texture/UI/{0}/{1}", LanguageSystem.LangPostfix, name);
//                case ImageTypeCode.MiniMap:
//                    return string.Format("Texture/Map/{0}", name);
//                case ImageTypeCode.Shader:
//                    return string.Format("Texture/Shader/{0}", name);
//                case ImageTypeCode.VFX:
//                    return string.Format("Texture/VFX/{0}", name);
//                case ImageTypeCode.House:
//                    return string.Format("Texture/House/{0}", name);
//                default:
//                    return string.Format("Textrue/{0}", name);
//            }
//        }

//        /// <summary>
//        /// 获取图片类型码
//        /// </summary>
//        /// <param name="texPath"></param>
//        /// <returns></returns>
//        public static ImageTypeCode GetImageTypeCode(string texPath)
//        {
//            if (texPath.StartsWith("Texture/UI/"))
//            {
//                return ImageTypeCode.UI;
//            }
//            else if (texPath.StartsWith("Texture/Map/"))
//            {
//                return ImageTypeCode.MiniMap;
//            }
//            else if (texPath.StartsWith("Texture/Shader/"))
//            {
//                return ImageTypeCode.Shader;
//            }
//            else if (texPath.StartsWith("Texture/VFX/"))
//            {
//                return ImageTypeCode.VFX;
//            }
//            else if (texPath.StartsWith("Texture/House/"))
//            {
//                return ImageTypeCode.House;
//            }
//            return ImageTypeCode.None;
//        }

//        /// <summary>
//        /// 是否是特效图片的路径
//        /// </summary>
//        /// <param name="texPath"></param>
//        /// <returns></returns>
//        public static bool IsVFXImagePath(string texPath)
//        {
//            return texPath.StartsWith("Texture/VFX/");
//        }

//        /// <summary>
//        /// 处理路径的分割符
//        /// </summary>
//        /// <param name="path"></param>
//        /// <returns></returns>
//        public static string ProcessPath(string path)
//        {
//            if (string.IsNullOrEmpty(path)) return path;
//            return path.Replace('\\', '/');
//        }

//        /// <summary>
//        /// 获取Path,不带扩展名
//        /// </summary>
//        /// <param name="path"></param>
//        /// <returns></returns>
//        public static string GetPathWithOutExt(string path)
//        {
//            var idx = path.LastIndexOf(".");
//            if (idx > 0)
//            {
//                return path.Substring(0, idx);
//            }
//            return path;
//        }

//        /// <summary>
//        /// 获取FileName,不带扩展名
//        /// </summary>
//        /// <param name="path"></param>
//        /// <returns></returns>
//        public static string GetFileNameWithOutExt(string path)
//        {
//            var startIdx = path.Replace("\\", "/").LastIndexOf("/");
//            var idx = path.LastIndexOf(".");
//            if (startIdx >= 0)
//            {
//                if (idx > 0)
//                {
//                    return path.Substring(startIdx + 1, idx - startIdx - 1);
//                }
//                else
//                {
//                    return path.Substring(startIdx + 1);
//                }
//            }
//            else
//            {
//                if (idx > 0)
//                {
//                    return path.Substring(0, idx);
//                }
//            }
//            return path;
//        }

//        //使某个路径的文件名小写的操作
//        public static string MakeFileNameToLower(string path)
//        {
//            //把路径中的文件名部分,修改为小写.-- 以适应Unity5.5的新的打包工具,会把所有的bundle名字都打成小写.
//            var arr = path.ToCharArray();
//            for (int i = arr.Length - 1; i >= 0; i--)
//            {
//                if (arr[i] == '/' || arr[i] == '\\') break;
//                if (char.IsLetter(arr[i])) arr[i] = char.ToLower(arr[i]);
//            }
//            return new string(arr);
//        }
//    }
//}
