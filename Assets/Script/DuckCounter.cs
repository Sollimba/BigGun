using UnityEngine;
using TMPro;

public class DuckCounter : MonoBehaviour
{
    public int duckCount = 0;
    public TextMeshProUGUI duckCounterText; // ������ �� ��������� ������ ��� ����������� ��������

    // ����� ���������� ��� ������ ����
    private void Update()
    {
        // ��������� ����� ��������
        UpdateDuckCounterText();
    }

    // ����� ��� ���������� �������� �� 1 ����
    public void IncrementDuckCount()
    {
        UpdateDuckCounterText();
    }

    // ����� ��� ���������� �������� �� �������� ���������� �����
    public void IncrementDuckCount(int points)
    {
        duckCount += points;
        UpdateDuckCounterText();
    }

    // ����� ��� ���������� ������ ��������
    private void UpdateDuckCounterText()
    {
        // ��������� ����� ��������
        duckCounterText.text = "Ducks Destroyed: " + duckCount.ToString();
    }
}