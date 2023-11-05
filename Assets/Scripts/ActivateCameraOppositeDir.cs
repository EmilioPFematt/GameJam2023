using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCameraOppositeDir : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            CameraController.Instance.canMove = true;
        }
    }
     void OnTriggerExit2D (Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            CameraController.Instance.canMove = false;
        }
    }
}
