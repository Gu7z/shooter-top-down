using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;   // The prefab of the bullet to be shot
    public float shootForce;    // The force at which the bullet is shot
    public KeyCode shootKey = KeyCode.Mouse0; // The key to shoot the bullet

    private void Update()
    {
        if (Input.GetKeyDown(shootKey))
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        // Get the mouse position in world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the shooter to the mouse position
        Vector2 direction = mousePosition - (Vector2)transform.position;
        direction.Normalize();

        // Instantiate the bullet prefab
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Apply force to the bullet in the specified direction
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.AddForce(direction * shootForce, ForceMode2D.Impulse);
    }
}
