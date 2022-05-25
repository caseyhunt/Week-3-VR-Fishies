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
    //Renderer m_Renderer;
    public Text m_Text;
    public Text n_Text;
    public Text start_Text;
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
        //Update the Text on the screen depending on current TouchPhase, and the current direction vector
        m_Text.text = "Touch : " + message + "in direction" + direction;
        n_Text.text = "Camera Pos:" + campos;


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
                    // Record initial touch position.
                    startPos = touch.position;
                    message = "Begun ";
                    Vector3 sphereStart = camloc + new Vector3(0, 1.2f, 0.5f);

                    References.Add((GameObject)Instantiate(projectile, sphereStart, transform.rotation));
                    //GameObject shot = GameObject.Instantiate(projectile, sphereStart, transform.rotation) as GameObject;
                    //shot.gameObject.tag = "spheres";
                    hasShot = true;
                    References[count].GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Sin(yRot)*18, -Mathf.Sin(xRot)*15, 10) * shootForce);
                    count++;
                    //if (goal.collided == true)
                    //{
                    //    foreach (GameObject shot in References)
                    //    {
                    //        shot.SetActive(false);
                    //        count = 0;
                    //    }
                    //}



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
}

