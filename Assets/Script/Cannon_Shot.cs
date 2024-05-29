using System.Collections;
using UnityEngine;

public class Cannon_Shot : MonoBehaviour
{
    public GameObject core_abstract;
    public Transform cannon_1;

    public float shootForce = 1000f;
    public float shootCooldown = 3f;
    private bool canShoot = true;

    void Update()
    {
        if (canShoot && Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(ShootWithCooldown());
        }
    }

    IEnumerator ShootWithCooldown()
    {
        canShoot = false; // Выключаем возможность стрельбы

        // Создаем экземпляр снаряда из префаба
        GameObject projectile = Instantiate(core_abstract, cannon_1.position, cannon_1.rotation);
        projectile.tag = "Projectile"; // Добавляем тег

        // Получаем Rigidbody снаряда
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        // Придаем снаряду силу в направлении вперед от точки spawnPoint
        projectileRigidbody.AddForce(cannon_1.forward * shootForce);
        AudioManager.instance.Play("Shoot");

        // Ждем заданное время
        yield return new WaitForSeconds(shootCooldown);

        canShoot = true; // Включаем возможность стрельбы снова
    }
}
