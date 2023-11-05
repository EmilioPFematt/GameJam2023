using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehaviour : MonoBehaviour
{
    private SpriteRenderer render; 
    private Animator playerAnimator;
    private GameObject player; 
    private bool run = false; 
    void Start() {
        render = GetComponent<SpriteRenderer>(); 
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnimator = player.GetComponent<Animator>(); 
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var rightStickX = Input.GetAxisRaw("Mouse X") * -10;
        var rightStickY = Input.GetAxisRaw("Mouse Y") * 10;
        Vector3 Direction =  new Vector3(transform.position.x,transform.position.y, 0) - new Vector3(worldPosition.x,worldPosition.y,0);
        if(Math.Abs(rightStickX) > 0.005f || Math.Abs(rightStickY) > 0.005f) Direction = new Vector3(rightStickX, rightStickY, 0);

        Direction.Normalize();  
        if(Direction.x > 0) {
            render.flipX = true;
        }
        else render.flipX = false;

        transform.up = Direction;
    }
}
