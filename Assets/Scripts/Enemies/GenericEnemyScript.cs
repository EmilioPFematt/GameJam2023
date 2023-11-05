using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GenericEnemyScript : MonoBehaviour
{
    public float speed = 2.0f;

    private GameObject player;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State == GameState.Game){
            player = GameObject.FindGameObjectWithTag("Player");
        }
        Transform target = player.transform;
        Vector3 moveDirection = new Vector3(target.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, moveDirection, speed * Time.deltaTime);
    }
}
