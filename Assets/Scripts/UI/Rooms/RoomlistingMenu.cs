using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomlistingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Roomlisting _roomlisting;
    [SerializeField]
    private Transform _content;
    private List<Roomlisting> _list= new List<Roomlisting>();
    private RoomCanvases _roomCanvases;

    public void FirstInitialize(RoomCanvases canvases)
    {
        _roomCanvases = canvases;
    }

    public override void OnJoinedRoom()
    {
        _roomCanvases.CurrentRooms.Show();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(RoomInfo info in roomList)
        {   //remove from list
            if (info.RemovedFromList)
            {
                int index = _list.FindIndex(x => x.roomiNFO.Name == info.Name);
                if(index != -1)
                {
                    Destroy(_list[index].gameObject);
                    _list.RemoveAt(index);
                   

                }
            }
            //added to room list
            else
            {
                Roomlisting listing = Instantiate(_roomlisting, _content);
                if (listing != null)
                {
                    listing.SetRoomInfo(info);
                    _list.Add(listing);
                }
            }
        }
    } 
}
