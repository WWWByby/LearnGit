using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class LoaderBundle : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        StartCoroutine(LoadAssetBundle("Prefabs/Canvas.prefab"));
    }


    IEnumerator LoadAssetBundle(string path = "")
    {
        path = path.ToLower();
        //
        string sourcePath;

#if UNITY_EDITOR
        sourcePath = Application.streamingAssetsPath + "/StandaloneOSXUniversal/"+path;
#endif

        Debug.Log("加载prefab:" + sourcePath);
        AssetBundle assetBundle = AssetBundle.LoadFromFile(sourcePath);
        yield return assetBundle;
        string[] names = assetBundle.GetAllAssetNames();
        print(names.Length);
    }

    // Update is called once per frame
    void Update()
    {
    }
}