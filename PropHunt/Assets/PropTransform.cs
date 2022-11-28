using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropTransform : MonoBehaviour
{
    public LayerMask mask;
    public GameObject player;
    bool release = true;
    //Vector3[] newVerticies;
    //Vector2[] newUV;
    //int[] newtriangles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && release)
        {
            //release = false;
            if (Physics.Raycast(transform.position, transform.forward, out var hit, Mathf.Infinity, mask))
            {
                var obj = hit.collider.gameObject;
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log($"looking at {obj.name}", this);
                Mesh mesh = obj.GetComponent<MeshFilter>().mesh;
                Mesh mesh2 = Instantiate(mesh);
                Mesh meshCollider = player.GetComponent<MeshCollider>().sharedMesh;
                player.GetComponent<MeshCollider>().sharedMesh = mesh2;
                player.GetComponent<MeshFilter>().mesh = mesh2;
                player.GetComponent<MeshRenderer>().material = obj.GetComponent<MeshRenderer>().material;
                player.transform.rotation = obj.transform.rotation;
                player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Looking at nothing.");
            }
        }
        else {
            //release = true;
        }
        
    }
}
