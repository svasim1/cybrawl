using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPulser : MonoBehaviour
{

    [Header("Weapon")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public Sprite bulletSprite;

    [Header("Weapon Stats")]
    public float bulletSpeed = 16f;
    public float bulletDamage = 5f;
    public float lifeTime = 1f;
    public int ammo = 5;
    public int knockback = 1000;
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
        Debug.Log("Pulser shot");

        // Play the shoot sound
        ShootSound();

        // Determine the direction of the bullet based on the player's facing direction
        Vector2 bulletDirection = transform.root.GetComponent<Player>().facingRight ? Vector2.right : Vector2.left;

        // Create a bullet
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        // Set the velocity of the bullet
        bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

        // Apply bulletDamage to the bullet
        bullet.GetComponent<Bullet>().damage = bulletDamage;

        //Apply knockback to the bullet
        bullet.GetComponent<Rigidbody2D>().mass = knockback;

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
        Debug.Log("Out of ammo");
        Destroy(gameObject);

        // Set hasWeapon to false on the player
        GetComponentInParent<WeaponCollect>().hasWeapon = false;
        if (GetComponentInParent<WeaponCollect>().hasWeapon == false)
        {
            Debug.Log("Player has no weapon");
        }
    }
    void ShootSound()
    {
        // Get the AudioSource component and play the shoot sound
        GameObject.Find("AudioHandler").transform.Find("SFX").Find("Pulser").GetComponent<AudioSource>().Play();
        Debug.Log("Played shoot sound");
    }
}
