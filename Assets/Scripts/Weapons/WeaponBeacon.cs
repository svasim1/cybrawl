using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBeacon : MonoBehaviour
{
    public float throwForce = 1000;
    public GameObject doomRayPrefab;
    public int ammo = 1;

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
        if (Input.GetButtonDown(fireButton) && ammo > 0) // Check if ammo is more than 0
        {
            Throw();
        }
    }


    public void Throw()
    {
        if (ammo > 0) // Check if ammo is more than 0
        {
            var doomRay = Instantiate(doomRayPrefab, transform.position, transform.rotation);
            var rb = doomRay.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log("Throwing grenade");
                rb.AddForce(transform.forward * throwForce);
            }

            ammo--; // Decrement ammo

            if (ammo == 0) // If ammo is 0, call OutOfAmmo
            {
                OutOfAmmo();
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 spawnPosition = transform.position + (transform.forward * 5) + (transform.up * 2);
        var box = Instantiate(doomRayPrefab, spawnPosition, Quaternion.identity);

        Destroy(gameObject);
    }

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
}