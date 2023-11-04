using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehaviour : MonoBehaviour
{
    private SpriteRenderer render; 
    void Start() {
        render = GetComponent<SpriteRenderer>(); 
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(transform.position.x > worldPosition.x) {
            render.flipX = true;
        }
        else render.flipX = false;
        Vector3 Direction =  new Vector3(transform.position.x,transform.position.y,0) - new Vector3(worldPosition.x,worldPosition.y,0);
        Direction.Normalize();
        transform.up = Direction;
    }
}
