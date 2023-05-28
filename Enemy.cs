using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    private GameObject player;
    private GameObject spawn;
    private Rigidbody2D rb;
    public float moveSpeed;
    private float initializationTime;

    void Start()
    {

        initializationTime = Time.timeSinceLevelLoad;
        spawn = GameObject.Find("Spawn");
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        Debug.Log("player found");
        Debug.Log(player);
    }

    // Update is called once per frame
    void Update()
    {
        float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;
        moveToPlayer(timeSinceInitialization);
    }

    public void takeDamage(int amount){
        health -= amount;

        if(health <= 0){
            Debug.Log("Enemy dead");
            Destroy(gameObject);
            spawn.GetComponent<Horde>().killEnemy();
        }
    }

    private void moveToPlayer(float aliveTime)
    {
        float currentSpeed = moveSpeed + (aliveTime / moveSpeed);
        // Get the player's position
        Vector2 playerPosition = player.transform.position;

        // Calculate the direction from the shooter to the player's position
        Vector2 direction = playerPosition - (Vector2)transform.position;
        direction.Normalize();

        // Calculate the velocity based on the direction and speed
        Vector2 velocity = direction * currentSpeed;

        // Apply the velocity to the Rigidbody2D
        rb.velocity = velocity;
    }
}
