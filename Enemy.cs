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

    void Start()
    {
        spawn = GameObject.Find("Spawn");
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveToPlayer();
    }

    public void takeDamage(int amount){
        health -= amount;

        if(health <= 0){
            spawn.GetComponent<Horde>().killEnemy();
            Destroy(gameObject);
        }
    }

    private void moveToPlayer()
    {
    // Get the player's position
    Vector2 playerPosition = player.transform.position;

    // Calculate the direction from the shooter to the player's position
    Vector2 direction = playerPosition - (Vector2)transform.position;
    direction.Normalize();

    // Calculate the velocity based on the direction and speed
    Vector2 velocity = direction * moveSpeed;

    // Apply the velocity to the Rigidbody2D
    rb.velocity = velocity;
    }
}
