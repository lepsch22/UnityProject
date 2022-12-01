using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GetOffThePenjamin : NetworkBehaviour
{
    public GameObject gamedata;
    public bool isProp;
    
    public override void OnStartLocalPlayer()
    {
        if(!isLocalPlayer){return;}
        gamedata = GameObject.Find("GameData");
        isProp = gamedata.GetComponent<GameData>().prop;
        if(isProp)
        {
            this.gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

}
