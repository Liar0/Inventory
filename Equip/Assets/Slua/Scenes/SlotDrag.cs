using SLua;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


[CustomLuaClass]
public class SlotDrag : MonoBehaviour/*,ICanvasRaycastFilter*/,IBeginDragHandler,IEndDragHandler,IDragHandler{

    LuaSvr luaSvr;
    int process;
    static int yytt = 0;
    LuaTable slotDragTable;

    public static Action<PointerEventData> _onPointerDragStart;
    public static Action<PointerEventData> _onPointerDragEnd;
    public static Action<PointerEventData> _onPointerDrag;
    public static Func<bool> _onIsRaycast;
    
    
   
    LuaFunction func;

    public void OnBeginDrag(PointerEventData eventData)
    {

        //GameObject.Find("").GetComponent < Image >().sprite.name
        if (_onPointerDragStart != null)
        {
            _onPointerDragStart((eventData));
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        if (_onPointerDrag != null)
        {
            _onPointerDrag(eventData);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //eventData.position.x
        if (_onPointerDragEnd != null)
        {
            _onPointerDragEnd(eventData);
        }
    }

    public Transform GetLocalTrans()
    {
        return transform;
    }

    //public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    //{
    //    if (_onIsRaycast != null)
    //    {
    //        //Debug.Log("_isRaycast");
    //        return _onIsRaycast();
            
    //    }
    //    return true;
    //}
    public static GameObject GetFirstPickGameObject(Vector2 position)
    {
        EventSystem eventSystem = EventSystem.current;
        PointerEventData pointerEventData = new PointerEventData(eventSystem);
        pointerEventData.position = position;
        //射线检测ui
        List<RaycastResult> uiRaycastResultCache = new List<RaycastResult>();
        eventSystem.RaycastAll(pointerEventData, uiRaycastResultCache);
        if (uiRaycastResultCache.Count > 0)
        {
            //for(int i=0;i<uiRaycastResultCache.Count;i++)
              // Debug.Log("名字："+uiRaycastResultCache[i].gameObject.ToString());
            return uiRaycastResultCache[0].gameObject;
        }
            
        return null;
    }

    // Use this for initialization
    void Awake() {

        luaSvr = new LuaSvr();

        luaSvr.init(Tick, Complete);

    }
	
    
	// Update is called once per frame
	void Update () {
		
	}

    void Tick(int p)
    {
        process = p;
    }


    void Complete()
    {
        slotDragTable =(LuaTable)luaSvr.start("SlotDrag");
        func=(LuaFunction)slotDragTable["ttt"];
        //Debug.Log(func);
        //GameObject.Find("").ToString();
        ////dd=func.cast<_GetTransform>();
        //if (_GetTransform != null)
        //{
        //    _GetTransform(transform);

        //}
        //if (func != null)
        //{
        //    func.call(yytt);
        //    Debug.Log("TTTTTTTTTTTT");
        //}

        //func.Dispose();
    }

    //public Transform _GetTransform { get { return transform; } }

}
