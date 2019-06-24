using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoom : MonoBehaviour
{
    private RoomCanvases _roomsCanvases;
    [SerializeField]
    PlayerListingsMenu _playerlistingsmenu;
    [SerializeField]
    LeaveRoomMenu leaveRoomMenu;

    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomsCanvases = canvases;
        _playerlistingsmenu.FirstInitialized(canvases);
        leaveRoomMenu.FirstInitialized(canvases);
    }

    public void Show()
    {
        gameObject.SetActive(true); 
    }
    public void hide()
    {
        gameObject.SetActive(false);
    }
}
