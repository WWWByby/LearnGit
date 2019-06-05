using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

namespace Editor.AssetBundle
{
    public class BuildBundleScript
    {

        public static string BundlePath = "AssetBundles";
        public static string ImporterBundlePath = "Assets/"+BundlePath;
        public static string RootPath = Application.dataPath + "/"+BundlePath;
    
        public static List<BundleInfo> BuildAllName()
        {
            Stack<string> searchStack = new Stack<string>() { };
            searchStack.Push(RootPath);
            Debug.Log(RootPath);
            
            List<BundleInfo> list = new List<BundleInfo>();
            while (searchStack.Count > 0)
            {
                string headPath = searchStack.Pop();

                string relativelyPath =
                    headPath.Length == RootPath.Length ? "" : headPath.Substring(RootPath.Length + 1);

                Debug.Log(relativelyPath);
                foreach (var VARIABLE in Directory.GetFiles(headPath))
                {
                    if (VARIABLE.EndsWith(".meta"))
                    {
                        string path = VARIABLE.Substring(0, VARIABLE.Length - 5);

                        if (Directory.Exists(path))
                        {
                            searchStack.Push(path);
                        }
                        else
                        {
                            BundleInfo info = new BundleInfo();
                            info.Path = relativelyPath;
                            string fileName = Path.GetFileName(path);
//                            Debug.Log("fileName:"+fileName);

                            string[] prefabBundleName = fileName.Split('.');
                            //资源的bundleName
                            string bundleName = relativelyPath +"/"+ prefabBundleName[0];

                            string variant = prefabBundleName[1];
                            info.Variant = variant;
                            info.Name = bundleName;
                            list.Add(info);
                        }
                    }
                }
            }


            for (int i = 0; i < list.Count; i+=1)
            {
                Debug.Log(list[i]);
            }
            
            Debug.Log(Directory.Exists(RootPath));

            return list;
        }
    }
}