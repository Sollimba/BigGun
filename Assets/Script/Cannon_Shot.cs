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
        canShoot = false; // ��������� ����������� ��������

        // ������� ��������� ������� �� �������
        GameObject projectile = Instantiate(core_abstract, cannon_1.position, cannon_1.rotation);
        projectile.tag = "Projectile"; // ��������� ���

        // �������� Rigidbody �������
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();

        // ������� ������� ���� � ����������� ������ �� ����� spawnPoint
        projectileRigidbody.AddForce(cannon_1.forward * shootForce);
        AudioManager.instance.Play("Shoot");

        // ���� �������� �����
        yield return new WaitForSeconds(shootCooldown);

        canShoot = true; // �������� ����������� �������� �����
    }
}
