using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemyScript : MonoBehaviour
{
     private const float acceleration = 60.0f;
    private float maxSpeed = 10.0f;
    private const float attackSpeed = 18.0f;
    private const float normalSpeed = 10.0f;
    private float localSpeed = 0.0f; 
    public GameObject player;
    private float angle = 0.5f;

    IEnumerator IdleBehavior(){
        while(true){
            bool attack = UnityEngine.Random.Range(0.0f, 1.0f) > 0.3f;
            float newAngle = attack?angle+1:UnityEngine.Random.Range(0.0f, 1.0f);
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.5f, 3.0f));
            setMaxSpeed(attack?attackSpeed:normalSpeed);
            setTarget(newAngle);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IdleBehavior());
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
        Vector3 target = FindPosition(angle, 7.0f);
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
