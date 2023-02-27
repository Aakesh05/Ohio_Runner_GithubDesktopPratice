using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    Rigidbody rb;
    public float jumpHeight;
    public bool grounded;

    public int maxJumpCount = 2;
    public int jumpsRemaining = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetButtonDown("Jump")) && (jumpsRemaining > 0) )
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumpsRemaining -= 1;
        }
    }


    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
            jumpsRemaining = maxJumpCount;
        }
    }

    public void OnCollisionExit(Collision collision)
{
    if(collision.gameObject.tag == "Ground")
    {
        grounded = false;
    }
}
}
