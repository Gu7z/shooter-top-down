using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float delay;
    public int damage;

    void Start()
    {
        Destroy(gameObject, delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with a specific tag or GameObject
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Enemy enemyScript = collision.gameObject.GetComponent<Enemy>();
            enemyScript.takeDamage(damage);
        }
    }
}
