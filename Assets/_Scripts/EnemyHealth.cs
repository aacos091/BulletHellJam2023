using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;

    public void DecreaseHealth()
    {
        enemyHealth--;
        if (enemyHealth <= 0)
        {
            Debug.Log("This enemy is dead");
            GameObject.Find("GameManager").GetComponent<GameManager>().DecreaseCount();
            Destroy(gameObject);
        }
    }
}
