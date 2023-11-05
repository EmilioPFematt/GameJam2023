using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float leftBound; 
    public float rightBound; 
    public bool canMove = false; 

    public static CameraController Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove){
            float localX = player.transform.position.x - transform.position.x;
            float playerSpeed = player.GetComponent<PlayerController>().getSpeed();
            if(localX >= rightBound || localX <= leftBound) 
                transform.position = new Vector3(transform.position.x + playerSpeed*Time.deltaTime, transform.position.y, transform.position.z);
        }
    }
}
