using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 public class PlayerLife : MonoBehaviour
{
    public bool death = false; 

    void Update()
    {
        if (transform.position.y < -1f && !death)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            Die();
            FindObjectOfType<AudioManager>().Play("Death Sound");
        }
    }
    void Die()
    {
        Invoke(nameof(ReloadLevel), 1f);
        death = true;
    }
    void ReloadLevel()
    {
        SceneManager.LoadScene(1);
        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = true;
    }
}
