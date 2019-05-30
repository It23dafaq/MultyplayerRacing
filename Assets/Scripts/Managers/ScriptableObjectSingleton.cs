using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
{ 
  private static T _instance = null;

public static T Instance
{
        get
        {
            if(_instance== null)
            {
                T[] resaults = Resources.FindObjectsOfTypeAll<T>();
                if (resaults.Length == 0)
                {
                    Debug.LogError("SingletonSCriptableObject -> resault leangth is 0 for type "+ typeof(T).ToString() + ".");
                    return null;
                }
                if (resaults.Length > 1)
                {
                    Debug.LogError("SingletonSCriptableObject -> resault leangth is more than 1 for type " + typeof(T).ToString() + ".");
                    return null;
                }
                _instance = resaults[0];
            }
            return _instance;
        }
}
}

      