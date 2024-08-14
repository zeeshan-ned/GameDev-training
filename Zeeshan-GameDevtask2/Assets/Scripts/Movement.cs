using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    Rigidbody rb;
    float xInput;
    float zInput;
    public float speed;
    public float jumpforce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce);
        }
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        rb.AddForce(xInput * speed, 0, zInput * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
