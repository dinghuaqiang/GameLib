namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 组合节点，有多个子节点，用于控制他们的哪个子节点被执行。顺序和结果也是由这种节点定义的。
    /// </summary>
    public abstract class Composite : Container
    {
        /// <summary>
        /// 子节点数组
        /// </summary>
        protected Node[] Children;

        /// <summary>
        /// 设置所有子节点的父节点
        /// </summary>
        /// <param name="name"></param>
        /// <param name="children"></param>
        public Composite(string name, Node[] children) : base(name)
        {
            Children = children;
            if (children != null && children.Length > 0)
            {
                for (int i = 0; i < children.Length; i++)
                {
                    children[i].SetParent(this);
                }
            }
        }

        /// <summary>
        /// 设置所有子节点的根节点
        /// </summary>
        /// <param name="rootNode"></param>
        public override void SetRoot(Root rootNode)
        {
            base.SetRoot(rootNode);
            if (Children != null && Children.Length > 0)
            {
                for (int i = 0; i < Children.Length; i++)
                {
                    Children[i].SetRoot(rootNode);
                }
            }
        }

        /// <summary>
        /// 停止所有的子节点
        /// </summary>
        /// <param name="success"></param>
        protected override void Stopped(bool success)
        {
            if (Children != null && Children.Length > 0)
            {
                for (int i = 0; i < Children.Length; i++)
                {
                    Children[i].ParentCompositeStopped(this);
                }
            }
            base.Stopped(success);
        }

        /// <summary>
        /// 某个子节点请求 关闭所有子节点时，应该做的操作
        /// </summary>
        /// <param name="abortChild"></param>
        /// <param name="immediateRestart">true:子节点希望立即重置当前节点 false:子节点希望停用当前节点</param>
        public abstract void StopLowerPriorityChildrenForChild(Node abortChild, bool immediateRestart);
    }
}
