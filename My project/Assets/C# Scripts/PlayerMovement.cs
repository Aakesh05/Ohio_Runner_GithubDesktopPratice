using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    
    
    public float jumpHeight;
    public bool grounded;
    public int maxJumpCount = 2;
    public int jumpsRemaining = 0;

    public Rigidbody rb;

    public float speed = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        if ((Input.GetButtonDown("Jump")) && (jumpsRemaining > 0) )
        {
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            jumpsRemaining -= 1;
            FindObjectOfType<AudioManager>().Play("Jump Sound");
        }


        if(Input.GetAxis("Horizontal") > 0)
        {
            rb.AddForce(Vector3.right * speed);
            FindObjectOfType<AudioManager>().Play("Rolling Sound");
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            rb.AddForce(-Vector3.right * speed);
            FindObjectOfType<AudioManager>().Play("Rolling Sound");
        }

        if(Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(Vector3.forward * speed);
            FindObjectOfType<AudioManager>().Play("Rolling Sound");
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            rb.AddForce(-Vector3.forward * speed);
            FindObjectOfType<AudioManager>().Play("Rolling Sound");
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


























































































































    


