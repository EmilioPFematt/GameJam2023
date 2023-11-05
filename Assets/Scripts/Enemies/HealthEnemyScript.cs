using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemyScript : MonoBehaviour
{
     private const float acceleration = 40.0f;
    private float maxSpeed = 10.0f;
    private const float attackSpeed = 18.0f;
    private const float normalSpeed = 10.0f;
    private float localSpeed = 0.0f; 
    private GameObject player;
    private float angle = 0.5f;
    public bool active = false;
    public float dist;
    private Animator animator;

    IEnumerator IdleBehavior(){
        while(true){
            bool attack = UnityEngine.Random.Range(0.0f, 1.0f) > 0.3f;
            float newAngle = UnityEngine.Random.Range(0.0f, 1.0f);
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 2.0f));
            setMaxSpeed(attack?attackSpeed:normalSpeed);
            setTarget(newAngle);
        }
    }

    public void SetWakeUp(bool s){
        if(active) return;
        else {
            if(s){
                active = true;
                StartCoroutine(IdleBehavior());
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
         if(GetComponent<Animator>() != null){
            animator = GetComponent<Animator>();
        }
    }
    // Angle esta en PI radians
    public Vector3 FindPosition(float a, float distance){
        return new Vector3(player.transform.position.x + Mathf.Cos(a * Mathf.PI) * distance, player.transform.position.y + Mathf.Sin(a * Mathf.PI) * distance, player.transform.position.z);
    }

    private void setTarget(float a){
        angle = a;
    }

    private void setMaxSpeed(float s){
        maxSpeed = s;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.State == GameState.Game){
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(active){
            animator.SetBool("turnEvil", true);
            Vector3 target = FindPosition(angle, dist);
            target.z = transform.position.z;
            if(Vector3.Distance(transform.position, target) <= 0.1f || localSpeed >= maxSpeed){
                localSpeed -= acceleration * Time.deltaTime;
                if(localSpeed < 0) localSpeed = 0; 
            }
            else {
                localSpeed += acceleration * Time.deltaTime; 
                if(localSpeed > maxSpeed) localSpeed = maxSpeed;
            }
            transform.position = Vector3.MoveTowards(transform.position, target, localSpeed * Time.deltaTime);
            
        }
    }

}
