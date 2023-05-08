using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _projectileRb;
    public float speed = 10f;
    public float timer = 5f;
    public float damage = 5f;
    public AudioSource hitSound;
    public AudioClip hit;
    public SpriteRenderer sprite;
    public Collider2D collider;

    private void Awake()
    {
        _projectileRb = GetComponent<Rigidbody2D>();
        hitSound = GetComponentInChildren<AudioSource>();
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
        if (!col.CompareTag("Player")) return;
        sprite.enabled = false;
        collider.enabled = false;
        hitSound.PlayOneShot(hit);
        col.gameObject.GetComponent<PlayerHealth>().DamagePlayer(damage);
        Debug.Log("You just got hit!");
        Destroy(gameObject, 1.0f);
    }
}
