using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonEndlessManager : CoreGameManager
{
    SpawnerNonEndless Statistic;
    // Start is called before the first frame update
    void Start()
    {
        Statistic = FindObjectOfType<SpawnerNonEndless>();
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
        else if (SpawnerNonEndless.limit == Statistic.limitRequired && TopDownShooter.health != 0) {
            Clear();
        }
    }

    public void Clear()
    {
        ResultPanel.SetActive(true);
        ResultText.text = "Your Score: \n" + score.ToString();
    }
}
