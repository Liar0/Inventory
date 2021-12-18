using UnityEngine;
using System.Collections;
using SLua;
using UnityEngine.UI;
using System;

public class Circle : MonoBehaviour {


	LuaSvr svr;
	LuaTable self;
	LuaFunction update;

    [CustomLuaClass]
    public delegate void UpdateDelegate(object self);

    UpdateDelegate ud;

	void Start () {

        //GameObject.Find("").GetComponent<Slider>().onValueChanged.AddListener(() =>{ return 0.4; });
		svr = new LuaSvr();
		
		svr.init(null, () =>
		{
			
			self = (LuaTable)svr.start("circle/circle");
            update = (LuaFunction)self["update"] ;
            ud = update.cast<UpdateDelegate>();
		});
	}
	
	void Update () {
        if (ud != null) ud(self);
	}
}
