using System.Collections.Generic;
using UnityEngine;

namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 行为树上下文，主要提供计时器的Update和黑板数据的获取
    /// </summary>
    public class BehaviorContext : MonoBehaviour
    {
        private Clock Clock = null;
        private Dictionary<string, Blackboard> Blackboards = null;
        private readonly string CN_CONTEXT_GO_NAME = "[BehaviorContext]";
        private static BehaviorContext _instance = null;

        /// <summary>
        /// 提供给外部获取计时器
        /// </summary>
        /// <returns></returns>
        public static Clock GetClock()
        {
            return SharedInstance().Clock;
        }

        /// <summary>
        /// 提供外部获取到黑板数据，没有黑板的话就创建一个新的提供出去
        /// 【这是一个共享黑板，提供给多个节点共用一个黑板】
        /// </summary>
        /// <param name="blackboardName">黑板名字</param>
        /// <returns></returns>
        public static Blackboard GetSharedBlackboard(string blackboardName)
        {
            BehaviorContext context = SharedInstance();
            if (!context.Blackboards.ContainsKey(blackboardName))
            {
                context.Blackboards.Add(blackboardName, new Blackboard(context.Clock));
            }
            return context.Blackboards[blackboardName];
        }

        /// <summary>
        /// 使用单例初始化黑板GameObject对象，挂载上下文脚本，实现计时器时间刷新
        /// </summary>
        /// <returns></returns>
        private static BehaviorContext SharedInstance()
        {
            if (_instance == null)
            {
                GameObject contextGo = new GameObject();
                _instance = contextGo.AddComponent<BehaviorContext>();
                contextGo.isStatic = true;
            }
            return _instance;
        }

        private void Awake()
        {
            if (Clock == null)
            {
                Clock = new Clock();
            }
            if (Blackboards == null)
            {
                Blackboards = new Dictionary<string, Blackboard>();
            }
            gameObject.name = CN_CONTEXT_GO_NAME;
        }

        private void Update()
        {
            if (Clock != null)
            {
                Clock.Update(Time.deltaTime);
            }
        }
    }
}
