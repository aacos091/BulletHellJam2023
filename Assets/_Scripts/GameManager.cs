using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalEnemiesInCurrentLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        totalEnemiesInCurrentLevel = GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("Turret").Length;
        
    }

    public void DecreaseCount()
    {
        totalEnemiesInCurrentLevel--;

        if (totalEnemiesInCurrentLevel == 0)
        {
            WinCurrentLevel();
        }
    }

    void WinCurrentLevel()
    {
        Debug.Log("You've won the current level!");
    }
}
