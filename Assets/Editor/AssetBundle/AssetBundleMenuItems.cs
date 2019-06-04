using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class AssetBundleMenuItems
{

    //public static string CreateAssetBundleDirectory()
    //{
    //    // Choose the output path according to the build target.
    //    string outputPath = Path.Combine(Utility.AssetBundlesOutputPath, Utility.GetPlatformName());
    //    if (!Directory.Exists(outputPath))
    //        Directory.CreateDirectory(outputPath);

    //    return outputPath;
    //}

    [MenuItem("AsssetBundles/Build")]
    public static void BuildAssetBundle()
    {
        Utility.CreateAssetBundleDirectory();
    }



    static void ClearAssetBundlesName()
    {
        //获取所有的AssetBundle名称
        string[] abNames = AssetDatabase.GetAllAssetBundleNames();

        //强制删除所有AssetBundle名称
        for (int i = 0; i < abNames.Length; i++)
        {
            AssetDatabase.RemoveAssetBundleName(abNames[i], true);
        }
    }

}
