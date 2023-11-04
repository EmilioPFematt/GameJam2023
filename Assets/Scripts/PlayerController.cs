using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxSpeed;
    public float playerAccel; 
    private Rigidbody2D rb;
    private float localVelocity=0; 
    public float jumpSpeed; 
    public float frictionMult;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public float getSpeed() {
        return localVelocity;
    }
    /**
    * Checks if player is grounded by raycasting down to check if a collider exists below the player.
    */
    private bool isGrounded(){
        Debug.Log("Here");
        return Physics2D.Raycast(transform.position, -transform.up, 1.1f);
    }
    // Update is called once per frame
    void Update()
    {   
        // Recieve horizontal input from the player
        int horizontalInput = (Input.GetKey(KeyCode.D)?1:0) - (Input.GetKey(KeyCode.A)?1:0);
        
        //Process jump using unity physics
        if(Input.GetKeyDown(KeyCode.Space)) {
            //Debug.Log(isGrounded());
            if(isGrounded()) rb.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
        }

        // Calculate velocity using acceleration variables
        if(horizontalInput != 0){
            localVelocity = localVelocity + playerAccel * horizontalInput * Time.deltaTime; 
            if(Math.Abs(localVelocity) > maxSpeed) localVelocity = maxSpeed * Math.Sign(localVelocity);
        }
        else { 
            localVelocity = (Math.Abs(localVelocity) - playerAccel * frictionMult * Time.deltaTime) * Math.Sign(localVelocity); 
            if(Math.Abs(localVelocity) < 0.05f) localVelocity = 0;
        }
        
        transform.position = new Vector3(transform.position.x + localVelocity * Time.deltaTime, transform.position.y, transform.position.z);
    }   
}
