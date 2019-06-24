using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCustomPropertyGenerator : MonoBehaviour
{
    [SerializeField]
    private Text _text;

    private ExitGames.Client.Photon.Hashtable _myproperty = new ExitGames.Client.Photon.Hashtable();

    // Start is called before the first frame update
    public void setCustomNumper()
    {
        System.Random rnd = new System.Random();
        int resault = rnd.Next(0,99);

        _text.text = resault.ToString();
        _myproperty["RandomNumber"] = resault;        
        PhotonNetwork.LocalPlayer.CustomProperties = _myproperty;
    }
    
    public void onClick_Buton()
    {
        setCustomNumper();
    }
}
