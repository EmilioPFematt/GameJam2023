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
            SoundManager.Instance.playSound(1);
            hitPoints--;
            StartCoroutine(Count());
            var health = GetComponent<HealthEnemyScript>();
            if(health != null){
                health.SetWakeUp(true);
            }
            var sleeping = GetComponent<SleepingEnemyScript>();
            if(sleeping != null && !GetComponent<SleepingEnemyScript>().awake){
                StartCoroutine(sleeping.WakeUp());
            }
        } 
    }
    IEnumerator Count(){
        canBeHit = false;
        Renderer rend = GetComponent<Renderer>();
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0.7f);
        //rend.material.color = new Color(1f, 1f, 1f, 1f);
        Color ogColor = rend.material.color;
        yield return new WaitForSeconds(0.5f);
        //rend.material.color = new Color(1f, 1f, 1f, 1f);
        //yield return new WaitForSeconds(0.1f);
        rend.material.color = new Color(ogColor.r, ogColor.g, ogColor.b, 1f);
        canBeHit = true; 
    }
    void Update()
    {
        if(hitPoints == 0 && !gameObject.CompareTag("Boss")){
            Destroy(this.gameObject);
        } else if(hitPoints == 0 && gameObject.CompareTag("Boss") ){
            GameManager.Instance.UpdateGameState(GameState.End);
        }
    }
}