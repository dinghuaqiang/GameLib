
namespace Code.Entity.Base
{
    /// <summary>
    /// 角色实体
    /// </summary>
    public class Character : Entity
    {
        protected override bool OnInitializeAfter(EntityInitInfo entityInitInfo)
        {
            return base.OnInitializeAfter(entityInitInfo);
        }

        protected override bool OnSetupFsmBefore()
        {
            return base.OnSetupFsmBefore();
        }
    }
}
