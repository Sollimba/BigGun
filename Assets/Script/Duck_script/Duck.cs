using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    protected float speed = 5f; // �������� �������� �������
    protected float distanceToDestroy = 50f; // ����������, ����� �������� ������ ����� ���������
    protected float distanceTraveled = 0f; // ���������� ����������
    protected DuckCounter duckCounter;

    protected virtual void Start()
    {
        duckCounter = FindObjectOfType<DuckCounter>();
    }

    protected virtual void Update()
    {
        // ������������ ������� ����
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // ����������� ���������� ����������
        distanceTraveled += speed * Time.deltaTime;

        // ���������, ��������� �� ���������� ���������� �������� ��������
        if (distanceTraveled >= distanceToDestroy)
        {
            // ���������� ������
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