using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Canvas restartCanvas;
    public Canvas winScreenCanvas;

    private Rigidbody2D rb;
    private Vector2 hvInput;

    public float speed = 2f;
    public int playerHealth = 5;
    private bool isMovementEnabled = true;

    private int killCount = 0;
    public int killsNeeded = 16;
    private bool winRound = false;
    // Start is called before the first frame update
    void Start()
    {
        restartCanvas.enabled = false;
        winScreenCanvas.enabled = false;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMovementEnabled)
        { 
            hvInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - (Vector2)transform.position;
            transform.up = direction;

            rb.velocity = hvInput.normalized * speed;

        }
        if(killCount == killsNeeded && !winRound)
        {
            WinRound();
            winRound = true;
        }
    }
    
    public void Hurt()
    {
        playerHealth--;

        if(playerHealth <= 0)
        {
            Die();
            LifeScoreManager.instance.updateDeaths();
        }
    }
    public void Die()
    {
        restartCanvas.enabled = true;
        Destroy(gameObject);
        
    }

    public void WinRound()
    {
        int num = 0;
        num++;
        Debug.Log("player win round :" +num);


        LifeScoreManager.instance.updateLevel();
        winScreenCanvas.enabled = true;
        isMovementEnabled = false;
    }

    public void KillCount()
    {
        
        killCount++;
        Debug.Log("Kill count: " + killCount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Zombie")
        {
            Debug.Log("Collided with zombie");
            Hurt();
        }
    }

}
