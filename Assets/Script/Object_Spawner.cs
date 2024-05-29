using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spawner : MonoBehaviour
{
    public GameObject[] spawnPoints; // Массив точек спавна
    public GameObject objectToSpawn; // Объект для спавна
    public float spawnInterval = 5f; // Интервал между спаунами

    private float timer = 0f; // Таймер для отслеживания интервала спауна

    void Start()
    {
        // Отключить спавнер при старте игры
        this.enabled = false;
    }

    void Update()
    {
        // Обновляем таймер
        timer += Time.deltaTime;

        // Если прошло достаточно времени для спауна нового объекта
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f; // Сбросим таймер
        }
    }

    void SpawnObject()
    {
        // Выбор случайной точки спавна
        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Спавн объекта в выбранной точке
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.transform.position, Quaternion.identity);

        // Поворачиваем новый объект на указанный угол по оси X
        spawnedObject.transform.rotation = Quaternion.Euler(-89.98f, 0f, 0f);

    }
}
