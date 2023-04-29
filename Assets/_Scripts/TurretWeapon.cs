using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWeapon : MonoBehaviour
{
    [Header("Weapon Settings")] 
    public float fireRate = 0.1f;
    private float _nextFire;
    public int ammo = 50;

    public Projectile projectile;
    public Transform gunBarrel;

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
    }

    void FireWeapon()
    {
        if (Time.time > _nextFire)
        {
            print("BANG!");
            var bullet = Instantiate(projectile, gunBarrel.position, gunBarrel.rotation);
            _nextFire = Time.time + fireRate;
            bullet = null;
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
