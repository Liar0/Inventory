using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
public class BuildAB {
	[MenuItem("AssetBundle/BuildAsset")]
	static void BuildAsset() {
		string str = "AssetBundle";
		if(!Directory.Exists(str))
        {
			Directory.CreateDirectory(str);
        }
        
		Debug.Log("正在压缩AB包");
		BuildPipeline.BuildAssetBundles(str, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
	}
	[MenuItem("AssetBundle/DeleteAsset")]
	static bool DeleteAsset() {
		string str = "AssetBundle";
		if (Directory.Exists(str))
		{
			Directory.Delete(str);
			Debug.Log("删除成功");
			return true;
		}
		Debug.Log("删除失败");
		return false;
	}								
}
