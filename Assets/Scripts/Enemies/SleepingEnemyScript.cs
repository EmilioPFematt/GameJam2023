using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingEnemyScript : MonoBehaviour
{
    public bool awake = false;
    public float speed = 2.0f;

    private GameObject player;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
        if(GetComponent<Animator>() != null){
            animator = GetComponent<Animator>();
        }

    }

    public IEnumerator WakeUp(){
        awake = true;
        if(GetComponent<Animator>() != null){
            animator.SetBool("wakeUp", true);
            Vector3 currentPosition = transform.position;
            currentPosition.y -= 1.5f;
            transform.position = currentPosition;
            yield return new WaitForSeconds(1f);
            animator.SetBool("walk", true);
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State == GameState.Game){
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(awake){
            Transform target = player.transform;
            Vector3 moveDirection = new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, moveDirection, speed * Time.deltaTime);
        }
        
    }
}
