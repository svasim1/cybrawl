using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollect : MonoBehaviour
{
    public GameObject WeaponHolder;
    public bool hasWeapon = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WeaponSpawner") && !hasWeapon)
        {
            Debug.Log("Activated pickup");
            Destroy(collision.gameObject);

            GameObject newWeapon = Instantiate(collision.GetComponent<WeaponSpawner>().weaponPrefab);
            newWeapon.transform.position = WeaponHolder.transform.position;
            newWeapon.transform.rotation = WeaponHolder.transform.rotation;
            newWeapon.transform.parent = WeaponHolder.transform;
            hasWeapon = true;

            newWeapon.SetActive(true);
        }
    }
}
