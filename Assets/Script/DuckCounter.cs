using UnityEngine;
using TMPro;

public class DuckCounter : MonoBehaviour
{
    public int duckCount = 0;
    public TextMeshProUGUI duckCounterText; // Ссылка на текстовый объект для отображения счетчика

    // Метод вызывается при старте игры
    private void Update()
    {
        // Обновляем текст счетчика
        UpdateDuckCounterText();
    }

    // Метод для увеличения счетчика на 1 очко
    public void IncrementDuckCount()
    {
        UpdateDuckCounterText();
    }

    // Метод для увеличения счетчика на заданное количество очков
    public void IncrementDuckCount(int points)
    {
        duckCount += points;
        UpdateDuckCounterText();
    }

    // Метод для обновления текста счетчика
    private void UpdateDuckCounterText()
    {
        // Обновляем текст счетчика
        duckCounterText.text = "Ducks Destroyed: " + duckCount.ToString();
    }
}