﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateRoomMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _roomName;

    private RoomCanvases _roomsCanvases;

    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomsCanvases = canvases;
    }

    public void Onclick_CreateRoom()
    {
        //create ROOM
        //JOIN CREATE ROOM
        if (!PhotonNetwork.IsConnected)
            return;

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(_roomName.text,options,TypedLobby.Default);

    }

    public override void OnCreatedRoom()
    {
        Debug.Log("created room succefully.", this);
        _roomsCanvases.CurrentRooms.Show();
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Room creation failed:" + message, this);
    }
    

    }


