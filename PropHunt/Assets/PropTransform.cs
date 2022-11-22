using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropTransform : MonoBehaviour
{
    public LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if(Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, mask)){
        //Physics.Raycast()
        var obj = hit.collider.gameObject;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        Debug.Log($"looking at {obj.name}", this);
    }
    else{
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        Debug.Log("Looking at nothing.");
    }
        
    }
}
