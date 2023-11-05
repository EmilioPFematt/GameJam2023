using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEnemyAwakeScript : MonoBehaviour
{
    public GameObject enemy;
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            enemy.GetComponent<SwoopingEnemyScript>().setAwake();
            Destroy(this);
        }
    }
}
