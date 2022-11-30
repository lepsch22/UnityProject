using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOffThePenjamin : MonoBehaviour
{
    public GameObject gamedata;
    public bool isProp;
    
    void Start()
    {
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
