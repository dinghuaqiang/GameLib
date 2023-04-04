using GameLib.Core.Asset;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadUITest : MonoBehaviour
{
    private string Root = "Assets/GameAssets/Resources/Default/UIRoot/UICanvas.prefab";
    private string PrefabPath = "Assets/GameAssets/Resources/GameUI/UIMainForm/Prefabs/UIMainForm.prefab";
    private Transform _rootTrans = null;
    private GameObject _thisGo = null;
    void Start()
    {
        AssetLoadManager.Instance.LoadAssetAsync(Root, OnLoadRootFinish);
    }

    private void OnLoadRootFinish(Object go)
    {
        if (go != null)
        {
            _rootTrans = Instantiate<GameObject>(go as GameObject).transform;
            AssetLoadManager.Instance.LoadAssetAsync(PrefabPath, OnLoadFinish);
        }
    }

    private void OnLoadFinish(Object go)
    {
        if (go != null)
        {
            if (_rootTrans != null)
            {
                Transform canvasTrans = _rootTrans.Find("Canvas");
                _thisGo = Instantiate(go as GameObject);
                RectTransform rectTransform = _thisGo.GetComponent<RectTransform>();
                Transform trans = _thisGo.GetComponent<Transform>();
                rectTransform.SetParent(canvasTrans);
                //设置RectTransform的postion（x,y,z）
                rectTransform.anchoredPosition3D = Vector3.zero;
                //设置缩放
                rectTransform.localScale = Vector3.one;
                //设置旋转
                rectTransform.localRotation = Quaternion.identity;

                //设置锚点位置
                //rectTransform.anchoredPosition = new Vector2(50, 50);
                //设置宽高 sizeDelta就是offsetMax - offsetMin的值，即物体左下角到右上角的变量
                //rectTransform.sizeDelta = new Vector2(1280,720);

                //offsetMin ： 对应Left、Bottom
                rectTransform.offsetMin = Vector2.zero;
                //offsetMax ： 对应Right、Top
                rectTransform.offsetMax = Vector2.zero;
            }
        }
    }

    private void OnDestroy()
    {
        if (_thisGo != null)
        {
            DestroyImmediate(_thisGo);
        }
    }
}
