namespace Code.Entity.Base
{
    /// <summary>
    /// 实体的基础信息
    /// </summary>
    public abstract class EntityInitInfo
    {
        /// <summary>
        /// 服务器ID，Entity实例的唯一ID
        /// </summary>
        public ulong ID = 0;
        /// <summary>
        /// 配置表的ID，从配置信息中读取，用于模型显示
        /// </summary>
        public uint CfgID = 0;
        /// <summary>
        /// 位置X
        /// </summary>
        public float X = 0;
        /// <summary>
        /// 位置Y
        /// </summary>
        public float Y = 0;
        /// <summary>
        /// 位置Z
        /// </summary>
        public float Z = 0;
    }
}
