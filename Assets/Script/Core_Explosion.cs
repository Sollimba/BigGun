using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_Core : MonoBehaviour
{
    public GameObject explosion_abstr; // ������ ������

    private void OnCollisionEnter(Collision collision)
    {
        // ������ �����
        GameObject explosion = Instantiate(explosion_abstr, transform.position, Quaternion.identity);
        // ���������� ������, �� ������� ��������� ������ (����)
        Destroy(gameObject);

        // ������� ������ DuckCounter � �����
        DuckCounter duckCounter = GameObject.FindObjectOfType<DuckCounter>();

        // ���������, ������ �� DuckCounter
        if (duckCounter != null)
        {
            // ���������, ����������� �� ���� � ��������, ������� ��� "Duck"
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

