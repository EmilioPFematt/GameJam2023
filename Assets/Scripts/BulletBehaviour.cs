using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private int cicleLives = 50; 
    // Sta rt is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        cicleLives--;
        if(cicleLives <= 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag != "Player" && other.gameObject.tag != "trigger"){
            Destroy(gameObject);
        }
    }
}
