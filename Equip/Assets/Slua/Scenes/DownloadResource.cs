using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SLua;
using UnityEngine.Networking;

public class DownloadResource : MonoBehaviour {


	LuaSvr luaSvr;
	LuaTable luaTable;
	LuaFunction main;

	private Button downloadBnt;
	// Use this for initialization
	void Start () {

        //luaSvr=new LuaSvr();
        //luaSvr.init(null, () =>
        // {
        //	 luaTable=(LuaTable)luaSvr.start("download");
        //	 //main = (LuaFunction)luaSvr.start("download");
        //	 //main.call(this);
        //	 //main.Dispose();	
        //	 //update = (LuaFunction)luaTable["update"];
        // }
        //);

        downloadBnt = GameObject.Find("Canvas/resource").GetComponent<Button>();
        if (downloadBnt != null)
        {
            downloadBnt.onClick.AddListener(OnClickDownload);
        }
    }
	
	// Update is called once per frame
	void Update () {
       
	}
	void OnClickDownload ()
    {
        StartCoroutine(Down("D:/luaProject/AssetBundle/AssetBundle"));
    }
	public IEnumerator Down(string str)
    {
        //string url="";
        //WWW www = WWW.LoadFromCacheOrDownload(url, 0);
        //yield return www;
        //      AssetBundle manifestAB = www.assetBundle;

        ////string[] mainStr=manifestAB.GetAllAssetNames();

        //AssetBundle AB=(AssetBundle)manifestAB.LoadAsset(str);
        //UnityWebRequest request=UnityWebRequest.GetAssetBundle(str);    
        //yield return request.Send();  
        //AssetBundle ab=DownloadHandlerAssetBundle.GetContent(request);
        

        WWW www = WWW.LoadFromCacheOrDownload(str, 0);
        yield return www;
        
        AssetBundle ab=www.assetBundle;
        AssetBundleManifest assetBundleManifest = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
        string[] strAB=assetBundleManifest.GetAllAssetBundles();
        foreach (var item in strAB)
        {
            Debug.Log(item);
            WWW ttt = WWW.LoadFromCacheOrDownload("D:/luaProject/AssetBundle/"+item, 0);
            yield return ttt;
            Debug.Log(item.Split('.')[1] + "____" + item.Split('.')[0]);
            if(item.Split('.')[1].Equals("prefab"))
            {
                Debug.Log("Instantiate");
                Debug.Log(ttt.assetBundle.LoadAsset<GameObject>(item.Split('.')[0]));
                GameObject.Instantiate(ttt.assetBundle.LoadAsset<GameObject>(item), GameObject.Find("Canvas").transform);
            }
             
        }

        yield return null;
    }

}
