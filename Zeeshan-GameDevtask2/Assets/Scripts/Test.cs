using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Test : MonoBehaviour
{
    Rigidbody rb;
    public GameObject winText;
    float xInput;
    float zInput;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject,5f);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Destroy(gameObject);
            rb.AddForce(Vector3.up * 500);
        }
        //rb.velocity = Vector3.forward * 20f;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("level2");
        }
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput * speed, 0, zInput * speed);
    }
    private void OnMouseDown()
    {
        //Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Destroy(gameObject);
            Destroy(collision.gameObject);
            winText.SetActive(true);
        }
    }
}
