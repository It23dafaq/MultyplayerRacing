﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("connecting to server");
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();

        

    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to Photon",this);
        Debug.Log(PhotonNetwork.LocalPlayer.NickName,this);
           if (!PhotonNetwork.InLobby)
                PhotonNetwork.JoinLobby();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("disconected from server for reason" + cause.ToString());
    }

}
