using GameLib.Core.Utils;
using UnityEngine;

namespace Code.Core.Base
{
    /// <summary>
    ///层的工具
    /// </summary>
    public static class LayerUtils
    {

        //默认
        public readonly static int Default = LayerMask.NameToLayer(LayerNameDefine.Default);
        public readonly static int TransparentFX = LayerMask.NameToLayer(LayerNameDefine.TransparentFX);

        //UILauncher
        public readonly static int UILauncher = LayerMask.NameToLayer(LayerNameDefine.UILauncher);
        //UITopLauncher
        public readonly static int UITopLauncher = LayerMask.NameToLayer(LayerNameDefine.UITopLauncher);

        //主角所在的层
        public readonly static int LocalPlayer = LayerMask.NameToLayer(LayerNameDefine.LocalPlayer);
        //其他玩家所在的层
        public readonly static int RemotePlayer = LayerMask.NameToLayer(LayerNameDefine.RemotePlayer);
        //怪物,NPC,采集物层
        public readonly static int Monster = LayerMask.NameToLayer(LayerNameDefine.Monster);
        //技能召唤物的层
        public readonly static int SummonObj = LayerMask.NameToLayer(LayerNameDefine.SummonObj);
        //根据活动在场景中摆放的物件和特效的层
        public readonly static int SceneVFX = LayerMask.NameToLayer(LayerNameDefine.SceneVFX);


        //UI摄像机所在的层:UI层,UI顶层,UI引导层
        public readonly static int AresUI = LayerMask.NameToLayer(LayerNameDefine.AresUI);
        public readonly static int UITop = LayerMask.NameToLayer(LayerNameDefine.UITop);
        public readonly static int GuideUI = LayerMask.NameToLayer(LayerNameDefine.GuideUI);
        public readonly static int SkillWarp = LayerMask.NameToLayer(LayerNameDefine.SkillWarp);

        //剧情的UI,UI模型层
        public readonly static int UIStory = LayerMask.NameToLayer(LayerNameDefine.UIStory);
        public readonly static int UIStoryObject = LayerMask.NameToLayer(LayerNameDefine.UIStoryObject);
        public readonly static int UITopStory = LayerMask.NameToLayer(LayerNameDefine.UITopStory);

        //地形层---美术设定的层
        public readonly static int Terrain = LayerMask.NameToLayer(LayerNameDefine.Terrain);
        public readonly static int TerrainMesh = LayerMask.NameToLayer(LayerNameDefine.TerrainMesh);
        //地形上的物体,可以在场景中产生实时阴影层
        public readonly static int TerrainObj = LayerMask.NameToLayer(LayerNameDefine.TerrainObj);
        public readonly static int SceneChange1 = LayerMask.NameToLayer(LayerNameDefine.SceneChange1);
        public readonly static int SceneChange2 = LayerMask.NameToLayer(LayerNameDefine.SceneChange2);
        //用于在场景中产生实时阴影的层,不会在主相机中出现 --美术设定
        public readonly static int ShadowMesh = LayerMask.NameToLayer(LayerNameDefine.ShadowMesh);

        //布置到场景的触发器层 -- 策划配置,包括传送阵,声音触发器等
        public readonly static int Trigger = LayerMask.NameToLayer(LayerNameDefine.Trigger);

        //碰撞层
        public readonly static int Collider = LayerMask.NameToLayer(LayerNameDefine.Collider);
        //墙体
        public readonly static int Wall = LayerMask.NameToLayer(LayerNameDefine.Wall);
        //交互层，用于界面上 摄像头对该物体聚焦（其他所有层都模糊处理）
        public readonly static int Interact = LayerMask.NameToLayer(LayerNameDefine.Interact);
        //场景故事层，用于交互或播放Timeline
        public readonly static int Story = LayerMask.NameToLayer(LayerNameDefine.Story);

        public readonly static int AR = LayerMask.NameToLayer(LayerNameDefine.AR);

        public readonly static int SceneObject_Mask = ~(LayerToMask(AresUI) | LayerToMask(GuideUI) | LayerToMask(LocalPlayer) | LayerToMask(Trigger) | LayerToMask(SummonObj) | (LayerToMask(SceneVFX)));
        public readonly static int UI_Mask = (LayerToMask(AresUI) | LayerToMask(GuideUI) | LayerToMask(UITop) | LayerToMask(ShadowMesh) | LayerToMask(UILauncher) | LayerToMask(UITopLauncher));
        public readonly static int NoneUI_Mask = ~(AresUI | UITop | GuideUI | UILauncher | UITopLauncher | Physics.IgnoreRaycastLayer);
        public readonly static int Terrain_Mask = UnityUtils.GetLayerMask(LayerNameDefine.Terrain, LayerNameDefine.TerrainObj, LayerNameDefine.TerrainMesh);
        public readonly static int TerrainPath_Mask = UnityUtils.GetLayerMask(LayerNameDefine.Terrain, LayerNameDefine.TerrainMesh);


        public static bool ContainLayer(int layer, int mask)
        {
            return ((1 << layer) & mask) != 0;
        }

        public static int LayerToMask(int layer)
        {
            return 1 << layer;
        }
    }
}
