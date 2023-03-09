namespace Code.Core.AI.BehaviorTree
{
    /// <summary>
    /// 装饰节点，用于防止纵向继承类数量爆炸问题。
    /// 始终【只有一个子节点】，用于修改子节点的结果或者执行子节点时执行其他操作（比如：更新黑板的Service）
    /// 父组合节点停用后，会先执行当前节点重写的DoParentCompositeStopped，然后执行子节点的DoParentCompositeStopped
    /// 子类可以扩展并覆盖DoStart()、DoStop()和DoChildStopped(Node child, bool result)方法，通过访问Decoratee属性启动或停止已装饰节点，并在其上调用start()或stop()。
    /// </summary>
    public abstract class Decorator : Container
    {
        protected Node Decoratee;

        public Decorator(string name, Node decoratee) : base(name)
        {
            Decoratee = decoratee;
            Decoratee.SetParent(this);
        }

        public override void SetRoot(Root rootNode)
        {
            base.SetRoot(rootNode);
            Decoratee.SetRoot(rootNode);
        }

        public override void ParentCompositeStopped(Composite composite)
        {
            base.ParentCompositeStopped(composite);
            Decoratee.ParentCompositeStopped(composite);
        }
    }
}
