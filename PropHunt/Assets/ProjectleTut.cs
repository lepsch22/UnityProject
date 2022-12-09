using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;


public class ProjectleTut : MonoBehaviour
{
    private bool collided;
    public bool hitNonPlayerProp = false;
    public bool destroyProjectile = false;
    public GameObject collidedObject;

    private void OnCollisionEnter(Collision co)
    {
        if (co.gameObject.tag != "Bullet" && co.gameObject.tag != "Player" && !collided && co.gameObject.tag != "Hands")
        {
            //yield WaitForSeconds(0.25);
            //destroyProjectile = true;
            if (co.gameObject.layer.ToString().Equals("7"))
            {
                Debug.Log("Take Damage");
                hitNonPlayerProp = true;
            }
            if (co.gameObject.tag == "PlayerProp") {
                Debug.Log("Hit Player Prop");
                //hitNonPlayerProp = false;
                collidedObject = co.gameObject;
            }

            Debug.Log(co.gameObject.layer.ToString());
            Debug.Log(co.gameObject.name);
            Debug.Log(co.gameObject.tag);
            destroyProjectile = true;
            collided = true;
        }
    }
    private void Start()
    {
        Physics.IgnoreLayerCollision(8, 8);
        try
        {
            Invoke("Destroy", 3.0f);
        }
        catch (Exception e) {
            print("Projectile already deleted.");

        }
        
    }
    private void OnDestroy()
    {
        PhotonNetwork.Destroy(gameObject);

    }

}
