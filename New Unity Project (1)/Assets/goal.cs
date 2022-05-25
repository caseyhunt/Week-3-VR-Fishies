using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class goal : MonoBehaviour
  
{
    AudioSource audioSource;
    public GameObject cup;
    bool collided;
    

    // Start is called before the first frame update
    void Start()
    {
         audioSource = GetComponent<AudioSource>();
         collided = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        UnityEngine.Debug.Log("collision");
        if (other.gameObject.tag == "ball")
        {
            Destroy(other.gameObject);
            Destroy(cup,2f);
           
           
        }
    }




    void whenCollided()
    {
      

    }
    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("collided with box");
        
    //    if (collision.relativeVelocity.magnitude > 2)
    //        audioSource.Play();
    //}
}
