using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck_Green : Duck
{
    public GameObject explosion_dead1;
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        speed = 3f;
        base.Update();
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            duckCounter.IncrementDuckCount(1); // Увеличение счета на 5 очков для зеленой утки
            GameObject explosion = Instantiate(explosion_dead1, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
