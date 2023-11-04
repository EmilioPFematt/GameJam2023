using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenericEnemyScript : MonoBehaviour
{
    private Transform target;
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(target !=null){
            Vector3 moveDirection = new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, moveDirection, speed * Time.deltaTime);
        }
        
    }
}
