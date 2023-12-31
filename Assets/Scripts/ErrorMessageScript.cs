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
        MusicManager.Instance.StopMusic();
        SoundManager.Instance.playSound(12);
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Bullet")){
            foreground.SetActive(false);
            rightWall.SetActive(false);
            background.SetActive(false);
            Transform playerPosition =  GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            GameObject bossArena = Instantiate(bossAreanPrefab, new Vector3(camera.transform.position.x, 0.25f, 0f), Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
