using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] spawnpoints;
    private int currSpawn = 0;

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

    }

}
