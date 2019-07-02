using ExitGames.Client.Photon;
using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventsExample : MonoBehaviourPun
{
   private SpriteRenderer _spriterender;
    private const byte COLOR_CHANGE_EVENT=0;

    private void Awake()
    {
        _spriterender = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   private void Update()
    {
        if (base.photonView.IsMine && Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColor();
        }
    }

    private void OnEnable()
    {
        PhotonNetwork.NetworkingClient.EventReceived += NetworkingCliend_EventReceiver;
    }

    private void OnDisable()
    {
        PhotonNetwork.NetworkingClient.EventReceived -= NetworkingCliend_EventReceiver;
    }

    private void NetworkingCliend_EventReceiver(EventData obj)
    {
        if (obj.Code == COLOR_CHANGE_EVENT)
        {
            object[] datas = (object[])obj.CustomData;
            float r = (float)datas[0];
            float g = (float)datas[1];
                float b = (float)datas[2];
            Debug.Log("im here");
            _spriterender.color = new Color(r, g, b, 1f);
        }
    }

    private void ChangeColor()
    {
        float r = UnityEngine.Random.Range(0f, 1f);
        float b = UnityEngine.Random.Range(0f, 1f);
        float g = UnityEngine.Random.Range(0f, 1f);
        

        _spriterender.color = new Color(r, g, b,1f);

        object[] datas = new object[] { r, g, b };

        PhotonNetwork.RaiseEvent(COLOR_CHANGE_EVENT,datas,raiseEventOptions:default,SendOptions.SendUnreliable);
    }
}
