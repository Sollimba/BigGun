using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_Object_Spawner : MonoBehaviour
{
    public GameObject[] l_spawnPoints; // ������ ����� ������ ��� ������� �������
    public GameObject l_objectToSpawn; // ������ ������ ��� ������
    public float l_spawnInterval = 10f; // �������� ����� �������� ��� ������� �������

    public GameObject[] l_spawnPoints2; // ������ ����� ������ ��� ������� �������
    public GameObject l_objectToSpawn2; // ������ ������ ��� ������
    public float l_spawnInterval2 = 10f; // �������� ����� �������� ��� ������� �������

    private float timer = 0f; // ������ ��� ������������ ��������� ������ ������� �������
    private float timer2 = 0f; // ������ ��� ������������ ��������� ������ ������� �������

    void Start()
    {
        // ��������� ������� ��� ������ ����
        this.enabled = false;
    }

    void Update()
    {
        // ��������� �������
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;

        // ���� ������ ���������� ������� ��� ������ ������� �������
        if (timer >= l_spawnInterval)
        {
            SpawnObject(l_objectToSpawn, l_spawnPoints);
            timer = 0f; // ������� ������
        }

        // ���� ������ ���������� ������� ��� ������ ������� �������
        if (timer2 >= l_spawnInterval2)
        {
            SpawnObject(l_objectToSpawn2, l_spawnPoints2);
            timer2 = 0f; // ������� ������
        }
    }

    void SpawnObject(GameObject objectToSpawn, GameObject[] spawnPoints)
    {
        // ����� ��������� ����� ������
        GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // ����� ������� � ��������� �����
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.transform.position, Quaternion.identity);

        // ������������ ����� ������ �� ��������� ���� �� ��� X
        spawnedObject.transform.rotation = Quaternion.Euler(-89.98f, 180f, 0f);
    }
}
