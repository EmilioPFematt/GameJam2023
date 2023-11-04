using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int hitPoints = 5;
    public float knockForce = 100f;
    private bool canBeHit = true; 
    public UnityEvent OnBegin, OnDone;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Bullet") && canBeHit){
            hitPoints --;
            StartCoroutine(Count());
        } 
    }
    /*void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("COLLIDING PLAYER");
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            Vector2 opposite = -other.relativeVelocity.normalized;
            rb.AddForce(opposite * knockForce, ForceMode2D.Impulse);
        }
    }*/
    IEnumerator Count(){
        canBeHit = false;
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0.3f);
        yield return new WaitForSeconds(0.5f);
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 1f);
        canBeHit = true; 
    }
    // Update is called once per frame
    void Update()
    {
        if(hitPoints == 0){
            Destroy(this.gameObject);
        }
    }
}