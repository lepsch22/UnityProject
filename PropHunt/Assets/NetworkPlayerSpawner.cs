using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    private GameObject spawnedPlayerPrefab;

    public GameObject playerHunter;
    public GameObject playerProp;

    private GameObject gamedata;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        gamedata = GameObject.Find("GameData");

        if(gamedata.GetComponent<GameData>().prop){
            Instantiate(playerProp, transform.position, transform.rotation);
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player Prop", transform.position, transform.rotation);

        } else {
            //Debug.Log("Spawn Hunter");
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player Hunter", transform.position, transform.rotation);
            Instantiate(playerHunter, transform.position, transform.rotation);
         }


    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);

    }

}
