using GameLib.Core.Event;
using UnityEngine;

/// <summary>
/// 挂接事件系统的脚本
/// </summary>
public class EventRootScript : MonoBehaviour
{
    private static EventRootScript _me;
    private static EventManager _manager;
    internal static void Create(EventManager manager)
    {
        _manager = manager;
        if (_me == null)
        {
            var go = new GameObject("[EventRoot]");
            _me = go.AddComponent<EventRootScript>();
            DontDestroyOnLoad(go);
        }
    }


    private void Update()
    {
        if (_manager != null)
        {
            _manager.Update();
        }
    }

    private void OnDestroy()
    {
        _manager = null;
        _me = null;
    }
}
