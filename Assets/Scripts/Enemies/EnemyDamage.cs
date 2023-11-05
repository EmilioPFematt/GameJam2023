using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamage : MonoBehaviour
{

    [Tooltip("Material to switch to during the flash.")]
    [SerializeField] private Material flashMaterial;


    // The SpriteRenderer that should flash.
    private SpriteRenderer spriteRenderer;
        
    // The material that was in use, when the script started.
    private Material originalMaterial;

    // Start is called before the first frame update
    public int hitPoints = 5;
    private bool canBeHit = true; 

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Bullet") && canBeHit){
            SoundManager.Instance.playSound(1);
            hitPoints--;
            StartCoroutine(FlashRoutine());
            StartCoroutine(Count());
            var health = gameObject.GetComponent<HealthEnemyScript>();
            Debug.Log(health);
            if(health != null){
                health.SetWakeUp(true);
            }
            var sleeping = gameObject.GetComponent<SleepingEnemyScript>();
            Debug.Log(sleeping);
            if(sleeping != null && !GetComponent<SleepingEnemyScript>().awake){
                StartCoroutine(sleeping.WakeUp());
            }
            var swoopingEnemy = gameObject.GetComponent<SwoopingEnemyScript>();
            Debug.Log(swoopingEnemy);
            if(swoopingEnemy != null && !GetComponent<SwoopingEnemyScript>().awake){
                Debug.Log(swoopingEnemy.awake);
                swoopingEnemy.awake = true;
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


    private IEnumerator FlashRoutine()
    {
        // Swap to the flashMaterial.

        Debug.Log("flashroutine");
        // Get the SpriteRenderer to be used,
        // alternatively you could set it from the inspector.
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        // Get the material that the SpriteRenderer uses, 
        // so we can switch back to it after the flash ended.
        originalMaterial = spriteRenderer.material;

        spriteRenderer.material = flashMaterial;

        // Pause the execution of this function for "duration" seconds.
        yield return new WaitForSeconds(0.1f);

        // After the pause, swap back to the original material.
        spriteRenderer.material = originalMaterial;
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