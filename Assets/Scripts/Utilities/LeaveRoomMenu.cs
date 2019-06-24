using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class LeaveRoomMenu : MonoBehaviour
{
    private RoomCanvases _roomCanvases;

    public void FirstInitialized(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
    }

    public void Onclick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom(true);
        _roomCanvases.CurrentRooms.hide();
        
    }
   
}
