using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;



public class PhotonNetworkManage : MonoBehaviourPunCallbacks
{
    public GameObject spawnedPlayerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    private void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try Connect To Server");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected To server");
        base.OnConnectedToMaster();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.JoinOrCreateRoom("Room1", roomOptions, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        base.OnJoinedRoom();

    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("A new player joined the room");
        //string meshTag = spawnedPlayerPrefab.GetComponent<NetworkProp>().currMesh;
        spawnedPlayerPrefab = GetComponent<NetworkPlayerSpawner>().spawnedPlayerPrefab;
        spawnedPlayerPrefab.GetComponent<NetworkProp>().ChangeMesh();
        base.OnPlayerEnteredRoom(newPlayer);
   

    }
    /*
    void ChangeMeshRPC(string meshTag)
    {
       spawnedPlayerPrefab.GetComponent<NetworkProp>().ChangeMeshRPC(meshTag);
    }
    */




}
