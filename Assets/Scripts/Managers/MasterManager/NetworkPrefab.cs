using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkPrefab 
{
    public GameObject _prefab;
    public string _path;

    public NetworkPrefab(GameObject gomj,string path)
    {
        _prefab = gomj;
        _path = ReturnPrefabPathModified(path);
        
    }

    //assets/resources/file.prefab
    //this method cuts first and last eg(assets,.prefab)
    
    private string ReturnPrefabPathModified(string path)
    {
        int ExtensionLength = System.IO.Path.GetExtension(path).Length;
        int additionallenght = 10;
        int startIndex = path.IndexOf("Resources");

        if (startIndex == -1)
            return string.Empty;
        else
            return path.Substring(startIndex+additionallenght, path.Length - (additionallenght+ startIndex + ExtensionLength));
    }
}
