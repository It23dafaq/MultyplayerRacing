using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOrJoinRooms : MonoBehaviour
{

    [SerializeField]
    private CreateRoomMenu _createRoomMenu;
    [SerializeField]
    private RoomlistingMenu _RoomListingMenu;


    private RoomCanvases _roomsCanvases;

    public void FirstInitialize(RoomCanvases canvases)
    {
        
        _roomsCanvases = canvases;
        _createRoomMenu.FirstInitialize(canvases);
        _RoomListingMenu.FirstInitialize(canvases);
    }
}
