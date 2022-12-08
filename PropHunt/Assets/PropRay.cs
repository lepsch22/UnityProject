using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PropRay : MonoBehaviour
{
    [SerializeField] private InputActionReference triggerActionReference;
    //[SerializeField] private float jumpForce = 500.0f;
    //public GameObject rb;

    public bool propChanged;
    public LayerMask mask;
    public GameObject player;
    public GameObject collidedObject;

    void Start()
    {
        triggerActionReference.action.performed += PropChange;

    }
    void PropChange(InputAction.CallbackContext ob) {
        if (Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, mask))
        {

            var obj = hit.collider.gameObject;
            collidedObject = obj;
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log($"looking at {obj.name}", this);
            Mesh mesh = obj.GetComponent<MeshFilter>().mesh;
            Mesh mesh2 = Instantiate(mesh);
            player.GetComponent<MeshCollider>().sharedMesh = mesh2;
            player.GetComponent<MeshFilter>().mesh = mesh2;
            player.GetComponent<MeshRenderer>().materials = obj.GetComponent<MeshRenderer>().materials;
            player.transform.rotation = obj.transform.rotation;
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
            propChanged = true;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Looking at nothing.");
        }
    }
}

    
