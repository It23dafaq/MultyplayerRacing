using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private PlayerListing _playerlisting;
    [SerializeField]
    private Transform _content;
    private List<PlayerListing> _list = new List<PlayerListing>();


    private void Awake()
    {
        GetCurrentRoomPlayers();
    }

    private void GetCurrentRoomPlayers()
    {
        foreach (KeyValuePair<int, Player> PlayerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(PlayerInfo.Value);   
        }
    }
    private void AddPlayerListing(Player player)
    {
        PlayerListing listing = Instantiate(_playerlisting, _content);
        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            _list.Add(listing);
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
    
}
