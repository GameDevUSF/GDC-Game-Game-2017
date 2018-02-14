using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject Als;
    private GameObject Ars;
    public float speed = 0.5f;

    private bool ArmUsedSlapIn;
    private bool ArmUsedSlapDown;
    private bool ArmUsedSlapUp;

    // Use this for initialization
    void Start ()
    {
        Als = GameObject.FindGameObjectWithTag("Arm_Left");
        Ars = GameObject.FindGameObjectWithTag("Arm_Right");
        ArmUsedSlapIn = true;
        ArmUsedSlapDown = true;
        ArmUsedSlapUp = true;
    }

    // Update is called once per frame
    void Update ()
    {
        Quaternion origin = Quaternion.identity;

        Quaternion slapInLeft = Quaternion.Euler(0, 35, 0);
        Quaternion slapInRight = Quaternion.Euler(0, -35, 0);

        Quaternion slapDown = Quaternion.Euler(30, 0, 0);
        Quaternion slapUp = Quaternion.Euler(-30, 0, 0);


        //Slap In Left and Right
        if (Input.GetKeyDown(KeyCode.Space) && ArmUsedSlapIn == false)
        {
            Als.transform.rotation = Quaternion.Slerp(Als.transform.rotation, slapInLeft, speed);
        }
        else if (Input.GetKeyUp(KeyCode.Space) && ArmUsedSlapIn == false)
        {
            Als.transform.rotation = Quaternion.Slerp(Als.transform.rotation, origin, speed);
            ArmUsedSlapIn = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && ArmUsedSlapIn == true)
        {
            Ars.transform.rotation = Quaternion.Slerp(Ars.transform.rotation, slapInRight, speed);
        }
        else if (Input.GetKeyUp(KeyCode.Space) && ArmUsedSlapIn == true)
        {
            Ars.transform.rotation = Quaternion.Slerp(Ars.transform.rotation, origin, speed);
            ArmUsedSlapIn = false;
        }


        //Slap Down Left and Right
        if (Input.GetMouseButtonDown(0) && ArmUsedSlapDown == false)
        {
            Als.transform.rotation = Quaternion.Slerp(Als.transform.rotation, slapDown, speed);
        }
        else if(Input.GetMouseButtonUp(0) && ArmUsedSlapDown == false)
        {
            Als.transform.rotation = Quaternion.Slerp(Als.transform.rotation, origin, speed);
            ArmUsedSlapDown = true;
        }
        else if (Input.GetMouseButtonDown(0) && ArmUsedSlapDown == true)
        {
            Ars.transform.rotation = Quaternion.Slerp(Ars.transform.rotation, slapDown, speed);
        }
        else if (Input.GetMouseButtonUp(0) && ArmUsedSlapDown == true)
        {
            Ars.transform.rotation = Quaternion.Slerp(Ars.transform.rotation, origin, speed);
            ArmUsedSlapDown = false;
        }

        //Slap Up Left and Right
        if (Input.GetMouseButtonDown(1) && ArmUsedSlapUp == false)
        {
            Als.transform.rotation = Quaternion.Slerp(Als.transform.rotation, slapUp, speed);
        }
        else if (Input.GetMouseButtonUp(1) && ArmUsedSlapUp == false)
        {
            Als.transform.rotation = Quaternion.Slerp(Als.transform.rotation, origin, speed);
            ArmUsedSlapUp = true;
        }
        else if (Input.GetMouseButtonDown(1) && ArmUsedSlapUp == true)
        {
            Ars.transform.rotation = Quaternion.Slerp(Ars.transform.rotation, slapUp, speed);
        }
        else if (Input.GetMouseButtonUp(1) && ArmUsedSlapUp == true)
        {
            Ars.transform.rotation = Quaternion.Slerp(Ars.transform.rotation, origin, speed);
            ArmUsedSlapUp = false;
        }


    }
}
