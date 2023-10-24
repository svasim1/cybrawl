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
        if (!hasWeapon && collision.CompareTag("WeaponSpawner"))
        {
            Debug.Log("Activated pickup");
            collision.gameObject.SetActive(false);

            GameObject newWeapon = Instantiate(collision.GetComponent<WeaponSpawner>().weaponPrefab);

            newWeapon.transform.SetParent(WeaponHolder.transform);
            newWeapon.transform.localPosition = Vector3.zero;
            newWeapon.transform.localScale = Vector3.one;

            hasWeapon = true;

            newWeapon.SetActive(true);
            StartCoroutine(EnableSpawnerAfterDelay(collision.gameObject, spawnCooldown));
        }
    }
    IEnumerator EnableSpawnerAfterDelay(GameObject spawner, float delay)
    {
        yield return new WaitForSeconds(delay);
        spawner.SetActive(true);
    }
}
