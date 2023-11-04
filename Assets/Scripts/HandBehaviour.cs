using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandBehaviour : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 Direction =  new Vector3(transform.position.x,transform.position.y,0) - new Vector3(worldPosition.x,worldPosition.y,0);
        Direction.Normalize();
        transform.up = Direction;
        
    }
}
