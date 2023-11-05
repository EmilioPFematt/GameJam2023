using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCameraOppositeDir : MonoBehaviour
{
    public GameObject errorMessage; 
    public GameObject healthBar;
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player") && healthBar == null){
            CameraController.Instance.canMove = false;
            errorMessage.SetActive(true);
            Destroy(gameObject);
        }
    }
     
}
