using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;
    public GameObject projectile;
    Camera mainCam;
    public float shootForce;
    bool hasShot;
    List<GameObject> References;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        hasShot = false;
        References = new List<GameObject>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mainCam = Camera.main;
        Quaternion campos = Camera.main.transform.rotation;
        Vector3 camloc = Camera.main.transform.position;
        float xRot = campos.x;
        float yRot = campos.y;

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
                    Vector3 sphereStart = camloc + new Vector3(0, 1.2f, 0.5f);

                    References.Add((GameObject)Instantiate(projectile, sphereStart, transform.rotation));
                    //GameObject shot = GameObject.Instantiate(projectile, sphereStart, transform.rotation) as GameObject;
                    //shot.gameObject.tag = "spheres";
                    hasShot = true;
                    References[count].GetComponent<Rigidbody>().AddForce(new Vector3(Mathf.Sin(yRot) * 18, -Mathf.Sin(xRot) * 15, 10) * shootForce);
                    count++;
                    break;
            }
        }
    }
}
