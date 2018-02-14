using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private bool isAlive;
    public float force = 20f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");


        /*Vector3 movement = new Vector3(h, 0.0f, v);
        transform.rotation = Quaternion.LookRotation(movement);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        */

        transform.position += transform.forward * speed * v * Time.deltaTime;
        transform.position += transform.right * speed * h * Time.deltaTime;

        Quaternion turnLeft = Quaternion.Euler(0, -90, 0);
        Quaternion turnRight = Quaternion.Euler(0, 90, 0);
        Quaternion turnAround = Quaternion.Euler(0, 180, 0);

        //transform.rotation = Quaternion.Slerp(transform.rotation, turnLeft, speed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, turnRight, speed);
        //transform.rotation = Quaternion.Slerp(transform.rotation, turnAround, speed);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Vector3 dir = col.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * force);
        }
    
    }
}
