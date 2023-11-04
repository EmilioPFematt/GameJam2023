using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int hitPoints = 5;
    private bool canBeHit = true; 
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Bullet") && canBeHit){
            hitPoints--;
            StartCoroutine(Count());
            var hc = GetComponent<HealthEnemyScript>();
            if(hc != null){
                hc.SetWakeUp(true);
            }
            var ge = GetComponent<GenericEnemyScript>();
            if(ge != null){
                ge.WakeUp();
            }
        } 
    }
    IEnumerator Count(){
        canBeHit = false;
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0.3f);
        yield return new WaitForSeconds(0.5f);
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 1f);
        canBeHit = true; 
    }
    void Update()
    {
        if(hitPoints == 0){
            Destroy(this.gameObject);
        }
    }
}