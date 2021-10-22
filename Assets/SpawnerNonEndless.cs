using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerNonEndless : Spawner
{
    private float spawnRate;
    [SerializeField] private int spawnAmount;
    [HideInInspector]public static int limit;
    [HideInInspector]public int limitRequired;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = startSpawnRate;
        limitRequired = spawnAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (TopDownShooter.health >= 0)
        {
            spawnEnemy();
        }

        if (limit == limitRequired) {
            Debug.Log("Stage Cleared");
        }
    }

    public override void spawnEnemy()
    {
        //spawnEnemy();
        if (spawnRate <= 0 && spawnAmount != 0)
        {
            int randPos = Random.Range(0, SpawnSpot.Length);
            int randEnemy = Random.Range(0, enemy.Length);
            Instantiate(enemy[randEnemy], SpawnSpot[randPos].position, SpawnSpot[randPos].rotation);
            spawnAmount -= 1;
            spawnRate = Random.Range(startSpawnRate - 1, startSpawnRate + 2);
        }
        else
        {
            spawnRate -= Time.deltaTime;
            
        }
    }
}
