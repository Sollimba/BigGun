using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    protected float speed = 5f; // Скорость движения объекта
    protected float distanceToDestroy = 50f; // Расстояние, после которого объект будет уничтожен
    protected float distanceTraveled = 0f; // Пройденное расстояние
    protected DuckCounter duckCounter;

    protected virtual void Start()
    {
        duckCounter = FindObjectOfType<DuckCounter>();
    }

    protected virtual void Update()
    {
        // Передвижение объекта вниз
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Увеличиваем пройденное расстояние
        distanceTraveled += speed * Time.deltaTime;

        // Проверяем, превысило ли пройденное расстояние заданное значение
        if (distanceTraveled >= distanceToDestroy)
        {
            // Уничтожаем объект
            Destroy(gameObject);
        }
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}