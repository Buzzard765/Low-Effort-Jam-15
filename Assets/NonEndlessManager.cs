using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonEndlessManager : CoreGameManager
{
    SpawnerNonEndless Statistic;
    [SerializeField] public GameObject Victory;
    // Start is called before the first frame update
    void Start()
    {
        Statistic = FindObjectOfType<SpawnerNonEndless>();
        Victory = GameObject.Find("Victory");
        Victory.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SpawnerNonEndless.limit);
        ScoreText.text = "Score: " + score.ToString();
        HealthText.text = "Health: " + TopDownShooter.health.ToString();
        if (TopDownShooter.health == 0)
        {
            GameOver();
            Debug.Log("Game Over");
        }
        else if (SpawnerNonEndless.limit == SpawnerNonEndless.limitRequired && TopDownShooter.health != 0) {
            Clear();
        }
    }

    public void Clear()
    {
        Victory.SetActive(true);
        ResultText.text = "Your Score: \n" + score.ToString();
    }
}
