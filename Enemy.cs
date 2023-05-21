using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;

    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int amount){
        health -= amount;

        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
