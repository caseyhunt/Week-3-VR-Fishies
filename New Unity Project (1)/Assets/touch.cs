using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class touch : MonoBehaviour
{


    public Vector2 startPos;
    public Vector2 direction;

    public GameObject projectile;
    Camera mainCam;
    public float shootForce;
    string message;
    bool hasShot;
    List<GameObject> References;
    int count;

    void Start()
    {
        hasShot = false;
        References = new List<GameObject>();
        count = 0;
    }



    void Update()
    {
        mainCam = Camera.main;
        Quaternion campos = Camera.main.transform.rotation;
        Vector3 camloc = Camera.main.transform.position;
        float xRot = campos.x;
        float yRot = campos.y;
        float zRot = campos.z;


        //if (hasShot == true)
        //{
        //    start_Text.text = "Make black touch green";
        //}
     





        // Track a single touch as a direction control.
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //When a touch has first been detected, change the message and record the starting position
                case TouchPhase.Began:
                    Vector3 sphereStart = camloc + new Vector3(0, 0f, 1.2f);
                    GameObject clone;
                    clone = Instantiate(projectile, sphereStart, transform.rotation);
                    clone.gameObject.tag = "ball";
                    References.Add(clone);
                    References[count].GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Sin(yRot) * 6f, Mathf.Cos(3.14f*xRot)*4.3f, 3.6f) * shootForce);

                    //References[count].GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 10) * shootForce);
                    count++;

                    if (count % 3 == 0)
                    {
                        foreach (GameObject shot in References)
                        {
                            Destroy(shot);
                        }
                    }
                    break;


                //Determine if the touch is a moving touch
                case TouchPhase.Moved:
                    // Determine direction by comparing the current touch position with the initial one
                    direction = touch.position - startPos;
                    message = "Moving ";
                    break;

                case TouchPhase.Ended:
                    // Report that the touch has ended when it ends
                    message = "Ending ";
                    
                    break;
            }
        }
    }

    //void OnGUI()
    //{
    //    mainCam = Camera.main;
    //    Quaternion campos = Camera.main.transform.rotation;
    //    Vector3 camloc = Camera.main.transform.position;
    //    float xRot = campos.x;
    //    float yRot = campos.y;


    //    Event m_Event = Event.current;

    //    if (m_Event.type == EventType.MouseDown)
    //    {
    //        Debug.Log(count);
    //        Debug.Log("Mouse Down.");
    //        Vector3 sphereStart = camloc + new Vector3(0, 1.2f, 0.5f);
    //        GameObject clone;
    //        clone = Instantiate(projectile, sphereStart, transform.rotation);

    //        // Give the cloned object an initial velocity along the current
    //        // object's Z axis
    //        //clone.velocity = transform.TransformDirection(new Vector3(18, 15, 10)*shootForce);
    //        References.Add(clone);
    //        References[count].GetComponent<Rigidbody>().AddForce(new Vector3(0f, 30f, 40f));
    //        count++;

    //        if (count % 3 == 0)
    //        {
    //            foreach (GameObject shot in References)
    //            {
    //                Destroy(shot);
    //            }
    //        }
    //    }
    //}
}


