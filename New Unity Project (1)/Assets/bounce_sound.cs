using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class bounce_sound : MonoBehaviour
  
{
    AudioSource audioSource;

    

    // Start is called before the first frame update
    void Start()
    {
         audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
    
           

    }



}
