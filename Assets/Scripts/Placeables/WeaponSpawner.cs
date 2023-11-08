using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] public GameObject weaponPrefab;
    private GameObject weaponDisplay;

    private void Start()
    {
        // Spawn weapon display
        weaponDisplay = Instantiate(weaponPrefab, transform.position + Vector3.up * 0.5f, transform.rotation, transform);
        
        // Set scale of weapon display
        weaponDisplay.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

    }
}
