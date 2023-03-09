using GameLib.Core.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameLib.Core.UI
{
    /// <summary>
    /// 继承MonoBehaviour,用于记录当前脚本所在对象的GameObject以及Transform引用
    /// </summary>
    public class MonoCacheBase : MonoBehaviour, IMonoCache
    {
        private GameObject _gameObjectInst = null;
        private Transform _transformInst = null;

        /// <summary>
        /// GameObject的实例引用
        /// </summary>
        public GameObject GameObjectInst
        {
            get
            {
                if (_gameObjectInst == null)
                {
                    _gameObjectInst = gameObject;
                }
                return _gameObjectInst;
            }
        }

        /// <summary>
        /// Transform的实例引用
        /// </summary>
        public Transform TransformInst
        {
            get
            {
                if (_transformInst == null)
                {
                    _transformInst = transform;
                }
                return _transformInst;
            }
        }

        /// <summary>
        /// 根据名字查找组件
        /// </summary>
        /// <typeparam name="Comp"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public Comp FindUI<Comp>(string name) where Comp : Component
        {
            return FindUI<Comp>(TransformInst, name);
        }

        public Comp FindUI<Comp>(Transform transformInst, string name) where Comp : Component
        {
            Comp form = default;
            Transform trans = transformInst.Find(name);
            if (trans != null)
            {
                form = trans.RequireComponent<Comp>();
            }
            return form;
        }

        public Comp FindComponent<Comp>(string nodePath)
        {
            return TransformInst.Find(nodePath).GetComponent<Comp>();
        }

        public GameObject FindGameObject(string nodePath)
        {
            return TransformInst.Find(nodePath).gameObject;
        }

        public Transform FindTransform(string nodePath)
        {
            return TransformInst.Find(nodePath);
        }

        public Comp RequireComponent<Comp>(string nodePath) where Comp : Component
        {
            return UnityUtils.RequireComponent<Comp>(FindGameObject(nodePath));
        }

        public Comp RequireComponent<Comp>(GameObject go) where Comp : Component
        {
            return UnityUtils.RequireComponent<Comp>(go);
        }

        public void AddButtonEvent(Button btn, UnityAction callBack)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(callBack);
        }
    }
}
