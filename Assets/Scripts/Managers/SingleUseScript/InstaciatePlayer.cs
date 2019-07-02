using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Photon.Realtime;

public class InstaciatePlayer : MonoBehaviourPun
{
    
    private GameObject PlayerPrefab;
    private const byte SPAWN_CHANGE_EVENT = 1;
   

    private void Awake()
    {
        PlayerPrefab = GetComponent<GameObject>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
    }

    
    public void OnEvent(EventData photonEvent)
    {
        if (photonEvent.Code == SPAWN_CHANGE_EVENT)
        {
            object[] data = (object[])photonEvent.CustomData;

            GameObject player = (GameObject)Instantiate(PlayerPrefab, (Vector3)data[0], (Quaternion)data[1]);
            PhotonView photonView = player.GetComponent<PhotonView>();
            photonView.ViewID = (int)data[2];
        }
    }

    

    public void SpawnPlayer()
    {
        GameObject player = Instantiate(PlayerPrefab);
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

            PhotonNetwork.RaiseEvent(SPAWN_CHANGE_EVENT, data, raiseEventOptions, sendOptions);
        }
        else
        {
            Debug.LogError("Failed to allocate a ViewId.");

            Destroy(player);
        }
    }



}
