using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorMessageScript : MonoBehaviour
{
    public GameObject foreground;
    public GameObject rightWall;
    public GameObject bossAreanPrefab;
    public GameObject background;
    Camera camera;
    void Awake(){
        camera = Camera.main;
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Bullet")){
            foreground.SetActive(false);
            rightWall.SetActive(false);
            background.SetActive(false);
            Transform playerPosition =  GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            GameObject bossArena = Instantiate(bossAreanPrefab, camera.ViewportToWorldPoint(new Vector2(0.5f, 0.5f)), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
