using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayerToSelf : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    public void Reset()
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 1, player.transform.position.z);
        player.transform.rotation = Quaternion.identity;  
    }

}
