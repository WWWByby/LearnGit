using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Editor.AssetBundle;
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
        ClearAssetBundlesName();
        AssetBundleMenuItems.NamedAssetBundles();
        //Utility.CreateAssetBundleDirectory();
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

        AssetDatabase.RemoveUnusedAssetBundleNames();
    }


    static void NamedAssetBundles()
    {
        //
        List<BundleInfo> lists =  BuildBundleScript.BuildAllName();

        if (lists.Count == 0)
        {
            Debug.LogError("bundle is null");
            return;
        }

        for (int i = 0; i < lists.Count; i++)
        {
            var info = lists[i];

            string importPath = BuildBundleScript.ImporterBundlePath + "/" + info.Path;
            
            var importer = AssetImporter.GetAtPath(importPath);

            if (importer == null)
            {
                Debug.LogError(importPath+ " : importer is null");
                continue;
            }

            importer.assetBundleName = info.Name;
            importer.assetBundleVariant = info.Variant;
            importer.SaveAndReimport();
        }
        //AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

    }

}
