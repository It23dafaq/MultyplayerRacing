using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class PlayerListingsMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private PlayerListing _playerlisting;
    [SerializeField]
    private Transform _content;
    private List<PlayerListing> _list = new List<PlayerListing>();
    private RoomCanvases roomCanvases;
    [SerializeField]
    private Text _ReadyUpText;
    private bool Ready = false;
    
    
    public override void OnEnable()
    {
        base.OnEnable();
        setReady(false);
        
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
    public void setReady(bool state)
    {
         Ready = state;
        if (!Ready)
        {
            _ReadyUpText.text = "Ready";
        }
        else
        {
            _ReadyUpText.text = "Not Ready";
        }
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
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        roomCanvases.CurrentRooms._leaveRoom.Onclick_LeaveRoom();
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
       /* if (PhotonNetwork.IsMasterClient)
        {   
            for(int i=0 ; i < _list.Count;i++)
            {
                if(_list[i].Player != PhotonNetwork.LocalPlayer)
                {
                    if (!_list[i].playerReady)
                        return;
                    
                }
            }
            */
            PhotonNetwork.CurrentRoom.IsOpen = false;
            PhotonNetwork.CurrentRoom.IsVisible = false;
            PhotonNetwork.LoadLevel(1);
        //}
    }
    public void OnClick_Ready()
    {
        setReady(!Ready);
        base.photonView.RPC("RPC_ChangeState",RpcTarget.MasterClient,PhotonNetwork.LocalPlayer, Ready);
        //base.photonView.RpcSecure("RPC_ChangeState", RpcTarget.MasterClient,true, PhotonNetwork.LocalPlayer, Ready);
    }
    [PunRPC]
    public void RPC_ChangeState(Player player,bool Ready)
    {

        int index = _list.FindIndex(x => x.Player == player);
        if (index != -1)
            _list[index].playerReady = Ready;
        
        
    }
}
