using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] public GameObject weaponPrefab;
    private GameObject weaponDisplay;

    private void Start()
    {
        weaponDisplay = Instantiate(weaponPrefab, transform.position + Vector3.up * 1f, transform.rotation, transform);
        weaponDisplay.transform.localScale = new Vector3(1f, 4f, 1f);

    }
}
