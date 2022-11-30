using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;


public class ProjectileShoot : MonoBehaviour
{
    [SerializeField] private InputActionReference triggerActionReference;
    [SerializeField] TextMeshProUGUI m_Object;

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
    /*
    public void OnHoverEntered(HoverEnterEventArgs args) 
    {
        Debug.Log($"{args.interactorObject} hovered over {args.interactableObject}", this);
    }
    public void OnHoverExited(HoverExitEventArgs args)
    {
        Debug.Log($"{args.interactorObject} stopped hovering over {args.interactableObject}", this);
    }   */


    private void ShootProjectile(InputAction.CallbackContext ob)
    {
        //Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        RaycastResult res;
        if (!rayInteractor.TryGetCurrentUIRaycastResult(out res))
        {
            //cursor.transform.position = res.worldPosition;

            if (Physics.Raycast(RHfirepoint.transform.position, RHfirepoint.transform.forward, out hit, Mathf.Infinity))//If ray hits any collider set destination to hit.point
                destination = hit.point;
            //else
            //destination = ray.GetPoint(1000);
            InstantiatieProjectile(RHfirepoint);
        }
        else
        {
            Debug.Log("UI HIT: " + res.ToString());
        }
        
    }
    
    void InstantiatieProjectile(Transform firepoint) 
    {
        var projectileObj = Instantiate(projectile, firepoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firepoint.position).normalized * projectileSpeed;
        unityGameObjects.Add(projectileObj);
        //listcounter++;
    }
    //public int listcounter = 0;
    private void Update()
    {
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
                        temp--;
                        Debug.Log("Test String " + temp.ToString());

                        m_Object.text = temp.ToString();



                    }
                    Destroy(unityGameObjects[i]);
                    unityGameObjects.RemoveAt(i);
                    //listcounter--;
                }

        }
    }

}
