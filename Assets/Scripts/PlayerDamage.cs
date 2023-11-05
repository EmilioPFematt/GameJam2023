using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int hitPoints = 5;
    private bool canBeHit = true; 
    
    void OnTriggerStay2D(Collider2D other){
        Debug.Log(other.name);
        if((other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Boss")) && canBeHit){
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
                StartCoroutine(Count(other));
            }
        } 
    }
    IEnumerator Count(Collider2D other){
        canBeHit = false;
        Renderer rend = GetComponent<Renderer>();
        Renderer childRend = transform.GetChild(0).gameObject.GetComponent<Renderer>();
        other.gameObject.GetComponent<Collider2D>().enabled = false; 
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0.3f);
        childRend.material.color = new Color(childRend.material.color.r, childRend.material.color.g, childRend.material.color.b, 0.3f);
        yield return new WaitForSeconds(1f);
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 1f);
        childRend.material.color = new Color(childRend.material.color.r, childRend.material.color.g, childRend.material.color.b, 1f);
        other.gameObject.GetComponent<Collider2D>().enabled = true; 
        canBeHit = true; 
    }
    void Update()
    {
        if(hitPoints == 0){
            Death();
        }
    }
    public void Death(){
        //this.enabled = false;
        GameManager.Instance.UpdateGameState(GameState.Death);
        // MusicManager.Instance.ChangeToGameOver();
        // yield return new WaitForSeconds(3f);
        // Scene currentScene = SceneManager.GetActiveScene();
        // SceneManager.LoadScene(currentScene.name);
    }
}