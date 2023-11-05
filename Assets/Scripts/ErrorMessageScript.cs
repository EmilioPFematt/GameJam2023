using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessageScript : MonoBehaviour
{
    public GameObject foreground;
    public GameObject rightWall;
    public GameObject bossAreanPrefab;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Bullet")){
            foreground.SetActive(false);
            rightWall.SetActive(false);
            Transform playerPosition =  GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            GameObject bossArena = Instantiate(bossAreanPrefab, new Vector3(playerPosition.position.x, 0.25f, playerPosition.position.z), playerPosition.rotation);
            Destroy(this.gameObject);
        }
    }
}
