using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScripts : AllUIButtonScript
{
    LevelSelector Data;

    [System.Serializable]
    public class LevelStatus
    {
        public Button level;
        public Sprite Blank, CompletePic, IncompletePic;
    }

    public List<LevelStatus> Progress = new List<LevelStatus>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ExitGame();
    }

    void ExitGame() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("ExitGame");
            Application.Quit();
        }
   
    }

    public void refreshLevels() {
        for (int i = 0; i < Progress.Count; i++) {
            //Disable dulu semua level kecuali pertama
        }
        for (int i = 0; i <= Data.levelReached; i++) {
            if (i == Progress.Count) {
                break;
            }
            Progress[i].level.interactable = true;
        }
    }

    public void loadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
