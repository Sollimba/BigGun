using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck_Blue : Duck
{
    public GameObject explosion_dead;
    protected override void Update()
    {
        speed = 8f;
        base.Update();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            duckCounter.IncrementDuckCount(5); // Увеличение на 1 очко для синей утки
            GameObject explosion = Instantiate(explosion_dead, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
