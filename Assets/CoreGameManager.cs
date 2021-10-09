using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreGameManager : MonoBehaviour
{
    public GameObject ResultPanel;
    public Text ScoreText, ResultText, HealthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreText.text = "Score: " + TopDownShooter.score.ToString();
        HealthText.text = "Health: " + TopDownShooter.health.ToString();
        if (TopDownShooter.health == 0) {
            ResultPanel.SetActive(true);
            ResultText.text = "Your Score: \n" + TopDownShooter.score.ToString();
        }
    }
}
