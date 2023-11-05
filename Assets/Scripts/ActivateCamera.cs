using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateCamera : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("CHANGE!!");
            CameraController.Instance.canMove = false;
        }
    }
     void OnTriggerExit2D (Collider2D other){
        if(other.gameObject.CompareTag("Player")){

            Debug.Log("CHANGE TRUE!!");
            CameraController.Instance.canMove = true;
        }
    }
}
