using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSidearm : MonoBehaviour
{

    [Header("Weapon")]
    public Transform raySpawnPoint;

    [Header("Weapon Stats")]
    public float rayDamage = 15f;
    public float rayDistance = 10f;

    private TargetableObject player;
    public int ammo = 8;
    [SerializeField] private string fireButton;
    private LineRenderer lineRenderer;

    private void Start()
    {
        // Gets the fireButton of the player
        Player player = GetComponentInParent<Player>();
        if (player != null)
        {
            fireButton = player.fireButton;
        }
        
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.1f;
        lineRenderer.positionCount = 2;

        lineRenderer.startColor = new Color(1f, 0f, 0f, 1f); // Red color with 50% transparency
        lineRenderer.endColor = new Color(1f, 0f, 0f, 0.5f); // Red color with 50% transparency
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

        lineRenderer.SetPosition(0, raySpawnPoint.position);
        lineRenderer.SetPosition(1, hit ? hit.point : (Vector2)raySpawnPoint.position + rayDirection * rayDistance);
        Invoke("ClearLine", 0.1f);

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
        }

        // Destroy the weapon when out of ammo
        if (ammo == 0)
        {
            Invoke("OutOfAmmo", 0.1f);
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
        GameObject.Find("AudioHandler").transform.Find("SFX").Find("Sidearm").GetComponent<AudioSource>().Play();
        Debug.Log("Played shoot sound");
    }

    void ClearLine()
    {
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, Vector3.zero);
    }
}
