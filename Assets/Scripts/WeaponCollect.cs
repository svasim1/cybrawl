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

            newWeapon.transform.SetParent(WeaponHolder.transform);
            newWeapon.transform.localPosition = Vector3.zero;

            if (!transform.root.GetComponent<Player>().facingRight)
            {
                newWeapon.transform.localScale = new Vector3(-newWeapon.transform.localScale.x, newWeapon.transform.localScale.y, newWeapon.transform.localScale.z);
            }

            hasWeapon = true;

            newWeapon.SetActive(true);
        }
    }
}
