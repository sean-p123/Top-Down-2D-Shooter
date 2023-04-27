using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunPoint;
    
    private float timer =0f;
    public float wait = 0.3f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
            if (timer >=wait && Input.GetButtonDown("Fire1"))
            {
                Shoot();
                timer = 0f;
        }
            
 
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab, gunPoint.position, transform.rotation);
    }
}
