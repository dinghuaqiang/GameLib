using UnityEngine;

namespace Code.Core.Utils
{
    /// <summary>
    /// Unity MONO的单例类实现
    /// </summary>
    public class UnitySingleton<SCRIPT> : MonoBehaviour where SCRIPT : Component 
    {
        private static SCRIPT _instance = null;

        public static SCRIPT Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = (SCRIPT)FindObjectOfType(typeof(SCRIPT));
                    if (_instance == null)
                    {
                        string goName = typeof(SCRIPT).Name;
                        GameObject targetGo = new GameObject(goName);
                        _instance = targetGo.AddComponent<SCRIPT>();
                        _instance.name = "[" + goName + "]";
                        //_instance.transform.parent = Root.node.transform;
                    }
                }
                return _instance;
            }
        }

        public void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name) && !gameObject.name.Equals(name))
            {
                gameObject.name = name;
            }
        }

        protected void Awake()
        {
            if (_instance != null && _instance.gameObject != gameObject)
            {
                Destroy(gameObject);
            }
            else if (_instance == null)
            {
                _instance = GetComponent<SCRIPT>();
            }
            OnInitialize();
        }

        public void Destory()
        {
            if (_instance != null)
            {
                Destroy(_instance.gameObject);
            }
            _instance = null;
        }

        protected void OnDestroy()
        {
            OnUninitialize();
            if (_instance != null && _instance.gameObject == gameObject)
            {
                _instance = null;
            }
        }

        protected virtual void OnInitialize() { }
        protected virtual void OnUninitialize() { }
    }
}
