using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCanvases : MonoBehaviour
{
    [SerializeField]
    private CreateOrJoinRooms _createOrJoinRooms;
    public CreateOrJoinRooms    CreateOrJoinRooms { get { return _createOrJoinRooms; } }

    [SerializeField]
    private CurrentRoom _currentRoom;
    public CurrentRoom CurrentRooms{ get { return _currentRoom; } }

    private void Awake()
    {
        FirstInitialize();
    }
    private void FirstInitialize()
    {
        CreateOrJoinRooms.FirstInitialize(this);
        CurrentRooms.FirstInitialize(this);
    }
}
