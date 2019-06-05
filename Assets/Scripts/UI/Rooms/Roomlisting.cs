using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roomlisting : MonoBehaviour
{
   
        [SerializeField]
        private Text _text;

    public RoomInfo roomiNFO { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
         roomiNFO = roomInfo;
        _text.text = roomInfo.MaxPlayers + "," + roomInfo.Name;
    }

    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(roomiNFO.Name);
    }

    }


