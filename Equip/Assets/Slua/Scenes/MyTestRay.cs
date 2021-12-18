using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MyTestRay : MonoBehaviour {

    List<RaycastResult> list;

    void Start()
    {
        list = new List<RaycastResult>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject obj = GetFirstPickGameObject(Input.mousePosition);
            Debug.Log(obj);
        }
    }

    public GameObject GetFirstPickGameObject(Vector2 position)
    {
        EventSystem eventSystem = EventSystem.current;
        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = position;
        //射线检测ui
        List<RaycastResult> uiRaycastResultCache = new List<RaycastResult>();
        eventSystem.RaycastAll(pointerEventData, uiRaycastResultCache);
        if (uiRaycastResultCache.Count > 0)
            return uiRaycastResultCache[0].gameObject;
        return null;
    }
}
