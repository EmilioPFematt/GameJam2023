using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxSpeed = 20;
    public float playerAccel = 10; 
    private Rigidbody2D rb;
    private float localVelocity=0; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        int horizontalInput = (Input.GetKey(KeyCode.D)?1:0) - (Input.GetKey(KeyCode.A)?1:0);
        localVelocity = localVelocity + playerAccel * horizontalInput * Time.deltaTime; 
        
    }
}
