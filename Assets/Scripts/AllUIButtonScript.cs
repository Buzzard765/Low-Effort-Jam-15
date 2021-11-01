using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllUIButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            pauseGame(PausePanel);
        }
    }

    void pauseGame(GameObject Panel) {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            Panel.SetActive(true);
        }
        else if (Time.timeScale == 0 && Panel.activeSelf == true) {
            Time.timeScale = 1;
            Panel.SetActive(false);
        }
    }

    void Restart() {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
