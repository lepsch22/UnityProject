using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewCanvas : MonoBehaviour
{
    public GameObject wristCanvas;
    public GameObject leftController;    

    // Start is called before the first frame update
    void Start()
    {
        wristCanvas.setActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(leftController.rotation.x > 90)

        
    }
}
