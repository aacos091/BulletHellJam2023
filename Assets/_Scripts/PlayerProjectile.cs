using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    private Rigidbody2D _projectileRb;
    public float speed = 10f;
    public float timer = 5f;
    public float damage = 5f;

    private void Awake()
    {
        _projectileRb = GetComponent<Rigidbody2D>();
        
    }

    private void Start()
    {
        Destroy(this.transform.gameObject, timer);
    }

    private void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    public void UpdateMoveSpeed(float moveSpeed)
    {
        this.speed = moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("You hit an enemy!");
            col.gameObject.GetComponent<EnemyHealth>().DecreaseHealth();
            Destroy(gameObject);
        }

        else if (col.CompareTag("Turret"))
        {
            Debug.Log("You hit a turret!");
            col.gameObject.GetComponent<EnemyHealth>().DecreaseHealth();
            Destroy(gameObject);
        }
    }
}
