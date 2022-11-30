using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PropHuntNetworkManager : NetworkManager
{

    public struct PropOrHunter : NetworkMessage
    {
        public bool isProp;
    }

    // Start is called before the first frame updat
    private GameObject gamedata;

    public bool test;
    
    public override void OnStartServer()
    {
        base.OnStartServer();

        gamedata = GameObject.Find("GameData");

        Debug.Log("testing server");

        NetworkServer.RegisterHandler<PropOrHunter>(OnCreateCharacter);
    }

    public override void OnStartClient()
    {
        base.OnStartClient();

        Debug.Log("testing client");

        // you can send the message here, or wherever else you want
        PropOrHunter characterMessage = new PropOrHunter
        {
            //isProp = gamedata.GetComponent<GameData>().prop
            isProp = false
        };

        Debug.Log("testing");

        NetworkClient.Send(characterMessage);
    }

    public override void OnStartHost()
    {
        base.OnStartHost();

        Debug.Log("testing host");
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();

         // you can send the message here, or wherever else you want
         PropOrHunter characterMessage = new PropOrHunter
        {
             isProp = gamedata.GetComponent<GameData>().prop
         };

         Debug.Log("testing" + characterMessage.isProp);

        NetworkClient.Send(characterMessage);
    }

    void OnCreateCharacter(NetworkConnectionToClient conn, PropOrHunter message){
        Debug.Log("HELLO I AM MESSAGE");
        
        if(gamedata.GetComponent<GameData>().prop){
            GameObject gameObject = Instantiate(this.spawnPrefabs[0]);
            NetworkServer.AddPlayerForConnection(conn, gameObject);
            Debug.Log("testing prop spawn");
        } else {
            GameObject gameObject = Instantiate(this.spawnPrefabs[1]);
            NetworkServer.AddPlayerForConnection(conn, gameObject);
            Debug.Log("testing hunter spawn");
        }
        

    }
}
