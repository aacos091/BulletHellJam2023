using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurretWeapon : MonoBehaviour
{
    [Header("Weapon Settings")] 
    public float fireRate = 0.1f;
    private float _nextFire;
    public int ammo = 50;

    public PlayerProjectile projectile;
    public Transform gunBarrel;
    public TMP_Text ammoNum;
    public AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PointToMouse();

        if (Input.GetMouseButton(0))
        {
            FireWeapon();
        }

        ammoNum.text = ammo.ToString();
    }

    void FireWeapon()
    {
        if (Time.time > _nextFire && ammo > 0)
        {
            //print("BANG!");
            var bullet = Instantiate(projectile, gunBarrel.position, gunBarrel.rotation);
            audio.Play();
            _nextFire = Time.time + fireRate;
            ammo--;
            bullet = null;
        }
        else if (ammo <= 0)
        {
            Debug.Log("You're out of ammo!");
        }
    }

    void PointToMouse()
    {
        float offset = 90f;
        
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);

        // Get the angle between the points
        float angle = AngleBetweenTwoPoints(transform.position, mouseWorldPosition);
        
        // Finish
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle + offset));
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
