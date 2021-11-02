using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProgressData
{
        
    public int LevelReached;
    public bool[] status;    

    public ProgressData(LevelSelector levelSelector)
    {
        status = new bool[levelSelector.status.Length];
        LevelReached = levelSelector.levelReached;

        for (int i = 0; i < levelSelector.status.Length; i++)
        {
            status[i] = levelSelector.status[i];
        }
    }
}
