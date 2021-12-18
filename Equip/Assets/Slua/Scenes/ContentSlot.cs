using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLua;
using System;


[CustomLuaClass]
public class ContentSlot : MonoBehaviour {


	LuaSvr luaSvr;


	public static Action<string> _inputClickKeyCode;
	private string _name;

	// Use this for initialization
	void Start () {
		_name = "potion_7";
		luaSvr =new LuaSvr();
		luaSvr.init(null, () =>
		{
			luaSvr.start("ContentSlot");
		});
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.K))
		{
			if (_inputClickKeyCode != null)
            {
				_inputClickKeyCode(_name);
				Debug.Log("KeyCode");
			}
				
		}
		else if (Input.GetKeyUp(KeyCode.S))
		{
			if (_inputClickKeyCode != null)
				_inputClickKeyCode("potion_8");
		}
	}
}
