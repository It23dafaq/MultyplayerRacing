using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(menuName = "Singletons/MasterManager")]
public class MasterManager : ScriptableObjectSingleton<MasterManager>
{
    [SerializeField]
    private GameSettings _gameSettings;

    private List<NetworkPrefab> _networkPrefabs = new List<NetworkPrefab>();
    public static GameSettings GameSettings{ get { return Instance._gameSettings; } }

    static public GameObject NetworkIstansiate(GameObject obj,Vector3 position,Quaternion rotesion)
    {
        foreach(NetworkPrefab networkprefab in Instance._networkPrefabs)
        {
            if (networkprefab._prefab == obj)
            {
                if (networkprefab._path != string.Empty)
                {
                    GameObject resaults = PhotonNetwork.Instantiate(networkprefab._path, position, rotesion);
                    return resaults;
                }
                else
                {
                    Debug.LogError("PATH IS EMPTY FOR GAMEOBJECT NAME" + networkprefab._prefab);
                    return null;
                }
            }

        }
        return null;
    }
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void PopulateNetworkPrefab()
    {
#if UNITY_EDITOR

        Instance._networkPrefabs.Clear();

        GameObject[] resaults = Resources.LoadAll<GameObject>("");
        for(int i = 0; i < resaults.Length; i++)
        {
            if (resaults[i].GetComponent<PhotonView>() != null)
            {
              string path =  AssetDatabase.GetAssetPath(resaults[i]);
                Instance._networkPrefabs.Add(new NetworkPrefab(resaults[i], path));

            }
        }

#endif
    }

    }

