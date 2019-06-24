using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerListing : MonoBehaviour
{
   
        [SerializeField]
        private Text _text;
    

    public Player Player { get; private set; }

    public void SetPlayerInfo(Player player)
    {
         
        Player = player;
        string resault = "";
        if (PhotonNetwork.LocalPlayer.CustomProperties.ContainsKey("RandomNumber"))
        {
            resault = PhotonNetwork.LocalPlayer.CustomProperties["RandomNumber"] + ", ";
        }
       
        _text.text = resault + player.NickName;
    }


    }


