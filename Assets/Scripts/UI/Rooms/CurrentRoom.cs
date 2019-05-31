using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentRoom : MonoBehaviour
{
    private RoomCanvases _roomsCanvases;

    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomsCanvases = canvases;
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
