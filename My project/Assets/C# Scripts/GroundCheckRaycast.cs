using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class GroundCheckRaycast : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 2f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    void Start()
    {
     rb = GetComponent<Rigidbody>();
    }
    void Update()
    {

    if (Input.GetButton("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }     
    bool IsGrounded()
    {
      return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }
}
