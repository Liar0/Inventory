using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLua;

[CustomLuaClass]
public class ContentSlotControl : MonoBehaviour {

	LuaSvr luaSvr;
	static LuaTable table;
	// Use this for initialization
	void Start () {
		luaSvr=new LuaSvr();
		luaSvr.init(null, () =>
		 {
			
			 table=(LuaTable)luaSvr.start("ContentSlotControl");
			 Debug.Log(table);
		 });
	}
	
	public LuaTable LLTable { get { return table; } }
	public static Sprite ResourcesLoad(string path)
    {
		return Resources.Load<Sprite>(path);
    }
	public static GameObject ResourcesAssetPrefab(string path)
	{
		return GameObject.Instantiate(Resources.Load<GameObject>(path),GameObject.Find("Canvas").transform);
	}

	public static LuaTable GetTables()
    {
        return table;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
