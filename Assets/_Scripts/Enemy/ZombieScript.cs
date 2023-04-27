using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{

    private Rigidbody2D rb;
    private PlayerController player;
    public float baseSpeed = 3;
    private float speed;
    public int enemyHealth = 1;
    private bool isCollidingWithPlayer = false;
    private Collider2D playerCollider;

    public float waitTime = 1f;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        //Changes zombie speed to make them random speeds
        speed = baseSpeed * (1 + Random.Range(-0.1f, 0.1f));
        player = FindObjectOfType<PlayerController>();
        playerCollider = player.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (isCollidingWithPlayer)
            {
                // If colliding with the player, stop moving
                rb.velocity = Vector2.zero;
                timer += Time.deltaTime;

                //wait a specified amount of time after collision to move again
                if (timer >= waitTime)
                {
                    isCollidingWithPlayer = false;
                    timer = 0.0f;
                }

            }
            else
            {
                //makes enemy always face the player
                transform.up = (player.transform.position - transform.position).normalized;
                rb.velocity = transform.up * speed;

                // Check if colliding with the player
                if (playerCollider.IsTouching(GetComponent<Collider2D>()))
                {
                    isCollidingWithPlayer = true;
                }
            }

        }

    }

    public void Hurt()
    {
        enemyHealth--;

        if(enemyHealth <= 0)
        {
            Die();
            LifeScoreManager.instance.updateKills();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
        player.KillCount();
    }
}
