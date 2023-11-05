using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int hitPoints = 5;
    private bool canBeHit = true; 
    
    void OnTriggerStay2D(Collider2D other){
        Debug.Log(other.name);
        if(other.gameObject.CompareTag("Enemy") && canBeHit){
            var sleeping = other.GetComponent<SleepingEnemyScript>();
            var health = other.GetComponent<HealthEnemyScript>();  
            bool damage = true;
            if(sleeping != null){
                damage = sleeping.awake;
            }
            else if(health != null){
                damage = health.active;
            }
            if(damage){ 
                hitPoints --;
                SoundManager.Instance.playSound(2);
                StartCoroutine(Count());
            }
        } 
    }
    IEnumerator Count(){
        canBeHit = false;
        Renderer rend = GetComponent<Renderer>();
        Renderer childRend = transform.GetChild(0).gameObject.GetComponent<Renderer>();
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0.3f);
        childRend.material.color = new Color(childRend.material.color.r, childRend.material.color.g, childRend.material.color.b, 0.3f);
        yield return new WaitForSeconds(2f);
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 1f);
        childRend.material.color = new Color(childRend.material.color.r, childRend.material.color.g, childRend.material.color.b, 1f);
        canBeHit = true; 
    }
    void Update()
    {
        if(hitPoints == 0){
            Debug.Log("PLAYER IS DEAD");
        }
    }
}