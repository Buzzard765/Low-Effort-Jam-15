using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScripts : AllUIButtonScript
{
    public LevelSelector Data;

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
        refreshLevels();
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
            Progress[i].level.interactable = false;
        }
        for (int i = 0; i <= Data.levelReached; i++) {
            if (i == Progress.Count) {
                break;
            }
            Progress[i].level.interactable = true;

            if (Data.status[i] == true) {
                //insert anything related to the button sprite
            }else if (Data.status[i] == false)
            {
                //insert anything related to the button sprite
            }
        }
    }

    
}
