using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class jumpController : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] private float jumpForce = 500.0f;


    public GameObject rb;
    public bool _isGrounded = true;
    /*
    private bool _isGrounded2 => Physics.Raycast(
        new Vector2(rb.transform.position.x,rb.transform.position.y+1f),Vector3.down,5.0f);
    */

    void Start()
    {
        jumpActionReference.action.performed += Jump;
        
    }
    /*
    private void OnJump(InputAction.CallbackContext obj) {
        Debug.Log($"TEST");
        if (!_isGrounded) return;
        Debug.Log($"Adding Force");
        rb.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
    }
    */
    private void Jump(InputAction.CallbackContext obj) 
    {
        Debug.Log("Attempt Jump");
        if (_isGrounded) 
        {
            _isGrounded = false;
            rb.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        _isGrounded = true;
    }

}
//Disable make the