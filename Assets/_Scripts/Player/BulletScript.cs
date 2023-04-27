using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (Vector2)(transform.up * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<ZombieScript>();
        
        if (collision.gameObject.tag == "Zombie")
        {
            Debug.Log("bullet collision with zombie");
            Destroy(gameObject);
            enemy.Hurt();
        }

        if (collision.gameObject.tag == "Obstacles")
        {
            Destroy(gameObject);
        }
      
    }
}
