namespace Code.Core.Base
{
    /// <summary>
    /// Layer的名字定义
    /// </summary>
    public class LayerNameDefine
    {
        //默认和没有物体的层
        public const string Default = "Default";
        public const string TransparentFX = "TransparentFX";

        //场景中模型的层        
        public const string LocalPlayer = "LocalPlayer";          //主角和主角宠物  
        public const string RemotePlayer = "RemotePlayer";        //其他玩家和宠物 
        public const string Monster = "Monster";                  //怪物和NPC

        //不能被选择的物品--采集物,技能产生的物品等
        public const string UnselectableObj = "UnselectableObj";

        //在场景中用于产生阴影的物体 -- 不会被主摄像机看到
        public const string ShadowMesh = "ShadowMesh";

        //地形的层
        public const string Terrain = "Terrain";            //地形的层  --接受阴影
        public const string TerrainObj = "OnTerrainObjs";      //地形上模型的层 -- 不接受阴影
        public const string TerrainMesh = "TerrainMesh";    //地形上的Mesh -- 接受阴影    
        public const string SceneChange1 = "SceneChange1";  //切换场景的层1
        public const string SceneChange2 = "SceneChange2";  //切换场景的层2


        //UI界面上的层
        public const string AresUI = "UI";  //默认UI层        
        public const string UITop = "UITop";    //最上层的层            

        public const string UILauncher = "UILauncher";
        public const string UITopLauncher = "UITopLauncher";

        //对话和剧情播放的层,包裹UI和场景对象
        public const string UIStory = "UIStory";
        public const string UIStoryObject = "UIStoryObject";
        public const string RoleStory = "RoleStory";
        public const string UITopStory = "UITopStory";

        //在编辑场景时,触发器的层
        public const string Trigger = "Trigger";
        //引导层UI在所有UI最上层
        public const string GuideUI = "GuideUI";
        //召唤（掉落）效果层
        public const string SummonObj = "SummonObj";
        //场景特效
        public const string SceneVFX = "SceneVFX";

        //可以碰撞的
        public const string Collider = "Collider";
        //墙体
        public const string Wall = "Wall";
        //交互层，用于界面上 摄像头对该物体聚焦（其他所有层都模糊处理）
        public const string Interact = "Interact";
        //技能特效扭曲层
        public const string SkillWarp = "SkillWarp";
        //AR层，专用于交互对象的聚焦
        public const string AR = "AR";
        //场景故事层，用于交互或播放Timeline
        public const string Story = "Story";
    }
}
