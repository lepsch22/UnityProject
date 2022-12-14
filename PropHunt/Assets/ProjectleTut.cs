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
    public List<String> listOfCollidedObjects = new List<String>();

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
                listOfCollidedObjects.Add("TakeDamage");
            }
            if (co.gameObject.tag == "PlayerProp") {
                Debug.Log("Hit Player Prop");
                collidedObject = co.gameObject;
                listOfCollidedObjects.Add("PlayerProp");
            }

            //Debug.Log(co.gameObject.layer.ToString());
            Debug.Log(co.gameObject.name);
            Debug.Log(co.gameObject.tag);
            StartCoroutine(ExecuteAfterTime());
            /*
            destroyProjectile = true;
            collided = true;
            if (destroyProjectile == true) {
                if (hitNonPlayerProp == true)
                {
                    GameObject Hunter = GameObject.Find("PlayerHunterNew(Clone)");
                    Hunter.GetComponentInChildren<ProjectileShoot>().subtractHealth();
                }
                PhotonNetwork.Destroy(gameObject);
                Destroy(gameObject);
            }
            */
        }
    }
    private void Start()
    {
        Physics.IgnoreLayerCollision(8, 8);
        try
        {
            Invoke("OnDestroy", 3.3f);
        }
        catch (Exception e) {
            print("Projectile already deleted.");

        }
        
    }
    private void OnDestroy()
    {
        PhotonNetwork.Destroy(gameObject);
        Destroy(gameObject);

    }
    private void Update()
    {
        if (collided == true) { 

        }
    }
    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(0.1f);
        whatWasHit();


    }
    void whatWasHit() {
        Debug.Log("Going to decide player damage, olr prop hit.");
        if (!listOfCollidedObjects.Contains("PlayerProp") && listOfCollidedObjects.Contains("TakeDamage")) {
            hitNonPlayerProp = true;
        }
        else if (listOfCollidedObjects.Contains("PlayerProp"))
        {
            //hitNonPlayerProp = true;
        }
        if (hitNonPlayerProp == true)
        {
            GameObject Hunter = GameObject.Find("PlayerHunterNew(Clone)");
            Hunter.GetComponentInChildren<ProjectileShoot>().subtractHealth();
        }

        destroyProjectile = true;
        PhotonNetwork.Destroy(gameObject);
        Destroy(gameObject);

    }

}
