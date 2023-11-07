using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPistol : MonoBehaviour
{

    [Header("Weapon")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public Sprite bulletSprite;

    [Header("Weapon Stats")]
    public float bulletSpeed = 10f;

    private float originalBulletSpeed;
    public float bulletDamage = 25f;
    public float fireRate = 0.5f;

    public float lifeTime = 1f;
    public int ammo = 10;
    [SerializeField] private string fireButton; 

    private void Start()
    {
        originalBulletSpeed = bulletSpeed;

        // Gets the fireButton of the player
        Player player = GetComponentInParent<Player>();
        if (player != null)
        {
            fireButton = player.fireButton;
        }
    }

    void Update()
    {   
        // Shoot if fireBUtton is pressed
        if (Input.GetButtonDown(fireButton))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create a bullet
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Set the direction of bulletSpeed depending on which way the player is facing
        if (!transform.root.GetComponent<Player>().facingRight)
        {
            bulletSpeed = -originalBulletSpeed;
            bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
        }
        else
        {
            bulletSpeed = originalBulletSpeed;
        }

        // Apply bulletSpeed to the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;

        // Apply bulletDamage to the bullet
        bullet.GetComponent<Bullet>().damage = bulletDamage;

        // Apply bulletSprite to the bullet
        bullet.GetComponent<SpriteRenderer>().sprite = bulletSprite;

        // Ignore collisions between the bullet and the objects with the layer PassThrough
        bullet.layer = LayerMask.NameToLayer("PassThrough");

        // Destroy the bullet after lifeTime
        Destroy(bullet, lifeTime);

        // Decrease ammo by one
        ammo--;

        // Destroy the weapon when out of ammo
        if (ammo == 0)
        {
            OutOfAmmo();
        }
    }

    // Destroy the weapon when out of ammo
    void OutOfAmmo()
    {
        Destroy(gameObject);

        // Set hasWeapon to false on the player
        GetComponentInParent<WeaponCollect>().hasWeapon = false;
    }
}
