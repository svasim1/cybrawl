using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPistol : MonoBehaviour
{

    [Header("Weapon")]
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public Sprite bulletSprite;

    [Header("Weapon Stats")]
    public float bulletSpeed = 10f;

    private float originalBulletSpeed;
    public float bulletDamage = 10f;
    public float fireRate = 0.5f;

    public float lifeTime = 1f;
    public int ammo = 10;
    [SerializeField] private string fireButton; 

    private void Start()
    {
        originalBulletSpeed = bulletSpeed;

        Player player = GetComponentInParent<Player>();
        if (player != null)
        {
            fireButton = player.fireButton;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown(fireButton))
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            if (!transform.root.GetComponent<Player>().facingRight)
            {
                bulletSpeed = -originalBulletSpeed;
                bullet.transform.localScale = new Vector3(-bullet.transform.localScale.x, bullet.transform.localScale.y, bullet.transform.localScale.z);
            }
            else
            {
                bulletSpeed = originalBulletSpeed;
            }

            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * bulletSpeed;
            bullet.GetComponent<Bullet>().damage = bulletDamage;
            bullet.GetComponent<SpriteRenderer>().sprite = bulletSprite;
            Destroy(bullet, lifeTime);
            ammo--;
            if (ammo == 0)
            {
                OutOfAmmo();
            }
        }
    }

    void OutOfAmmo()
    {
        Destroy(gameObject);
        GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponCollect>().hasWeapon = false;
    }
}
