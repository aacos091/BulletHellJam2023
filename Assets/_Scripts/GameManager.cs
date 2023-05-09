using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int totalEnemiesInCurrentLevel;
    public float levelTimer = 60.0f;
    public bool allEnemiesDead = false;
    public bool playerDead = false;
    public TMP_Text timerText;
    public GameObject WinLevelText;
    
    // Start is called before the first frame update
    void Start()
    {
        totalEnemiesInCurrentLevel = GameObject.FindGameObjectsWithTag("Enemy").Length + GameObject.FindGameObjectsWithTag("Turret").Length;
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    
        if (!allEnemiesDead && !playerDead)
        {
            if (levelTimer > 0.0f)
            {
                levelTimer -= Time.deltaTime;

                timerText.text = Mathf.FloorToInt(levelTimer).ToString();
            }
        }
        
        
        if (levelTimer <= 0.0f)
        {
            WinCurrentLevel();
        }
    }

    public void DecreaseCount()
    {
        totalEnemiesInCurrentLevel--;

        if (totalEnemiesInCurrentLevel == 0)
        {
            allEnemiesDead = true;   
            WinCurrentLevel();
        }
    }

    void WinCurrentLevel()
    {
        Debug.Log("You've won the current level!");
        
        WinLevelText.SetActive(true);
    }
}
