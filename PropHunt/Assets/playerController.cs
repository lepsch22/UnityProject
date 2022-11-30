using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpActionReference;
    [SerializeField] private float jumpForce = 500.0f;


    public GameObject rb;

    private bool _isGrounded => Physics.Raycast(
        new Vector2(rb.transform.position.x,rb.transform.position.y+1f),Vector3.down,3.0f);

    void Start()
    {
        jumpActionReference.action.performed += OnJump;
        
    }
    private void OnJump(InputAction.CallbackContext obj) {
        Debug.Log($"TEST");
        if (!_isGrounded) return;
        Debug.Log($"Adding Force");
        rb.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
    }
    void Update()
    {
        
    }
}
//Disable make the