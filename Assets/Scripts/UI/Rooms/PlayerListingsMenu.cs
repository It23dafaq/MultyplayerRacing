using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private PlayerListing _playerlisting;
    [SerializeField]
    private Transform _content;
    private List<PlayerListing> _list = new List<PlayerListing>();
    private RoomCanvases roomCanvases;
    
    
    public override void OnEnable()
    {
        base.OnEnable();
        
        GetCurrentRoomPlayers();
    }
    public override void OnDisable()
    {
        base.OnDisable();
        for (int i = 0; i < _list.Count; i++)
            Destroy(_list[i].gameObject);

        _list.Clear();
    }
    public void FirstInitialized(RoomCanvases canvases)
    {
        roomCanvases = canvases;
    }
    

    private void GetCurrentRoomPlayers()
    {   if (!PhotonNetwork.IsConnected)
            return;

        if (PhotonNetwork.CurrentRoom == null || PhotonNetwork.CurrentRoom.Players==null)
            return;
        foreach (KeyValuePair<int, Player> PlayerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(PlayerInfo.Value);   
        }
    }
    private void AddPlayerListing(Player player)
    {
        int index = _list.FindIndex(x => x.Player == player);
        //if index found 
        if (index != -1)
        {
            _list[index].SetPlayerInfo(player);
        }
        else
        {

            PlayerListing listing = Instantiate(_playerlisting, _content);
            if (listing != null)
            {
                listing.SetPlayerInfo(player);
                _list.Add(listing);
            }
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {

        int index = _list.FindIndex(x => x.Player == otherPlayer);   
        if (index != -1)
        {
            Destroy(_list[index].gameObject);
            _list.RemoveAt(index);
        }
   
    }
    public void OnClick_StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        }
    }
    
}
