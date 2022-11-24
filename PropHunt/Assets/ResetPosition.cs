using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    //public GameObject player;

    public void Reset()
    {
        Debug.Log($"Reset");
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        transform.rotation = Quaternion.identity;
    }
}
