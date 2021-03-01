using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;

    public float xPositionLimit;
    float spawnRate = 0.4f;

    int flagScore = 0;



    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        int score = GameManager.instance.ReturnScore();

        if(score - flagScore == 50)
        {
            spawnRate -= 0.05f;
            StopSpawning();

            StartSpawning();

            print(spawnRate);

            flagScore = score;
        }
    }

    void SpawnEnemy()
    {
        float position = Random.Range(-xPositionLimit, xPositionLimit);

        Vector2 spawnPos = new Vector2(position, transform.position.y);

        Instantiate(enemy, spawnPos, Quaternion.identity);
    }

    public void StartSpawning()
    {

        InvokeRepeating("SpawnEnemy", 0.5f, spawnRate);
    }

    public void StopSpawning()
    {
        CancelInvoke("SpawnEnemy");
    }

}
