using UnityEngine;

namespace GameLib.Core.UI
{
    /// <summary>
    /// 脚本中要缓存一些GameObject对象
    /// 不用使用gameObject,transform等方法,
    /// 因为这些方法会导致查找操作,效率很低,
    /// 所以继承此脚本,用于保存这些属性的引用,通过这些引用会得到更好的效率
    /// </summary>
    public interface IMonoCache
    {
        /// <summary>
        /// GameObject的引用
        /// </summary>
        GameObject GameObjectInst { get; }

        /// <summary>
        /// Transform的引用
        /// </summary>
        Transform TransformInst { get; }
    }
}
