using System.Collections;
using System.Collections.Generic;
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
        string sourcePath = Application.streamingAssetsPath + "/"+path;

        AssetBundleCreateRequest abCR = AssetBundle.LoadFromFileAsync(sourcePath);
        yield return abCR;
        AssetBundle bundle = abCR.assetBundle;
        foreach (var item in bundle.GetAllAssetNames())
        {
            print(item);
           AssetBundleRequest abr =  bundle.LoadAssetAsync<GameObject>(item);

            yield return abr;

            Object.Instantiate(abr.asset);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}