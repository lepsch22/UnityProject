using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hunter;
    public bool prop;
    public void setProp()
    {
        prop = true;
    }
    public void setHunter()
    {
        hunter = true;
    }
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        if (currentScene.name == "DontDestroyOnLoad")
        {
            GameObject networkManage;
            //networkManage = GameObject.Find("NetworkManager");
            //networkManage.

            
            
        }

    }
}
