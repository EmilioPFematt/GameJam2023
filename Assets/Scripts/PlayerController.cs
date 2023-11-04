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
    private SpriteRenderer render;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }
    public float getSpeed() {
        return localVelocity;
    }
    /**
    * Checks if player is grounded by raycasting down to check if a collider exists below the player.
    */
    private bool isGrounded(){
        return Physics2D.Raycast(transform.position, -transform.up, 5.0f);
    }
    // Update is called once per frame
    void Update()
    {   
        // Recieve horizontal input from the player
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        /*if(Math.Abs(horizontalInput) > 0.4f) horizontalInput = horizontalInput > 0f?1f:-1f;
        else horizontalInput = 0;*/
        //Debug.Log(horizontalInput);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(transform.position.x > worldPosition.x) {
            render.flipX = true;
        }
        else render.flipX = false;
        //Process jump using unity physics
        if(Input.GetKeyDown(KeyCode.Space)) {
            //Debug.Log(isGrounded());
            if(isGrounded()) rb.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
        }

        // Calculate velocity using acceleration variables
        if(horizontalInput != 0){
            localVelocity += playerAccel * horizontalInput * Time.deltaTime; 
            if(Math.Abs(localVelocity) > maxSpeed) localVelocity = maxSpeed * Math.Sign(localVelocity);
        }
        else { 
            localVelocity = (Math.Abs(localVelocity) - playerAccel * frictionMult * Time.deltaTime) * Math.Sign(localVelocity); 
            if(Math.Abs(localVelocity) < 0.05f) localVelocity = 0;
        }
        
        transform.position = new Vector3(transform.position.x + localVelocity * Time.deltaTime, transform.position.y, transform.position.z);
    }   
}
