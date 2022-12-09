using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] spawnpoints;
    private int currSpawn = 0;
    public GameObject E;
    public GameObject SpawnManager;

    private void Start()
    {
        E = GameObject.Find("EventSystem");
        SpawnManager = GameObject.Find("Spawns");
        spawnpoints = SpawnManager.GetComponent<spawnManager>().spawnpoints;
    }
    public void ResetToSpawn()
    {
        transform.position = spawnpoints[currSpawn].transform.position;
        if (currSpawn == spawnpoints.Length-1)
        {
            currSpawn = 0;

        }
        else 
        {
            currSpawn++;

        }
        E.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

    }

}
