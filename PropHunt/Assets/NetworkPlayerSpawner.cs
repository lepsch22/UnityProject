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
    public GameObject[] gameObjects;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        gamedata = GameObject.Find("GameData");
        gameObjects = GameObject.FindGameObjectsWithTag("PlayerProp");

        //if(gamedata.GetComponent<GameData>().prop){
        Instantiate(playerProp, transform.position, transform.rotation);
        spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player Prop", transform.position, transform.rotation);
        spawnedPlayerPrefab.GetComponent<NetworkProp>().currMesh = "Chair";
        /*
        } else {
            Debug.Log("Spawn Hunter");
            Instantiate(playerHunter, transform.position, transform.rotation);
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player Hunter", transform.position, transform.rotation);
        }
        */

        if (spawnedPlayerPrefab.GetPhotonView().IsMine)
        {
            for (int i = 0; i < gameObjects.Length; i++)
            {
                var obj = GameObject.FindWithTag(gameObjects[i].GetComponent<NetworkProp>().currMesh);
                gameObjects[i].GetComponentInChildren<MeshFilter>().mesh = obj.GetComponent<MeshFilter>().mesh;
                gameObjects[i].GetComponentInChildren<MeshRenderer>().materials = obj.GetComponent<MeshRenderer>().materials;
            }

        }


    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);

    }

}
