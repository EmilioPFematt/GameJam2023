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
        if(other.gameObject.CompareTag("Enemy") && canBeHit){
            hitPoints --;
            StartCoroutine(Count());
        } 
    }
    IEnumerator Count(){
        canBeHit = false;
        Renderer rend = GetComponent<Renderer>();
        Renderer childRend = transform.GetChild(0).gameObject.GetComponent<Renderer>();
        rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0.3f);
        childRend.material.color = new Color(childRend.material.color.r, childRend.material.color.g, childRend.material.color.b, 0.3f);
        yield return new WaitForSeconds(0.5f);
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