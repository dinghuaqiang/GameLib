using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameLib.Core.Utils
{
    /// <summary>
    /// Unity的工具函数集合
    /// </summary>
    [ExecuteAlways]
    public class UnityUtils
    {
        public static GameObject ResetTransform(GameObject go)
        {
            Reset(go.transform);
            return go;
        }

        public static void CopyTransform(Transform from, Transform to)
        {
            to.parent = from.parent;
            to.localPosition = from.localPosition;
            to.localRotation = from.localRotation;
            to.localScale = from.localScale;
        }

        public static void CopyTransformSRT(Transform from, Transform to)
        {
            to.position = from.position;
            to.rotation = from.rotation;
            to.localScale = from.localScale;
        }

        public static Transform Reset(Transform trans)
        {
            trans.localScale = Vector3.one;
            trans.localRotation = Quaternion.identity;
            trans.localPosition = Vector3.zero;
            return trans;
        }

        public static Transform RequireChildTransform(Transform parent, string childName)
        {
            var ret = parent.Find(childName);
            if (ret == null)
            {
                var go = new GameObject(childName);
                go.transform.parent = parent;
                ret = go.transform;
            }
            return ret;
        }

        public static T RequireComponent<T>(GameObject go) where T : Component
        {
            T ret = go.GetComponent<T>();
            if (ret == null)
            {
                ret = go.AddComponent<T>();
            }
            return ret;
        }

        public static T RequireComponent<T>(GameObject go, out bool isNew) where T : Component
        {
            T ret = go.GetComponent<T>();
            if (ret == null)
            {
                isNew = true;
                ret = go.AddComponent<T>();
            }
            else
            {
                isNew = false;
            }
            return ret;
        }

        public static Transform GetChildByName(Transform parentTran, string childName)
        {
            for (int i = 0; i < parentTran.childCount; i++)
            {
                Transform childTran = parentTran.GetChild(i);
                if (childTran.name.Contains(childName))
                {
                    return childTran;
                }
            }
            return null;
        }

        public static Transform FindParent(Transform current, Transform targetParent)
        {
            while (current != null && current != targetParent)
            {
                current = current.parent;
            }
            return current;
        }

        public static GameObject AddChild(GameObject parent)
        {
            GameObject go = new GameObject();
            if (parent != null)
            {
                Transform t = go.transform;
                SetLayer(go.transform, parent.layer,true);
                t.parent = parent.transform;
                t.localPosition = Vector3.zero;
                t.localRotation = Quaternion.identity;
                t.localScale = Vector3.one;
            }
            return go;
        }

        public static bool CheckChild(Transform parent, Transform child)
        {
            return null != FindParent(child.parent, parent);
        }

        public static string GetTransPath(Transform trans)
        {
            var sb = StringUtils.NewStringBuilder;
            sb.Append(trans.name);
            var p = trans.parent;
            while (p != null)
            {
                sb.Insert(0, '/');
                sb.Insert(0, p.name);
                p = p.parent;
            }
            return sb.ToString();
        }

        public static string GetTransPathFrom(Transform trans, Transform from)
        {
            var sb = StringUtils.NewStringBuilder;
            sb.Append(trans.name);
            var p = trans.parent;
            while (p != null)
            {
                if (p == from)
                {
                    break;
                }
                sb.Insert(0, '/');
                sb.Insert(0, p.name);
                p = p.parent;
            }
            return sb.ToString();
        }

        public static int GetHierarchyDepthFrom(Transform trans, Transform from)
        {
            int count = 0;
            var p = trans.parent;
            while (p != null)
            {
                if (p == from)
                {
                    return count;
                }
                ++count;
                p = p.parent;
            }
            return -1;
        }

        public static Transform Find(string path)
        {
            Transform cur = null;
            var seg = path.Split('\\', '/');
            if (seg.Length > 0)
            {
                var go = GameObject.Find(seg[0]);
                if (go != null)
                {
                    cur = go.transform;
                    for (int i = 1; i < seg.Length && cur != null; ++i)
                    {
                        var t = cur;
                        cur = null;
                        for (int j = 0; j < t.childCount; ++j)
                        {
                            var c = t.GetChild(j);
                            if (c.name == seg[i])
                            {
                                cur = c;
                                break;
                            }
                        }
                    }
                }
            }
            return cur;
        }

        static List<Component> _GetComponentsInChildren(Transform trans, Type t, int depth, ref List<Component> ret)
        {
            var c = trans.GetComponents(t);
            for (int i = 0; i < c.Length; ++i)
            {
                ret.Add(c[i]);
            }
            if (c == null && depth > 0)
            {
                for (int i = 0; i < trans.childCount; ++i)
                {
                    _GetComponentsInChildren(trans.GetChild(i), t, depth - 1, ref ret);
                }
            }
            return ret;
        }

        static Component _GetComponentInChildren(Transform trans, Type t, int depth)
        {
            var c = trans.GetComponent(t);
            if (c == null && depth > 0)
            {
                for (int i = 0; i < trans.childCount; ++i)
                {
                    var child = trans.GetChild(i);
                    c = child.GetComponent(t) ?? _GetComponentInChildren(child, t, depth - 1);
                    if (c != null)
                    {
                        break;
                    }
                }
            }
            return c;
        }

        public static T[] GetComponentsInChildren<T>(Transform trans, int depth = int.MaxValue) where T : Component
        {
            if (depth < 0)
            {
                depth = int.MaxValue;
            }
            List<Component> _ret = new List<Component>();
            _GetComponentsInChildren(trans, typeof(T), depth, ref _ret);
            var ret = new T[_ret.Count];
            for (int i = 0; i < _ret.Count; ++i)
            {
                ret[i] = _ret[i] as T;
            }
            return ret;
        }

        public static T GetComponentInChildren<T>(Transform trans, int depth = int.MaxValue) where T : Component
        {
            if (depth < 0)
            {
                depth = int.MaxValue;
            }
            var ret = _GetComponentInChildren(trans, typeof(T), depth);
            return ret as T;
        }

        static T _GetComponentInChildren_IgnoreActiveStatus<T>(Transform trans) where T : Component
        {
            var r = trans.GetComponent<T>();
            if (r == null)
            {
                for (int i = 0; i < trans.childCount && r == null; ++i)
                {
                    r = _GetComponentInChildren_IgnoreActiveStatus<T>(trans.GetChild(i));
                }
            }
            return r;
        }

        public static T GetComponentInChildren_IgnoreActiveStatus<T>(Transform trans) where T : Component
        {
            if (trans == null)
            {
                return null;
            }
            var r = trans.GetComponent<T>();
            if (r == null)
            {
                for (int i = 0; i < trans.childCount && r == null; ++i)
                {
                    r = _GetComponentInChildren_IgnoreActiveStatus<T>(trans.GetChild(i));
                }
            }
            return r;
        }

        /// return parent which its name contains string specified
        public static Transform GetParentTransform(Transform trans, string parentName)
        {
            if (trans != null)
            {
                while (!trans.name.Contains(parentName))
                {
                    trans = trans.parent;
                }
                return trans;
            }
            return null;
        }

        public static int GetLayerMask(params string[] layers)
        {
            int mask = 0;
            for (int i = 0; i < layers.Length; ++i)
            {
                mask |= (1 << LayerMask.NameToLayer(layers[i]));
            }
            return mask;
        }

        //判断LayerMask是否包含指定的layer
        public bool ContainsLayer(LayerMask mask, int layer)
        {
            return ((1 << layer) & mask.value) != 0;
        }

        private int EnableLayer(string layerName)
        {
            return 1 << LayerMask.NameToLayer(layerName);
        }

        //只开启对应的层
        private int EnableLayers(params string[] layerNames)
        {
            int layer = 0;
            for (int i = 0; i < layerNames.Length; i++)
            {
                int curLayer = LayerMask.NameToLayer(layerNames[i]);
                layer ^= 1 << curLayer;
            }
            return layer;
        }

        private int DisableLayer(string layerName)
        {
            int layer = 0;
            layer |= ~(1 << LayerMask.NameToLayer(layerName));
            return layer;
        }

        public static void SetLayer(Transform trans, int layer, bool recursive = false)
        {
            if (trans == null)
            {
                return;
            }
            trans.gameObject.layer = layer;
            if (recursive)
            {
                var list = trans.GetComponentsInChildren<Transform>(true);
                for (int i = 0; i < list.Length; i++)
                {
                    list[i].gameObject.layer = layer;
                }               
            }
        }

        public static void FindAllChildContainsString(Transform parent, string contains, List<Transform> result)
        {
            if (result == null || parent.childCount == 0)
            {
                return;
            }
            else
            {
                string containsLower = contains.ToLower();
                for (int i = 0; i < parent.childCount; i++)
                {
                    var child = parent.GetChild(i);
                    if (child.name.ToLower().Contains(containsLower) && child.gameObject.activeInHierarchy == true)
                    {
                        result.Add(child);
                    }
                    else
                    {
                        FindAllChildContainsString(child, containsLower, result);
                    }
                }
            }
        }

        public static Transform FindChildContainsString(Transform parent, string contains)
        {
            Transform result = null;
            string containsLower = contains.ToLower();
            if (parent.childCount == 0)
            {
                result = null;
            }
            else
            {
                for (int i = 0; i < parent.childCount; i++)
                {
                    var child = parent.GetChild(i);
                    if (child.name.ToLower().Contains(containsLower) && child.gameObject.activeInHierarchy == true)
                    {
                        result = child;
                    }
                    else
                    {
                        result = FindChildContainsString(child, containsLower);
                    }
                    if (result != null)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        public static Transform FindChildContainsStringWithBoxCollider(Transform parent, string contains)
        {
            string containLower = contains.ToLower();
            Transform result = null;
            if (parent.childCount == 0)
            {
                result = null;
            }
            else
            {
                for (int i = 0; i < parent.childCount; i++)
                {
                    var child = parent.GetChild(i);
                    if (child.name.ToLower().Contains(containLower) && child.gameObject.activeInHierarchy == true && child.GetComponent<BoxCollider>() != null)
                    {
                        result = child;
                    }
                    else
                    {
                        result = FindChildContainsStringWithBoxCollider(child, containLower);
                    }
                    if (result != null)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        public static T GetNearestComponentFromParents<T>(GameObject child) where T : Component
        {
            if (child != null)
            {
                Transform obj = child.transform;
                while (obj.parent != null)
                {
                    var component = obj.GetComponent<T>();
                    if (component != null)
                    {
                        return component;
                    }
                    obj = obj.transform.parent;
                }
            }
            return null;
        }

        public static List<T> GetAllComponentsFromParents<T>(GameObject child) where T : Component
        {
            if (child != null)
            {
                var result = new List<T>();
                Transform obj = child.transform;
                while (obj.parent != null)
                {
                    var com = obj.GetComponent<T>();
                    if (com != null)
                    {
                        result.Add(com);
                    }
                    obj = obj.transform.parent;
                }
                return result;
            }
            return null;
        }

        /// <summary>
        /// 移除某组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="go"></param>
        public static void RemoveComponet<T>(GameObject go)
             where T : Component
        {
            var cl = go.GetComponent<T>();
            if (cl != null)
            {
                // remove audio listener if only
#if UNITY_EDITOR
                GameObject.DestroyImmediate(cl);
#else
                GameObject.Destroy(cl);
#endif
            }
        }

        /// <summary>
        /// 点是否在一个指定的区域内
        /// </summary>
        /// <param name="point">点的坐标</param>
        /// <param name="field">范围坐标。顺序是左下，左上， 右上，右下</param>
        /// <returns></returns>
        public static bool IsPointInField2D(Vector3 point, Vector3[] field)
        {
            float minX = field[0].x;
            float maxX = field[3].x;
            float minY = field[0].y;
            float maxY = field[1].y;
            return (minX <= point.x) && (maxX >= point.x) && (minY <= point.y) && (maxY >= point.y);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool IsFieldAInFieldB2D(Vector3[] a, Vector3[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (!IsPointInField2D(a[i], b))
                {
                    return false;
                }
            }
            return true;
        }

        public static List<int> DecimalNumDecompse(int num)
        {
            int b = 1;
            int index = 0;
            List<int> result = new List<int>();
            while (num != 0)
            {
                int temp = num & b;
                if (temp == 1)
                {
                    result.Add(index);
                }
                num = num >> 1;
                index++;
            }

            for (int i = 0; i < result.Count; i++)
            {
                result[i] = (int)Math.Pow(2, result[i]);
            }
            return result;
        }

        public static void SetGameObjectActive(Transform tran, bool isActive)
        {
            if (tran != null)
            {
                tran.gameObject.SetActive(isActive);
            }
        }

        //获取在最外层时的大小
        public static Vector3 GetWorldScale(Transform tran)
        {
            if (tran == null) return Vector3.one;

            Vector3 scale = tran.localScale;
            while (tran.parent != null)
            {
                tran = tran.parent;
                scale = Vector3.Scale(scale, tran.localScale);
            }
            return scale;
        }

        //查找当前场景中的根节点
        public static GameObject FindSceneRoot(string name)
        {
            var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            if (!string.IsNullOrEmpty(scene.name))
            {
                var roots = scene.GetRootGameObjects();
                for (int i = 0; i < roots.Length; i++)
                {
                    if (string.Equals(roots[i].name.Trim(), name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return roots[i];
                    }
                }
            }            
            return null;
        }

        //复制摄像机的属性
        public static void CopyCameraProperty(Camera source, Camera target, int excludeLayer = 0)
        {
            if (source != null && target != null)
            {
                target.CopyFrom(source);
                target.cullingMask = source.cullingMask & (~(1 << excludeLayer));
                target.transform.position = source.transform.position;
                target.transform.rotation = source.transform.rotation;
                target.Render();
            }
        }

        //更新摄像机的工作模式
        public static void UpdateCameraModes(Camera src, Camera dest)
        {
            if (dest == null)
            {
                return;
            }
            // set water camera to clear the same way as current camera
            dest.clearFlags = src.clearFlags;
            dest.backgroundColor = src.backgroundColor;
            /*
            if (src.clearFlags == CameraClearFlags.Skybox)
            {
                Skybox sky = src.GetComponent<Skybox>();
                Skybox mysky = dest.GetComponent<Skybox>();
                if (!sky || !sky.material)
                {
                    mysky.enabled = false;
                }
                else
                {
                    mysky.enabled = true;
                    mysky.material = sky.material;
                }
            } */
            // update other values to match current camera.
            // even if we are supplying custom camera&projection matrices,
            // some of values are used elsewhere (e.g. skybox uses far plane)
            dest.farClipPlane = src.farClipPlane;
            dest.nearClipPlane = src.nearClipPlane;
            dest.orthographic = src.orthographic;
            dest.fieldOfView = src.fieldOfView;
            dest.aspect = src.aspect;
            dest.orthographicSize = src.orthographicSize;
        }

        /// <summary>
        /// 获取某个MonoBehaviour
        /// </summary>
        /// <param name="go"></param>
        /// <param name="name"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static MonoBehaviour GetMonoBehaviour(GameObject go,string name,bool ignoreCase = false)
        {
            var allComps = go.GetComponents<MonoBehaviour>();
            for (int i = 0; i < allComps.Length; i++)
            {
                if (allComps[i] != null)
                {
                    var t = allComps[i].GetType();
                    if (string.Compare(t.Name,name,ignoreCase)==0)
                    {
                        return allComps[i];
                    }
                }
            }
            return null;
        }
    }
}