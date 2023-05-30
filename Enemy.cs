using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
  [SerializeField] private Camera cam;
  [SerializeField] float health, maxHealth = 50f;
  private GameObject player;
  private GameObject spawn;
  private Rigidbody2D rb;
  private float currentSpeed;
  public float moveSpeed;
  private float initializationTime;
  SpriteRenderer sprite;
  [SerializeField] FloatingBar healthBar;

  void Awake() {
    cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    healthBar = GetComponentInChildren<FloatingBar>();
    rb = GetComponent<Rigidbody2D>();
    spawn = GameObject.Find("Spawn");
    player = GameObject.Find("Player");
    sprite = GetComponent<SpriteRenderer>();
  }

  void Start() {
    initializationTime = Time.timeSinceLevelLoad;
  }

  // Update is called once per frame
  void Update() {
    float timeSinceInitialization = Time.timeSinceLevelLoad - initializationTime;
    updateSpeed(timeSinceInitialization);
    moveToPlayer();
    transform.rotation = cam.transform.rotation;
  }

  public void takeDamage(int amount) {
    health -= amount;
    healthBar.UpdateBar(health, maxHealth);
    if (health <= 0) {
      Debug.Log("Enemy dead");
      Destroy(gameObject);
      spawn.GetComponent<Horde>().killEnemy();
    }
  }

  private void updateSpeed(float aliveTime) {
    currentSpeed = Mathf.Max(moveSpeed + (aliveTime), 18);
    float enemyRedColor = map01(currentSpeed, 0, moveSpeed * 2);

    sprite.color = new Color(enemyRedColor * 10, 0, 0, 1);
  }

  private void moveToPlayer() {
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
  static float map01(float value, float min, float max) {
    return (value - min) * 1f / (max - min);
  }
}
