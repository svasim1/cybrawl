using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollect : MonoBehaviour
{
    public GameObject WeaponHolder;
    public bool hasWeapon = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasWeapon && collision.CompareTag("WeaponSpawner"))
        {
            Debug.Log("Activated pickup");
            Destroy(collision.gameObject);

            GameObject newWeapon = Instantiate(collision.GetComponent<WeaponSpawner>().weaponPrefab);

            newWeapon.transform.SetParent(WeaponHolder.transform);
            newWeapon.transform.localPosition = Vector3.zero;
            newWeapon.transform.localScale = Vector3.one;

            hasWeapon = true;

            newWeapon.SetActive(true);
        }
    }
}
