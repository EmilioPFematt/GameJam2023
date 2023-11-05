using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideToSide : MonoBehaviour
{
    private float timeBeforeChange = 0.0f;
    public float timeToMove = 0.5f;
    public float speed = 2.0f;
    private float newX;
    private bool movingRight = true;

    void Update()
    {
        if (timeBeforeChange <= 0)
        {
            timeBeforeChange = timeToMove;
            movingRight = !movingRight;
        }

        float moveDistance = speed * Time.deltaTime;
        newX = transform.position.x + (movingRight ? moveDistance : -moveDistance);
        timeBeforeChange -= Time.deltaTime;

        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}
