using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaciateExample : MonoBehaviourPun
{
    [SerializeField]
    private GameObject _prefab;

    private const byte CustomManualInstantiationEventCode = 1;
    private void Awake()
    {
        // PhotonNetwork.Instantiate("Car", new Vector3(28, 3, 245), Quaternion.identity, 0);
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        GameObject player = Instantiate(_prefab);
        PhotonView photonView = player.GetComponent<PhotonView>();

        if (PhotonNetwork.AllocateViewID(photonView))
        {
            object[] data = new object[]
            {
            player.transform.position, player.transform.rotation, photonView.ViewID
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

            Destroy(player);
        }
    }
    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == CustomManualInstantiationEventCode)
        {
            object[] data = (object[])photonEvent.CustomData;

            GameObject player = (GameObject)Instantiate(_prefab, (Vector3)data[0], (Quaternion)data[1]);
            PhotonView photonView = player.GetComponent<PhotonView>();
            photonView.ViewID = (int)data[2];
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