using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSidearm : MonoBehaviour
{

    [Header("Weapon")]
    public Transform raySpawnPoint;

    [Header("Weapon Stats")]
    public float rayDamage = 15f;
    public float rayDistance = 10f;
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
        // Create a LayerMask that includes all layers except PassThrough
        int layerMask = ~(1 << LayerMask.NameToLayer("PassThrough"));

        // Determine the direction of the ray based on the player's facing direction
        Vector2 rayDirection = transform.root.GetComponent<Player>().facingRight ? Vector2.right : Vector2.left;

        // Create a ray
        RaycastHit2D hit = Physics2D.Raycast(raySpawnPoint.position, rayDirection, rayDistance, layerMask);

        if (hit == GameObject.FindGameObjectWithTag("Player"))
        {
            // Deal damage to the player
            hit.transform.GetComponent<TargetableObject>().TakeDamage(rayDamage);
            Debug.Log(hit.transform.name + " was hit by the ray");
        }

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
