using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;
    public GameObject wheelTrailLeft;
    public GameObject wheelTrailRight;

    public void DecreaseHealth()
    {
        enemyHealth--;
        if (enemyHealth <= 0)
        {
            Debug.Log("This enemy is dead");
            GameObject.Find("GameManager").GetComponent<GameManager>().DecreaseCount();
            if (this.gameObject.CompareTag("Enemy"))
            {
                wheelTrailRight.transform.SetParent(null);
                wheelTrailLeft.transform.SetParent(null);
            }
            Destroy(gameObject);
        }
    }
}
