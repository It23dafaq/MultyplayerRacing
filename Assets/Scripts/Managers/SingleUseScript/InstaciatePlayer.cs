using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Realtime;

public class InstaciatePlayer : MonoBehaviourPun
{
    private const byte CustomManualInstantiationEventCode = 1;
    [SerializeField]
    private GameObject _prefab;
    private void Awake()
    {
        MasterManager.NetworkIstansiate(_prefab, transform.position, Quaternion.identity);
     //   PhotonNetwork.Instantiate(pla, new Vector3(0, 0, 0), Quaternion.identity, 0);
    }
   


}
