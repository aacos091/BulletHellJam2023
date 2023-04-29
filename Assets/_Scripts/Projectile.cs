using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _projectileRb;
    public float speed = 10f;
    public float timer = 5f;

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
}
