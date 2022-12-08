using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NetworkPlayerSpawner : MonoBehaviourPunCallbacks
{
    public GameObject spawnedPlayerPrefab;

    public GameObject playerHunter;
    public GameObject playerProp;

    private GameObject gamedata;
    public GameObject[] players;
    public ExitGames.Client.Photon.Hashtable m_playerCustomProperties = new ExitGames.Client.Photon.Hashtable();

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        gamedata = GameObject.Find("GameData");
        GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerPropNetworked");
  

        if(gamedata.GetComponent<GameData>().prop){
            Instantiate(playerProp, transform.position, transform.rotation);
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player Prop", transform.position, transform.rotation);
            spawnedPlayerPrefab.GetComponent<NetworkProp>().currMesh = "Big_Table";
        }
        else {
            Debug.Log("Spawn Hunter");
            Instantiate(playerHunter, transform.position, transform.rotation);
            spawnedPlayerPrefab = PhotonNetwork.Instantiate("Network Player Hunter", transform.position, transform.rotation);
        }
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawnedPlayerPrefab);

    }

    
    public void C_SetMesh(string tMesh){
        if(PhotonNetwork.IsConnected){
            m_playerCustomProperties["Mesh"] = tMesh;
            PhotonNetwork.SetPlayerCustomProperties(m_playerCustomProperties);
        }

    }
    public string C_GetMesh(int i){
        string currMesh = (string)PhotonNetwork.PlayerList[i].CustomProperties["Mesh"];
        Debug.Log("The mesh of " + i +" is "+currMesh);
        return currMesh;

    }

    
    

}
