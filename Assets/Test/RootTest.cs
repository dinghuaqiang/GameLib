using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Networking;
using UnityEngine.Playables;

namespace Assets.Test
{
    public class RootTest : MonoBehaviour
    {
        //用于获取射线的点的信息，rayHit获取完毕
        RaycastHit hit;
        Camera _mainCamera = null;
        private Transform _cube = null;
        private void Awake()
        {
            _mainCamera = Camera.main;
            _cube = transform.Find("Cube");
            Debug.Log(ColorUtility.ToHtmlStringRGB(Color.red));
            _mainCamera.AddCommandBuffer(UnityEngine.Rendering.CameraEvent.BeforeFinalPass, new UnityEngine.Rendering.CommandBuffer());
            Graphics.ExecuteCommandBuffer(new UnityEngine.Rendering.CommandBuffer());
        }

        private void Update()
        {
            //用于获取鼠标在世界坐标中的位置（屏幕坐标），ray获取完毕
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(_cube.transform.position, hit.transform.position);
                Debug.DrawRay(_cube.transform.position, hit.transform.position);
                _cube.LookAt(hit.transform.position);
            }
        }

        private void OnDestroy()
        {
            
        }
    }
}
