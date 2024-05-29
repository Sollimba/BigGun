using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Object_Spawner : MonoBehaviour
{
    public GameObject[] l_spawnPoints; // Массив точек спавна для первого объекта
    public GameObject l_objectToSpawn; // Первый объект для спавна
    public float l_spawnInterval = 10f; // Интервал между спаунами для первого объекта

    public GameObject[] l_spawnPoints2; // Массив точек спавна для второго объекта
    public GameObject l_objectToSpawn2; // Второй объект для спавна
    public float l_spawnInterval2 = 10f; // Интервал между спаунами для второго объекта

    private float timer = 0f; // Таймер для отслеживания интервала спауна первого объекта
    private float timer2 = 0f; // Таймер для отслеживания интервала спауна второго объекта

    void Start()
    {
        // Отключить спавнер при старте игры
        this.enabled = false;
    }

    void Update()
    {
        // Обновляем таймеры
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        // Если прошло достаточно времени для спауна первого объекта
        if (timer >= l_spawnInterval)
        {
            SpawnObject(l_objectToSpawn, l_spawnPoints);
            timer = 0f; // Сбросим таймер
        }

        // Если прошло достаточно времени для спауна второго объекта
        if (timer2 >= l_spawnInterval2)
        {
            SpawnObject(l_objectToSpawn2, l_spawnPoints2);
            timer2 = 0f; // Сбросим таймер
        }
    }

    void SpawnObject(GameObject objectToSpawn, GameObject[] spawnPoints)
    {
        // Выбор случайной точки спавна
        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Спавн объекта в выбранной точке
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.transform.position, Quaternion.identity);

        // Поворачиваем новый объект на указанный угол по оси X
        spawnedObject.transform.rotation = Quaternion.Euler(-89.98f, 180f, 0f);
    }
}
