using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    public float cameraSpeed;
    private GameObject player;
    private bool isAlive;
    public float force = 20f;

    private Collider Pal;
    private Collider Par;

    public Camera cameraMain;
    public Camera cameraPause;

    public Camera cameraReal;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        isAlive = true;

        Pal = GameObject.FindGameObjectWithTag("Arm_Left_Cube").GetComponent<Collider>();
        Par = GameObject.FindGameObjectWithTag("Arm_Right_Cube").GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance = player.transform.position - gameObject.transform.position;

        if (Vector3.Magnitude(distance) > -5 && Vector3.Magnitude(distance) < 5 && isAlive == true)
        {
            transform.position += Vector3.Normalize(distance) * speed * Time.deltaTime;
        }

        Vector3 dist = transform.position - Pal.transform.position;

        if (Vector3.Magnitude(dist) < 1.5)
        {
            cameraMain.transform.rotation = Quaternion.Lerp(cameraMain.transform.rotation, cameraPause.transform.rotation, Time.deltaTime * cameraSpeed);
            cameraMain.transform.position = Vector3.Lerp(cameraMain.transform.position, cameraPause.transform.position, Time.deltaTime * cameraSpeed);
        }

        /*if (isAlive == false)
        {
            cameraReal.transform.rotation = Quaternion.Lerp(cameraPause.transform.rotation, cameraMain.transform.rotation, Time.deltaTime * cameraSpeed);
            cameraReal.transform.position = Vector3.Lerp(cameraPause.transform.position, cameraMain.transform.position, Time.deltaTime * cameraSpeed);
        }*/

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider == Pal || col.collider == Par)
        {
            Vector3 dir = col.contacts[0].point - transform.position;
            dir = -dir.normalized;
            GetComponent<Rigidbody>().AddForce(dir * force);

            isAlive = false;
        }
    }
}
