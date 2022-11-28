using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackCamera : MonoBehaviour
{
    public Camera cameraTrack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(cameraTrack.transform.position.x, 0, cameraTrack.transform.position.z);
        transform.rotation = Quaternion.Euler(0, cameraTrack.transform.rotation.y,0);
        
    }
}
