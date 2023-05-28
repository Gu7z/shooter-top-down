using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
  public float delay;
  public int damage;

  void Start() {
    Destroy(gameObject, delay);
  }

  private void OnCollisionEnter2D(Collision2D collision) {
    Destroy(gameObject);
    if (collision.gameObject.CompareTag("Enemy")) {
      Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
      enemyScript.takeDamage(damage);
    }
  }
}
