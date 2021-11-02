using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerNonEndless : Spawner
{
    LevelSelector Data;
    [SerializeField] int Currentlevel;
    private float spawnRate;
    [SerializeField] private int spawnAmount;
    [HideInInspector]public static int limit;
    [HideInInspector]public static int limitRequired;
    [SerializeField] public GameObject Victory;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = startSpawnRate;
        limitRequired = spawnAmount;
        // Refer the save data
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
            AddLevel();
            Victory.SetActive(true);
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

    public void AddLevel() {
        if (Data.levelReached < Currentlevel) {
            Data.status[Data.levelReached] = true;
            Data.levelReached = Currentlevel;
        }
       
    }

    public void UpdateData() {
        Data.SaveGame();
        //Data.RefreshLevel();
    }

    
}
