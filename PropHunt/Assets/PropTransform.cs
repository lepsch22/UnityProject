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

                //Destroy(player.GetComponent<MeshRenderer>());
                //Destroy(player.GetComponent<MeshFilter>());
                //player.AddComponent<MeshFilter>();
                //MeshFilter playermesh = player.GetComponent<MeshFilter>();
                //playermesh.mesh = obj.GetComponent<MeshFilter>().mesh;
                //playermesh.mesh = Resources.Load<Mesh>("Chair");
                //player.AddComponent<MeshRenderer>();

                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log($"looking at {obj.name}", this);

                //Mesh mesh = obj.GetComponent<MeshFilter>().sharedMesh;
                //Vector3[] verticies = mesh.vertices;
                //int p = 0;
                //while (p < verticies.Length)
                //{
                //    verticies[p] += new Vector3(0, Random.Range(-0.3F, 0.3F), 0);
                //}
                //Mesh playermesh = player.GetComponent<MeshFilter>().mesh;
                //playermesh.vertices = verticies;
                //playermesh.RecalculateNormals();
                Mesh mesh = obj.GetComponent<MeshFilter>().mesh;
                Mesh mesh2 = Instantiate(mesh);
                //player.GetComponent<MeshFilter>().sharedMesh = mesh2;
                player.GetComponent<MeshFilter>().mesh = mesh2;       
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
