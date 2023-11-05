    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowBoss : MonoBehaviour
{
    public bool isSpawned;

    private Animator windowAnimator;

    public GameObject child;
    private HealthEnemyScript hes;

    void Start() {
        windowAnimator = gameObject.GetComponent<Animator>();
        hes = gameObject.GetComponent<HealthEnemyScript>();
    }

    void Update(){
        if(isSpawned){
            windowAnimator.Play("WindowAnim");
            hes.enabled = true;
        }
    }
}
