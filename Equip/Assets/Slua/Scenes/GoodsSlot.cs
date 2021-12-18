using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLua;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;


[CustomLuaClass]
public class GoodsSlot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, ICanvasRaycastFilter
{

    LuaSvr luaSvr;
    Button bnt;
    LuaTable table;
    LuaFunction func;
    static Transform trans;

    //bool isRaycast = false;

    public static Action<PointerEventData> _onPointerDragStart;
    public static Action<PointerEventData> _onPointerDragEnd;
    public static Action<PointerEventData> _onPointerDrag;
    public static Func<bool> _onIsRaycast;
    public static Action<string> _inputClickKeyCode;



    //public void Get(string str,out Action<PointerEventData> action)
    //{
    //    action += ()typeof(Inventory).GetMethod(str);
    //}


    public void OnBeginDrag(PointerEventData eventData)
    {

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

            //Debug.Log(eventData.pointerDrag);
            _onPointerDragEnd(eventData);
        }


    }

    public static Vector2 ScreenToUGUIPosition(RectTransform transform, Vector2 screenPos)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform, screenPos, Camera.main, out pos);
        return pos;
    }

    // Use this for initialization
    void Start()
    {
        //bnt.OnPointerUp(PointerEventData)
        trans = transform;
        
        luaSvr = new LuaSvr();
        luaSvr.init(null, () =>
        {
            table = (LuaTable)luaSvr.start("GoodsSlot");
            //func=(LuaFunction)table["onMouseDragStart"];
            //Input.GetKeyDown()
           
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (_inputClickKeyCode != null)
                _inputClickKeyCode("q");

        }
    }

    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        if (_onIsRaycast != null)
        {
            Debug.Log("_isRaycast");
            return _onIsRaycast();

        }
        return true;
    }


    //[MonoPInvokeCallback(typeof(LuaCSFunction))]
    //[StaticExport]
    public static Transform GetLocalTrans()
    {
        return trans;
    }

    public static Sprite ResourcesLoad(string path)
    {
        return Resources.Load<Sprite>(path);
    }
}