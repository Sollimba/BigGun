using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Spawner : MonoBehaviour
{
    public GameObject[] spawnPoints; // ������ ����� ������
    public GameObject objectToSpawn; // ������ ��� ������
    public float spawnInterval = 5f; // �������� ����� ��������

    private float timer = 0f; // ������ ��� ������������ ��������� ������

    void Start()
    {
        // ��������� ������� ��� ������ ����
        this.enabled = false;
    }

    void Update()
    {
        // ��������� ������
        timer += Time.deltaTime;

        // ���� ������ ���������� ������� ��� ������ ������ �������
        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f; // ������� ������
        }
    }

    void SpawnObject()
    {
        // ����� ��������� ����� ������
        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // ����� ������� � ��������� �����
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.transform.position, Quaternion.identity);

        // ������������ ����� ������ �� ��������� ���� �� ��� X
        spawnedObject.transform.rotation = Quaternion.Euler(-89.98f, 0f, 0f);

    }
}
