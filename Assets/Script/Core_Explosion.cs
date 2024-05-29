using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Core : MonoBehaviour
{
    public GameObject explosion_abstr; // Префаб взрыва

    private void OnCollisionEnter(Collision collision)
    {
        // Создаём взрыв
        GameObject explosion = Instantiate(explosion_abstr, transform.position, Quaternion.identity);
        // Уничтожаем объект, на котором находится скрипт (ядро)
        Destroy(gameObject);

        // Находим объект DuckCounter в сцене
        DuckCounter duckCounter = GameObject.FindObjectOfType<DuckCounter>();

        // Проверяем, найден ли DuckCounter
        if (duckCounter != null)
        {
            // Проверяем, столкнулось ли ядро с объектом, имеющим тег "Duck"
            if (collision.gameObject.CompareTag("Duck"))
            {
                AudioManager.instance.Play("Duck_dead");
                duckCounter.IncrementDuckCount();
                Destroy(collision.gameObject);
            }
        }
        else
        {
            Debug.LogError("DuckCounter not found in the scene!");
        }
    }
}

