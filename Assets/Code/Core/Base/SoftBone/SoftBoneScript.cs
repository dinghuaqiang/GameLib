using GameLib.Core.Base.Support;
using GameLib.Core.Utils;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Core.Base
{
    //柔体骨骼脚本
    public class SoftBoneScript : MonoBehaviour
    {
        #region//静态变量
        //品质，3级表示全部柔化，2级表示只柔化主角，1级表示不柔化
        public static int QualityLevel = 3;
        #endregion

        #region//私有变量
        private Transform _transformInst = null;
        private GameObject _gameObjectInst = null;
        //上一帧的位置
        private Vector3 _prePos = Vector3.zero;
        //上一帧的旋转
        private Quaternion _preRot = Quaternion.identity;
        //柔体禁用计时器，当位移和旋转停止时进行倒计时
        private float _stopTimer = 0f;
        #endregion

        #region//脚本数据
        //根节点，用于判断是否执行柔体效果
        [HideInInspector] [SerializeField] Transform _rootTrans = null;
        //节点列表
        [HideInInspector] [SerializeField] List<Particle> _partList = null;
        //位移时执行柔体效果
        [HideInInspector] [SerializeField] public bool MoveExecute = true;
        //旋转时执行柔体效果
        [HideInInspector] [SerializeField] public bool RotExecute = true;
        //柔软因子开始值,用于编辑时生成
        [HideInInspector] [SerializeField] public float _factorStart = 0.3f;
        //柔软因子结束值,用于编辑时生成
        [HideInInspector] [SerializeField] public float _factorEnd = 0.9f;
        //角度因子开始值,用于编辑时生成
        [HideInInspector] [SerializeField] public float _angleStart = 10f;
        //角度因子结束值,用于编辑时生成
        [HideInInspector] [SerializeField] public float _angleEnd = 20f;
        //柔体结束同步时间
        [HideInInspector] [SerializeField] public float _stopMaxTime = 3f;
        #endregion

        #region//属性
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
        public List<Particle> PartList
        {
            get
            {
                return _partList;
            }
        }
        #endregion


        #region//私有函数
        private void OnEnable()
        {
            //同步位置
            for (int i = 0; i < _partList.Count; ++i)
            {
                var p = _partList[i];
                p.DstTrans.localPosition = p.OriPos;
                p.DstTrans.localRotation = p.OriRot;
                p.PrePos = p.DstTrans.position;
            }
            _prePos = _rootTrans.position;
            _preRot = _rootTrans.rotation;
            _stopTimer = 0f;
        }
        private void OnDisable()
        {
            //同步位置
            for (int i = 0; i < _partList.Count; ++i)
            {
                var p = _partList[i];
                p.DstTrans.localPosition = p.OriPos;
                p.DstTrans.localRotation = p.OriRot;
                p.PrePos = p.DstTrans.position;
            }
        }
        //软化同步骨骼
        private void SoftSyncParticle(Particle p, float lerpValue, float frameRate)
        {
            if (p == null || p.DstTrans == null)
                return;
            var pTrans = p.DstTrans;
            var parentTrans = p.DstTrans.parent;
            if (parentTrans == null) //数据错误
            {
                p.PrePos = pTrans.position;
                return;
            }
            //当前动画给定的位置
            float fixFactor = Mathf.Lerp(1f, p.Factor, frameRate) * lerpValue; ;
            if (fixFactor <= 0)
            {
                p.PrePos = pTrans.position;
                return;
            }
            if (p.MaxRotAngle <= 0)
            {
                p.PrePos = pTrans.position;
                return;
            }
            var maxAngle = p.MaxRotAngle * (frameRate / frameRate);
            var parentPos = parentTrans.position;
            var prePos = p.PrePos;
            var oriPos = p.DstTrans.position;
            var newPos = Vector3.Lerp(oriPos, prePos, fixFactor);
            var oriDis = Vector3.Distance(oriPos, parentPos);
            var newDis = Vector3.Distance(newPos, parentPos);
            var oriDir = (oriPos - parentPos).normalized;
            var newDir = (newPos - parentPos).normalized;
            var rotAngle = Vector3.Angle(newDir, oriDir);
            if (rotAngle > maxAngle)
            {
                newDir = Vector3.Slerp(oriDir, newDir, maxAngle / rotAngle).normalized;
            }
            if (newDis < oriDis * (1f - p.DisMultiple))
            {
                //超过限定距离
                newPos = parentPos + newDir * (oriDis * (1f - p.DisMultiple));
            }
            else if (newDis > oriDis * (1f + p.DisMultiple))
            {
                //超过限定距离
                newPos = parentPos + newDir * (oriDis * (1f + p.DisMultiple));
            }
            else if (rotAngle > maxAngle)
            {
                newPos = parentPos + newDir * newDis;
            }
            p.DstTrans.rotation = Quaternion.FromToRotation(oriDir, newDir) * p.DstTrans.rotation;
            p.DstTrans.position = newPos;
            p.PrePos = newPos;
        }

        void Update()
        {
            //同步位置
            for (int i = 0; i < _partList.Count; ++i)
            {
                var p = _partList[i];
                p.DstTrans.localPosition = p.OriPos;
                p.DstTrans.localRotation = p.OriRot;
            }
        }

        private void LateUpdate()
        {
            if (_partList == null)
            {
                return;
            }
            var isEnable = false;
            switch (QualityLevel)
            {
                case 3:
                    isEnable = true;
                    break;
                case 2:
                    {
                        var layer = GameObjectInst.layer;
                        isEnable = layer == LayerUtils.LocalPlayer || layer == LayerUtils.AresUI || layer == LayerUtils.UITop || layer == LayerUtils.UIStory;
                    }
                    break;
            }
            var syncPrePos = true;
            if (isEnable)
            {
                _stopTimer -= Time.deltaTime;
                var dis = 0f;
                if (MoveExecute)
                {
                    dis = Vector3.SqrMagnitude(_prePos - _rootTrans.position) * _rootTrans.lossyScale.x;
                }
                var angle = 0f;
                if (RotExecute)
                {
                    angle = Quaternion.Angle(_preRot, _rootTrans.rotation);
                }
                var frameRate = 1f;
                if (FrameMonitor.RealFPS > 0)
                {
                    frameRate = 30f / FrameMonitor.RealFPS;
                }
                if (frameRate > 1f)
                {
                    frameRate = 1f;
                }
                var disLimit = 0.04f * frameRate;
                var andLimit = 5f * frameRate;
                if (dis >= disLimit || angle >= andLimit)
                {
                    for (int i = 0; i < _partList.Count; ++i)
                    {
                        SoftSyncParticle(_partList[i], 1f, frameRate);
                    }
                    _stopTimer = _stopMaxTime;
                    syncPrePos = false;
                }
                else if (_stopTimer >= 0f)
                {
                    for (int i = 0; i < _partList.Count; ++i)
                    {
                        SoftSyncParticle(_partList[i], _stopTimer / _stopMaxTime, frameRate);
                    }
                    syncPrePos = false;
                }
            }
            if (syncPrePos)
            {
                for (int i = 0; i < _partList.Count; ++i)
                {
                    var p = _partList[i];
                    p.PrePos = p.DstTrans.position;
                }
            }
            _prePos = _rootTrans.position;
            _preRot = _rootTrans.rotation;
        }
        #endregion

        #region//编辑器函数
#if UNITY_EDITOR
        public void BuildParticle()
        {
            //先查找根节点
            var parentTrans = TransformInst;
            var finded = false;
            while (parentTrans != null)
            {
                if (UnityEditor.PrefabUtility.IsAnyPrefabInstanceRoot(parentTrans.gameObject))
                {
                    finded = true;
                    break;
                }
                parentTrans = parentTrans.parent;
            }
            if (!finded)
            {
                UnityEngine.Debug.LogError("生成失败，没有查找到预制根节点");
                return;
            }
            //查找所属skinmeshrender
            var skins = parentTrans.GetComponentsInChildren<SkinnedMeshRenderer>(true);
            SkinnedMeshRenderer ownerSkin = null;
            if (skins != null)
            {
                for (int i = 0; i < skins.Length; ++i)
                {
                    for (int j = 0; j < skins[i].bones.Length; ++j)
                    {
                        if (skins[i].bones[j].IsChildOf(TransformInst))
                        {
                            ownerSkin = skins[i];
                            break;
                        }
                    }
                    if (ownerSkin != null)
                    {
                        break;
                    }
                }
            }
            if (ownerSkin == null)
            {
                UnityEngine.Debug.LogError("生成失败，没有查找到骨骼所属SkinnedMeshRenderer");
                return;
            }
            _rootTrans = parentTrans;
            //缓存骨骼节点，用于判断是否时骨骼
            var tmpDic = new Dictionary<Transform, bool>();
            for (int i = 0; i < ownerSkin.bones.Length; ++i)
            {
                tmpDic.Add(ownerSkin.bones[i], true);
            }
            tmpDic[TransformInst] = true;
            Utility.Hierarchy.WalkHierarchy(TransformInst, t =>
            {
                if (!tmpDic.ContainsKey(t))
                {
                    //判断是否是骨骼的父节点
                    var isParent = false;
                    var iter = tmpDic.GetEnumerator();
                    while (iter.MoveNext())
                    {
                        if (iter.Current.Key.IsChildOf(t))
                        {
                            isParent = true;
                            break;
                        }
                    }
                    if (isParent)
                    {
                        tmpDic.Add(t, true);
                    }
                }
                return true;
            });
            //生成骨骼列表
            _partList = new List<Particle>();
            var tmpParDic = new Dictionary<Transform, Particle>();
            Utility.Hierarchy.WalkHierarchy(TransformInst, t =>
            {
                if (tmpDic.ContainsKey(t))
                {
                    //判断是否是骨骼
                    var p = new Particle();
                    p.DstTrans = t;
                    var depth = 0;
                    var parent = t;
                    while (parent != TransformInst)
                    {
                        parent = parent.parent;
                        ++depth;
                    }
                    p.Depth = depth;
                    p.OriPos = p.DstTrans.localPosition;
                    p.OriRot = p.DstTrans.localRotation;
                    _partList.Add(p);
                    tmpParDic[t] = p;
                }
                return true;
            });
            var boneParsList = new List<List<Particle>>();
            for (int i = 0; i < _partList.Count; ++i)
            {
                var par = _partList[i];
                var isEnd = true;
                for (int j = 0; j < par.DstTrans.childCount; ++j)
                {
                    if (tmpParDic.ContainsKey(par.DstTrans.GetChild(j)))
                    {
                        isEnd = false;
                        break;
                    }
                }
                if (isEnd)
                {
                    var listTmp = new List<Particle>();
                    listTmp.Add(par);
                    boneParsList.Add(listTmp);
                }
            }
            for (int i = 0; i < boneParsList.Count; ++i)
            {
                //查找这一排骨骼的所有节点
                var listTmp = boneParsList[i];
                var tmpParent = listTmp[0].DstTrans.parent;
                var frontPos = listTmp[0].DstTrans.position;
                var allDis = 0f;
                while (tmpParDic.ContainsKey(tmpParent))
                {
                    listTmp.Add(tmpParDic[tmpParent]);
                    allDis += Vector3.Distance(tmpParent.position, frontPos);
                    frontPos = tmpParent.position;
                    tmpParent = tmpParent.parent;
                }
                var tmpDis = 0f;
                for (int j = listTmp.Count - 1; j >= 0; --j)
                {
                    var curDis = 0f;
                    if (j > 0)
                    {
                        curDis = Vector3.Distance(listTmp[j].DstTrans.position, listTmp[j - 1].DstTrans.position);
                    }
                    if (listTmp[j].DstTrans == TransformInst)
                    {
                        listTmp[j].Factor = 0f;
                        listTmp[j].MaxRotAngle = 0f;
                    }
                    else
                    {
                        var lerpValue = (tmpDis + curDis / 2f) / allDis;
                        listTmp[j].Factor = Mathf.Lerp(_factorStart, _factorEnd, lerpValue);
                        listTmp[j].MaxRotAngle = Mathf.Lerp(_angleStart, _angleEnd, lerpValue);
                    }
                    tmpDis += curDis;
                }
            }
            UnityEditor.EditorUtility.SetDirty(this);
            UnityEditor.EditorUtility.SetDirty(GameObjectInst);
        }

        private void OnDrawGizmos()
        {
            if (_partList != null)
            {
                Gizmos.color = Color.green;
                for (int i = 0; i < _partList.Count; ++i)
                {
                    var trans = _partList[i].DstTrans;
                    var parent = trans.parent;
                    if (parent != null)
                    {
                        Gizmos.DrawLine(parent.position, trans.position);
                    }
                    Gizmos.DrawSphere(trans.position, 0.05f);
                }
                Gizmos.color = Color.white;
            }
        }
#endif
        #endregion

        #region//私有类
        [System.Serializable]
        public class Particle
        {
            #region//运行时变量
            [NonSerialized]
            public Vector3 PrePos = Vector3.zero; //上一帧位置
            #endregion

            #region//脚本变量
            [SerializeField]
            public Transform DstTrans = null; //目标trans
            [SerializeField]
            [Range(0, 1.0f)]
            public float Factor = 0.9f; //柔软度0到1
            [SerializeField]
            [Range(0f, 1f)]
            public float DisMultiple = 0f; //延展和收缩倍数
            [SerializeField]
            [Range(0f, 360f)]
            public float MaxRotAngle = 50f; //最大旋转角度
            [SerializeField]
            public int Depth = 0;
            [SerializeField]
            public Vector3 OriPos = Vector3.zero; //原始位置
            [SerializeField]
            public Quaternion OriRot = Quaternion.identity; //原始旋转
            #endregion
        }
        #endregion
    }
}
