using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaciateExample : MonoBehaviour
{
    [SerializeField]
   private GameObject _prefab;

    private void Awake()
    {
        MasterManager.NetworkIstansiate(_prefab, transform.position, Quaternion.identity);
    }
}
