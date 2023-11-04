using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{

    private float acceleration = 10;
    private float maxSpeed = 8;
    private float localSpeed = 0; 
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        acceleration = 50;
        maxSpeed = 8;
    }
    // Angle esta en PI radians
    public Vector3 FindPosition(float angle, float distance){
        return new Vector3(player.transform.position.x + Mathf.Cos(angle * Mathf.PI) * distance, player.transform.position.y + Mathf.Sin(angle * Mathf.PI) * distance, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = FindPosition(0.25f, 10.0f);
        if(Vector3.Distance(transform.position, target) < 0.1f || localSpeed >= maxSpeed){
            localSpeed -= acceleration * Time.deltaTime; 
        }
        else {
            localSpeed += acceleration * Time.deltaTime; 
        }
        transform.position = Vector3.MoveTowards(transform.position, target, localSpeed * Time.deltaTime);
    }
}
