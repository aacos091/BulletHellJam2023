using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHealth;
    public GameObject wheelTrailLeft;
    public GameObject wheelTrailRight;
    public AudioSource audio;

    public void DecreaseHealth()
    {
        enemyHealth--;
        if (enemyHealth <= 0)
        {
            Debug.Log("This enemy is dead");
            GameObject.Find("GameManager").GetComponent<GameManager>().DecreaseCount();
            audio.Play();
            audio.transform.SetParent(null);
            Destroy(audio.GameObject(), 1f);
            if (this.gameObject.CompareTag("Enemy"))
            {
                wheelTrailRight.transform.SetParent(null);
                wheelTrailLeft.transform.SetParent(null);
            }
            Destroy(gameObject);
        }
    }
}
