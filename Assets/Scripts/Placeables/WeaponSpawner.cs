using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] public GameObject weaponPrefab;
    private GameObject weaponDisplay;
    public string WeaponSpawner1313;

    private void Start()
    {
        weaponDisplay = Instantiate(weaponPrefab, transform.position + Vector3.up * 0.5f, transform.rotation, transform);
        weaponDisplay.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);

    }
}
