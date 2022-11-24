using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectleTut : MonoBehaviour
{
    private bool collided;
    public bool hitNonPlayerProp = false;
    public bool destroyProjectile = false;
    private void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided && co.gameObject.tag != "Hands")
        {
            //destroyProjectile = true;
            if (co.gameObject.layer.ToString().Equals("7"))
            {
                Debug.Log("Take Damage");
                hitNonPlayerProp = true;
            }
            Debug.Log(co.gameObject.layer.ToString());
            Debug.Log(co.gameObject.name);
            Debug.Log(co.gameObject.tag);
            destroyProjectile = true;
            collided = true;
        }
    }

}
