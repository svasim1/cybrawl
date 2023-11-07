using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCannon : MonoBehaviour
{

    [Header("Weapon")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public Sprite bulletSprite;

    [Header("Weapon Stats")]
    public float bulletSpeed = 1f;
    public float bulletDamage = 50f;
    public float fireRate = 0.5f;
    public float lifeTime = 10f;
    public int ammo = 2;
    [SerializeField] private string fireButton; 

    private void Start()
    {
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
        // Determine the direction of the bullet based on the player's facing direction
        Vector2 bulletDirection = transform.root.GetComponent<Player>().facingRight ? Vector2.right : Vector2.left;

        // Create a bullet
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Set the velocity of the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

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
