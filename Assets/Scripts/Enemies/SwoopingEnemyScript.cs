using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Timeline;

public class SwoopingEnemyScript : MonoBehaviour
{

    private Vector3 target;
    public bool awake = false;
    public float speed = 9.0f;
    public float restingHeight = 2.0f; 
    public float restDistance = 10.0f; 
    private GameObject player; 
    private bool attacking = true;
    private int restDirection = -1;
    public float swoopDepth = -4.0f; 
    private bool setTarget = true;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(awake) {
            if(attacking && !setTarget) {
                target = new Vector3(player.transform.position.x, swoopDepth, 0); 
                //setTarget = true;
            }
            else if(!setTarget){
                target = new Vector3(player.transform.position.x + restDistance*restDirection, restingHeight, 0); 
                setTarget = true;
            }
            if(Math.Abs(transform.position.x - target.x) < 0.05f && Math.Abs(transform.position.y - target.y) < 0.05f) { 
                attacking = !attacking;
                if(attacking) restDirection = -Math.Sign(transform.position.x - player.transform.position.x);
                setTarget = false;
            }

            Vector3 s = Vector3.MoveTowards(transform.position, target,  attacking?speed * Time.deltaTime:speed * Time.deltaTime/2);
            transform.position = s;
        }
    }
}
