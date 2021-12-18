using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SLua;
using System.IO;
using System;

[CustomLuaClass]
public class CoroutineTest : MonoBehaviour {



	LuaSvr luaSvr;
	LuaTable table;
	LuaFunction func;
	static CoroutineTest c;
	int process;
	// Use this for initialization
	void Start () {
		//c = this;
		//luaSvr = new LuaSvr();

		//luaSvr.init(null, () => {

		//	table = (LuaTable)luaSvr.start("CoroutineT");

		//	Debug.Log(table.ToString());
		//	func = (LuaFunction)table["init"];

		//	//LoadAssetFunc();
		//});


		//luaSvr.init(Tick, Complete);
		
		StartCoroutine(Coroutine());

	}
	
	IEnumerator Coroutine()
    {

		//AssetBundle a=AssetBundle.LoadFromFile("");



		string url = "D:/luaProject/AssetBundle/AssetBundle";

		//WWW request=WWW.LoadFromCacheOrDownload(url,0);
		//yield return request;

		//AssetBundle assetBundle = request.assetBundle;
		AssetBundle assetBundle = AssetBundle.LoadFromFile(url);

		Debug.Log(assetBundle.ToString());	
		AssetBundleManifest ab =assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
		Debug.Log(ab);
		
		string[] abAll=ab.GetAllAssetBundles();
		foreach(string s in abAll)
        {
			Debug.Log(s);



            //AssetBundleManifest abb = assetBundle.LoadAsset<AssetBundleManifest>(s);
            string[] str = ab.GetAllDependencies(s);
            
            foreach (string st in str)
            {
                Debug.Log(st);
            }
        }

		WWW www=WWW.LoadFromCacheOrDownload("D:/luaProject/AssetBundle/cube.prefab",0);
		yield return www;
		AssetBundle aa=www.assetBundle;
		
		GameObject.Instantiate(aa.LoadAsset<GameObject>("cube.prefab"));

		yield return null;


		
    }


	void LoadAssetFunc()
    {
		func.call(null, this);

		func.Dispose();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void Tick(int p)
    {
		process = p;

	}
	[MonoPInvokeCallback(typeof(LuaCSFunction))]
	[StaticExport]
	static public int staticCoroutineTest(IntPtr l)
    {
		LuaObject.pushValue(l, true);

		LuaObject.pushValue(l, c);
		return 2;
    }






	void Complete()
    {
		table = (LuaTable)luaSvr.start("CoroutineT");

		Debug.Log(table.ToString());	
		func=(LuaFunction)table["init"];

        func.call(this);

        func.Dispose();
	}


}
