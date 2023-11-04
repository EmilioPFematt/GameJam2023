using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int hitPoints = 5;
    private bool canBeHit = true; 
    
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("ENTER COLLISION");
        if(other.gameObject.CompareTag("Bullet") && canBeHit){
            Debug.Log("ENTER INSIDE BULLET");
            hitPoints --;
            StartCoroutine(Count());
        }
    }
    IEnumerator Count(){
        Debug.Log("ENTER IENUM");
        canBeHit = false;
        yield return new WaitForSeconds(0.5f);
        canBeHit = true; 
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("HIT POINTS" + hitPoints);
        if(hitPoints == 0){
            Destroy(this.gameObject);
        }
    }
}
