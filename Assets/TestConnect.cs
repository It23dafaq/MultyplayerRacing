using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestConnect : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        print("connecting to server");
        PhotonNetwork.NickName = MasterManager.GameSettings.NickName;
        PhotonNetwork.GameVersion = MasterManager.GameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();

        

    }
    public override void OnConnectedToMaster()
    {
        print("connected to master");
        print(PhotonNetwork.LocalPlayer.NickName);
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("disconected from server for reason" + cause.ToString());
    }

}
