using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  struct BundleInfo
{
    public string Name;

    public string Path;
    
    public string Hash;

    public string Variant;
    //

    public override string ToString()
    {
        return "Name: " + this.Name + "\t" +"Path: "+Path +"\t" + "Hash: "+ Hash + "\t" + "Variant: "+ Variant;
    }
}
