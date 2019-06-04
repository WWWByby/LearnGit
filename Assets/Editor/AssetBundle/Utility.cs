using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class Utility
{
    public const string AssetBundlesOutputPath = "AssetBundles";


    public static string CreateAssetBundleDirectory()
    {
        // Choose the output path according to the build target.
        string outputPath = Path.Combine(Utility.AssetBundlesOutputPath, Utility.GetPlatformName());
        if (!Directory.Exists(outputPath))
            Directory.CreateDirectory(outputPath);

        return outputPath;
    }


#if UNITY_EDITOR
    private static string GetPlatformForAssetBundles(BuildTarget target)
    {
        switch (target)
        {
            case BuildTarget.Android:
                return "Android";
#if UNITY_TVOS
                case BuildTarget.tvOS:
                    return "tvOS";
#endif
            case BuildTarget.iOS:
                return "iOS";
            case BuildTarget.WebGL:
                return "WebGL";
            //                case BuildTarget.WebPlayer:
            //                    return "WebPlayer";
            case BuildTarget.StandaloneWindows:
            case BuildTarget.StandaloneWindows64:
                return "Windows";
            case BuildTarget.StandaloneOSX:
                return "OSX";
            // Add more build targets for your own.
            // If you add more targets, don't forget to add the same platforms to GetPlatformForAssetBundles(RuntimePlatform) function.
            default:
                return null;
        }
    }
#endif


    public static string GetPlatformName()
    {
#if UNITY_EDITOR
        return GetPlatformForAssetBundles(EditorUserBuildSettings.activeBuildTarget);
#else
            return GetPlatformForAssetBundles(Application.platform);
#endif
    }
}
