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
    SpriteRenderer sprite;

    void Start()
    {

        initializationTime = Time.timeSinceLevelLoad;
        spawn = GameObject.Find("Spawn");
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
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
        float currentSpeed = moveSpeed + (aliveTime);
        // Get the player's position
        Vector2 playerPosition = player.transform.position;

        // Calculate the direction from the shooter to the player's position
        Vector2 direction = playerPosition - (Vector2)transform.position;
        direction.Normalize();

        // Calculate the velocity based on the direction and speed
        Vector2 velocity = direction * currentSpeed;

        // Apply the velocity to the Rigidbody2D
        rb.velocity = velocity;

        float enemyRedColor = map01(currentSpeed, moveSpeed, moveSpeed*5);

        Debug.Log("----");
        Debug.Log(currentSpeed);
        Debug.Log(enemyRedColor);
        Debug.Log("----");

        sprite.color = new Color(enemyRedColor*10, 0, 0, 1);
    }
    public static float map01(float value, float min, float max)
    {
        return (value - min) * 1f / (max - min);
    }
}
