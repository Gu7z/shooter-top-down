using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horde : MonoBehaviour
{
    public GameObject enemyPrefab; 
    public float interval;
    public float spawnRadius;    // The radius within which objects will be spawned
    public int spawnLimit;
    private int enemiesAlive;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RepeatFunction", 0f, interval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RepeatFunction()
    {
        if(enemiesAlive >= spawnLimit){
            return;
        }

        Vector2 randomPosition = new Vector2(
            Random.Range(transform.position.x - spawnRadius / 2f, transform.position.x + spawnRadius / 2f),
            Random.Range(transform.position.y - spawnRadius / 2f, transform.position.y + spawnRadius / 2f)
        );
        GameObject newEnemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        enemiesAlive++;
    }

    public void killEnemy(){
        enemiesAlive--;
    }
}
