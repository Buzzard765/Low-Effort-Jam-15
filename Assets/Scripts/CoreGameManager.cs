using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreGameManager : MonoBehaviour
{
    
    public GameObject ResultPanel;
    public Text ScoreText, ResultText, HealthText;
    public static int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + score.ToString();
        HealthText.text = "Health: " + TopDownShooter.health.ToString();
        if (TopDownShooter.health == 0) {
            GameOver();
            Debug.Log("Game Over");
        }        
    }

    public void GameOver() {
        ResultPanel.SetActive(true);
        ResultText.text = "Your Score: \n" + score.ToString();
    }

    
}
