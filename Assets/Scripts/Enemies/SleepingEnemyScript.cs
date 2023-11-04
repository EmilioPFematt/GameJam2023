using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingEnemyScript : MonoBehaviour
{
    public bool awake = false;
    public float speed = 2.0f;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void WakeUp(){
        awake = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(awake){
            Transform target = player.transform;
            Vector3 moveDirection = new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, moveDirection, speed * Time.deltaTime);
        }
        
    }
}
