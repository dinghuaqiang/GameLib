using UnityEngine;

/// <summary>
/// 摄像机调整脚本.
/// </summary>
[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
    //当前摄像机
    public Camera CurCamera;
    public Transform Target;

    /**
     * https://zhuanlan.zhihu.com/p/453251884
     * https://learnopengl-cn.github.io/01%20Getting%20started/09%20Camera/
     * 欧拉角(Euler Angle)是可以表示3D空间中任何旋转的3个值，由莱昂哈德·欧拉(Leonhard Euler)在18世纪提出。
     * 一共有3种欧拉角：俯仰角(Pitch)、偏航角(Yaw)、滚转角(Roll)
     * 俯仰角是描述我们如何往上或往下看的角
     * 偏航角表示我们往左和往右看的程度
     * 对于摄像机系统来说，只关心俯仰角和偏航角，不会讨论滚转角。给定一个俯仰角和偏航角，可以把它们转换为一个代表新的方向向量的3D向量。
     */
    //当前pitch 俯仰角，上下看
    public float CurPitch = 30f;
    //当前yaw 偏航角，左右看
    public float CurYaw = 135f;

    //当前跟随距离
    public float CurDis = 20f;
    //当前Y轴偏移量
    public float CurOffsetY = 2.5f;
    //当前X轴偏移量
    public float CurOffsetX = 0f;
    //当前fov
    public float CurFov = 35;

    //是否同步
    public bool IsSyncView = false;

    // Start is called before the first frame update
    void Start()
    {
        if (CurCamera == null)
        {
            var cams = GetComponentsInChildren<Camera>();
            if (cams != null && cams.Length > 0)
            {
                CurCamera = cams[0];
            }
            else
            {
                //找不到相机就创建一个相机
                var camGo = new GameObject("GameCamera");
                camGo.transform.parent = transform;
                camGo.transform.localPosition = Vector3.zero;
                camGo.transform.localScale = Vector3.one;
                camGo.transform.localEulerAngles = Vector3.zero;
                CurCamera = camGo.AddComponent<Camera>();
            }
            //让它最高
            CurCamera.depth = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (CurCamera != null)
        {            
            var CameraTrans = CurCamera.transform;
            var TargetTrans = Target;
            if (TargetTrans == null)
            {
                TargetTrans = transform;
            }

            /**
             加个显示，确保不会倒着看
             对于俯仰角，要让用户不能看向高于89度的地方（在90度时视角会发生逆转，所以我们把89度作为极限），同样也不允许小于-89度。
             这样能够保证用户只能看到天空或脚下，但是不能超越这个限制。
             https://learnopengl-cn.github.io/01%20Getting%20started/09%20Camera/
             */
            if (CurPitch < -89f) CurPitch = -89f;
            if (CurPitch > 89f) CurPitch = 89f;

            //计算目标偏移量
            var targetPos = TargetTrans.position + Vector3.up * CurOffsetY;
            //根据俯仰角度和偏航角度设置旋转值
            Quaternion cameraRotation = Quaternion.Euler(CurPitch, CurYaw, 0f);
            //用目标位置，这里使用目标位置减去相机距离目标的距离 
            var cameraPos = targetPos - cameraRotation * Vector3.forward * CurDis;
            if (CurOffsetX != 0)
            {
                var dir = (TargetTrans.position - cameraPos);
                dir.y = 0;
                //围绕y轴旋转90°,得到旋转之后的坐标点
                dir = Quaternion.AngleAxis(90, Vector3.up) * dir;
                //对方向进行归一化，用作后续计算在哪个方向移动多少距离
                dir = dir.normalized;
                //得到目标位置  这里主要是加上方向和初始偏移量的距离
                targetPos = targetPos + dir * CurOffsetX;
                //目得到相机的当前位置， 这里使用目标位置减去相机距离目标的距离 
                cameraPos = targetPos - cameraRotation * Vector3.forward * CurDis;
            }

            //设置Fov
            CurCamera.fieldOfView = CurFov;
            //设置相机的位置和旋转
            CameraTrans.position = cameraPos;
            CameraTrans.rotation = cameraRotation;
        }
    }

#if UNITY_EDITOR
    private void LateUpdate()
    {
        if (IsSyncView && CurCamera != null)
        {
            var v = UnityEditor.SceneView.lastActiveSceneView;
            if (v != null)
            {
                v.AlignViewToObject(CurCamera.transform);
            }
        }
    }
#endif
}
