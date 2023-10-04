using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPistol : MonoBehaviour
{

    [Header("Weapon")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;

    [Header("Weapon Stats")]
    public float bulletSpeed = 10f;
    public float bulletDamage = 10f;
    public float fireRate = 0.5f;

    public float reloadTime = 1f;

    public float lifeTime = 1f;
    public float ammo = 10f;
    public bool fire;
    [SerializeField] private string fireButton;

    void Update() {
        fire = Input.GetButtonDown(fireButton);
        if (fire) {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;
        }

    }
}
