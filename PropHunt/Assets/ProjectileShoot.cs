using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileShoot : MonoBehaviour
{
    [SerializeField] private InputActionReference triggerActionReference;
    [SerializeField] TextMeshProUGUI m_Object;
    [SerializeField] GameObject XROrigin;
    public int HPIntVal = 200;
    public bool isMyNetworkedPlayerDead;
    public bool playSound = false;
    public Transform RHfirepoint;
    public GameObject projectile;
    public XRRayInteractor rayInteractor;
    public float projectileSpeed = 30;
    public List<GameObject> unityGameObjects = new List<GameObject>();
    //public LayerMask mask;
    public Camera cam;
    private Vector3 destination;

    void Start()
    {
        triggerActionReference.action.performed += ShootProjectile;

    }



    private void ShootProjectile(InputAction.CallbackContext ob)
    {
        RaycastHit hit;
        RaycastResult res;
        if (!rayInteractor.TryGetCurrentUIRaycastResult(out res))
        {

            if (Physics.Raycast(RHfirepoint.transform.position, RHfirepoint.transform.forward, out hit, Mathf.Infinity))//If ray hits any collider set destination to hit.point
                destination = hit.point;
            InstantiatieProjectile(RHfirepoint);
        }
        else
        {
            Debug.Log("UI HIT: " + res.ToString());
        }
        
    }
    
    void InstantiatieProjectile(Transform firepoint) 
    {
        //GetComponent<AudioSource>().Play();
        playSound = true;
        var projectileObj = PhotonNetwork.Instantiate("vfx_ProjectileTut", firepoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firepoint.position).normalized * projectileSpeed;
        unityGameObjects.Add(projectileObj);
    }
    
    private void Update()
    {
        if (isMyNetworkedPlayerDead) {
            Destroy(XROrigin);
            SceneManager.LoadScene("End Screen");

    }
      
    }

    public void subtractHealth() {
        int temp;
        int.TryParse(m_Object.text, out temp);
        temp = temp - 1;
        HPIntVal = temp;
        //Debug.Log("Test String " + temp.ToString());

        m_Object.text = temp.ToString();
    }
}

/*
       if (unityGameObjects.Count > 0)
       {
           for (int i = 0; i < unityGameObjects.Count; i++)
               if (unityGameObjects[i].GetComponent<ProjectleTut>().destroyProjectile == true)
               {
                   Debug.Log("Test damage " + unityGameObjects[i].GetComponent<ProjectleTut>().hitNonPlayerProp);
                   if(unityGameObjects[i].GetComponent<ProjectleTut>().hitNonPlayerProp == true)
                   {

                       int temp;
                       int.TryParse(m_Object.text, out temp);
                       temp = temp - 3;
                       HPIntVal = temp;
                       Debug.Log("Test String " + temp.ToString());

                       m_Object.text = temp.ToString();



                   }
                   PhotonNetwork.Destroy(unityGameObjects[i]);
                   unityGameObjects.RemoveAt(i);
               }

       }
       */