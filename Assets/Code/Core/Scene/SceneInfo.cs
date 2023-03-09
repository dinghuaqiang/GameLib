namespace GameLib.Core.Scene
{
    public class SceneInfo
    {
        public int CfgID { get; private set; }
        public int Priority { get; private set; }
        public string SceneName { get; private set; }
        public bool Additive { get; private set; }
        public SceneInfo(string sceneName, int priority = 100) : this(sceneName, false, priority) { }
        public SceneInfo(string sceneName, bool addtive, int priority = 100)
        {
            SceneName = sceneName;
            Additive = addtive;
            Priority = priority;
        }
    }
}
