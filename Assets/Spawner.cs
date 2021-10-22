using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] SpawnSpot;
    private float spawnRate;
    public float startSpawnRate;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = startSpawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (TopDownShooter.health >= 0) {
            spawnEnemy();
        }
        
    }

    public virtual void spawnEnemy() {
        if (spawnRate <= 0)
        {
            int randPos = Random.Range(0, SpawnSpot.Length);
            int randEnemy = Random.Range(0, enemy.Length);
            Instantiate(enemy[randEnemy], SpawnSpot[randPos].position, SpawnSpot[randPos].rotation);
            spawnRate = Random.Range(startSpawnRate - 1, startSpawnRate + 2);
        }
        else {
            spawnRate -= Time.deltaTime;
        }
    }
}
