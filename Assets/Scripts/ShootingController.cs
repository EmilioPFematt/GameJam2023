using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public float timeSinceLastFire = 0.0f;

    public float fireRate = 5f;
    public float bulletSpeed = 5.0f;
    public GameObject bullet;

    private Camera mainCamera;
    void Start(){
        mainCamera = Camera.main;
    }
    void Update(){
        if(Input.GetMouseButton(0)){
            Shoot();
        }
    }
    private void Shoot(){
        if ((Time.time - timeSinceLastFire) >= (1f/fireRate)) {
            // Obtener dirección de disparo
            Vector3 worldMousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = worldMousePos - transform.position;
            direction.Normalize();
            GameObject newBullet;            
            newBullet = Instantiate(bullet, transform.position, transform.rotation);
            /*clone.GetComponent<PlayerBullet>().bulletDamage = bulletDamage;
            clone.GetComponent<PlayerBullet>().bulletSpeed = bulletSpeed;
            clone.GetComponent<PlayerBullet>().bulletDirection = direction;*/
            newBullet.GetComponent<Rigidbody2D>().velocity = (direction) * (bulletSpeed);


            // Actualizar
            timeSinceLastFire = Time.time;
        }
    }
}
