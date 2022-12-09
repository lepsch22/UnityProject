using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopFromPhasing : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform previousPosition;
    private Transform currPosition;
    void Start()
    {
        previousPosition = gameObject.transform;
    }
    private void Update()
    {
        previousPosition = gameObject.transform;
    }

    private void OnCollisionEnter(Collision co) {
        gameObject.transform.position = previousPosition.position;     
    }
}
