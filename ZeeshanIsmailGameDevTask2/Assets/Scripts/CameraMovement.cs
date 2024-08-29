/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = player.transform.position + offset;
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player, cameraTrans;
    public Vector3 offset;

    void Update()
    {
        gameObject.transform.position = player.transform.position + offset;
        cameraTrans.LookAt(player);
    }
}