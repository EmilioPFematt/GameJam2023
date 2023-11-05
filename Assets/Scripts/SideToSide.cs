using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour
{
    private float timeBeforeChange = 0.0f; 
    public float timeToMove = 0.5f;
    public float speed = 2.0f;
    private float newX;
    private bool movingRight = false; 

    // Update is called once per frame
    void Update()
    {
        if(timeBeforeChange > 0){
                newX = transform.position.x + (movingRight ? speed * Time.deltaTime : -speed * Time.deltaTime);
                timeBeforeChange -= Time.deltaTime;
            } else{
                timeBeforeChange  = timeToMove;
                movingRight = !movingRight;
            }
            // Update the object's position
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
