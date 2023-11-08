using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollect : MonoBehaviour
{
    public GameObject WeaponHolder;
    public bool hasWeapon = false;
    public float spawnCooldown = 20f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if player is colliding with object tagged WeaponSpawner
        if (!hasWeapon && collision.CompareTag("WeaponSpawner"))
        {
            Debug.Log("OnTriggerEnter2D called with " + collision.gameObject.name);

            // Hide the weapon spawner
            collision.gameObject.SetActive(false);

            // Set the weapon to WeaponHolder
            GameObject newWeapon = Instantiate(collision.GetComponent<WeaponSpawner>().weaponPrefab);
            newWeapon.transform.SetParent(WeaponHolder.transform);
            newWeapon.transform.localPosition = Vector3.zero;
            newWeapon.transform.localScale = Vector3.one;
            newWeapon.SetActive(true);

            // Set hasWeapon to true
            hasWeapon = true;

            // Spawn weapon spawner after spawnCooldown
            StartCoroutine(EnableSpawnerAfterDelay(collision.gameObject, spawnCooldown));
        }
    }

    // Enable spawner after delay
    IEnumerator EnableSpawnerAfterDelay(GameObject spawner, float delay)
    {
        yield return new WaitForSeconds(delay);
        spawner.SetActive(true);
    }
}
