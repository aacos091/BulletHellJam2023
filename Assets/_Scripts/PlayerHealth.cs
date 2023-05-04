using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float health = 100.0f;
    [SerializeField] private GameObject GameOverText;

    public float ReturnCurrentHealth()
    {
        return health;
    }
    
    public void HealPlayer(float heal)
    {
        health += heal;
        if (health > 100.0f)
        {
            health = 100.0f;
        }
    }
    
    public void DamagePlayer(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        Debug.Log("You're DEAD!");
        GameOverText.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        Debug.Log("Health = " + health);
    }
}
