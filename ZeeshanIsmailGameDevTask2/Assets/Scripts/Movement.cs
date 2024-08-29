/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    Animator anim;
    public float JumpForce;
    public float speed;
    float xInput;
    float zInput;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpForce);
        }
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        rb.AddForce(xInput * speed, 0, zInput * speed);

        anim.SetFloat("runningSpeed", Mathf.Abs(Input.GetAxis("Horizontal")) + Mathf.Abs(Input.GetAxis("Vertical")));
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public Animator playerAnim;
	public Rigidbody playerRigid;
	public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
	public float JumpForce;
	public bool walking;
	public Transform playerTrans;

	// Start is called before the first frame update
	void Start()
	{
		playerRigid = GetComponent<Rigidbody>();
		playerAnim = GetComponent<Animator>();
	}


	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			playerRigid.AddForce(Vector3.up * JumpForce);
		}
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			playerAnim.SetTrigger("jump");
			playerAnim.ResetTrigger("idle");
			
		}
		if (Input.GetKeyUp(KeyCode.Space))
		{
			playerAnim.ResetTrigger("walk");
			playerAnim.SetTrigger("idle");
			
			//steps1.SetActive(false);
		}
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			playerAnim.SetTrigger("walk");
			playerAnim.ResetTrigger("idle");
			walking = true;
			//steps1.SetActive(true);
		}
		if (Input.GetKeyUp(KeyCode.UpArrow))
		{
			playerAnim.ResetTrigger("walk");
			playerAnim.SetTrigger("idle");
			walking = false;
			//steps1.SetActive(false);
		}
		if (Input.GetKeyDown(KeyCode.DownArrow))
		{
			playerAnim.SetTrigger("walkback");
			playerAnim.ResetTrigger("idle");
			//steps1.SetActive(true);
		}
		if (Input.GetKeyUp(KeyCode.DownArrow))
		{
			playerAnim.ResetTrigger("walkback");
			playerAnim.SetTrigger("idle");
			//steps1.SetActive(false);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
		}
		if (walking == true)
		{
			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				//steps1.SetActive(false);
				//steps2.SetActive(true);
				w_speed = w_speed + rn_speed;
				playerAnim.SetTrigger("run");
				playerAnim.ResetTrigger("walk");
			}
			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				//steps1.SetActive(true);
				//steps2.SetActive(false);
				w_speed = olw_speed;
				playerAnim.ResetTrigger("run");
				playerAnim.SetTrigger("walk");
			}
		}
	}
}
