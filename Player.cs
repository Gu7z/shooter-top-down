using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
  public float speed;

  private Rigidbody2D rb;

  private void Start() {
    rb = GetComponent<Rigidbody2D>();
    rb.freezeRotation = true;
  }

  private void Update() {
    float moveVertical = Input.GetKey(KeyCode.W) ? 1f : (Input.GetKey(KeyCode.S) ? -1f : 0f);
    float moveHorizontal = Input.GetKey(KeyCode.A) ? -1f : (Input.GetKey(KeyCode.D) ? 1f : 0f);

    Vector2 movement = new Vector2(moveHorizontal, moveVertical);
    rb.velocity = movement * speed;
  }
}
