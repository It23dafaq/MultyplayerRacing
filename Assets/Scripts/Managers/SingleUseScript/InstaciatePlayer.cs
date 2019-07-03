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
        SpawnPlayer();
     //   PhotonNetwork.Instantiate(pla, new Vector3(0, 0, 0), Quaternion.identity, 0);
    }
    public void SpawnPlayer()
    {
        GameObject player = Instantiate(_prefab);
        PhotonView photonView = player.GetComponent<PhotonView>();

      //  MasterManager.NetworkIstansiate(_prefab, transform.position, Quaternion.identity);
       // PhotonView photonView = _prefab.GetComponent<PhotonView>();

        if (PhotonNetwork.AllocateViewID(photonView))
        {
            object[] data = new object[]
            {
            _prefab.transform.position, _prefab.transform.rotation, photonView.ViewID
            };

            RaiseEventOptions raiseEventOptions = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.AddToRoomCache
            };

            SendOptions sendOptions = new SendOptions
            {
                Reliability = true
            };

            PhotonNetwork.RaiseEvent(CustomManualInstantiationEventCode, data, raiseEventOptions, sendOptions);
        }
        else
        {
            Debug.LogError("Failed to allocate a ViewId.");

            Destroy(_prefab);
        }
    }

    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == CustomManualInstantiationEventCode)
        {
            object[] data = (object[])photonEvent.CustomData;
            
            MasterManager.NetworkIstansiate(_prefab, (Vector3)data[0], (Quaternion)data[1]);
            PhotonView photonView = _prefab.GetComponent<PhotonView>();
            photonView.ViewID = (int)data[2];
            photonView.TransferOwnership((int)data[2]);
            
            
        }
    }
    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += OnEvent;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= OnEvent;
    }


}
