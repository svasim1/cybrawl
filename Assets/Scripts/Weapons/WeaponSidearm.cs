using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSidearm : MonoBehaviour
{

    [Header("Weapon")]
    public Transform raySpawnPoint;
    public GameObject bulletTrailPrefab;
    public GameObject impactEffect;

    [Header("Weapon Stats")]
    public float rayDamage = 15f;
    public float rayDistance = 10f;

    private TargetableObject player;
    public int ammo = 8;
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
        Debug.Log("Ray shot");

        // Decrease ammo by one
        ammo--;

        // Play the shoot sound
        ShootSound();

        // Create a LayerMask that includes all layers except PassThrough
        int layerMask = ~(1 << LayerMask.NameToLayer("PassThrough"));

        // Determine the direction of the ray based on the player's facing direction
        Vector2 rayDirection = transform.root.GetComponent<Player>().facingRight ? Vector2.right : Vector2.left;

        // Create a ray
        RaycastHit2D hit = Physics2D.Raycast(raySpawnPoint.position, rayDirection, rayDistance, layerMask);

        // Check if the ray hit something
        if (hit)
        {
            player = hit.transform.GetComponent<TargetableObject>();
            if (player != null)
            {
                // Deal damage to the player
                player.TakeDamage(rayDamage);
                Debug.Log(hit.transform.name + " was hit by the ray");
            }

            // Create the impact effect
            //Instantiate(impactEffect, hit.point, Quaternion.identity);
        }

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
        GameObject.Find("AudioHandler").transform.Find("SFX").Find("Shoot").GetComponent<AudioSource>().Play();
        Debug.Log("Played shoot sound");
    }
}
