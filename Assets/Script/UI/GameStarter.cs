using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // Ссылка на текстовый объект для отображения таймера
    public float countdownTime = 5f; // Время отсчета до старта в секундах
    public TextMeshProUGUI timerText; // Ссылка на текстовый объект для отображения игрового таймера
    public float gameDuration = 60f; // Продолжительность игры в секундах
    public GameObject endGamePanel; // Панель с результатами
    public TextMeshProUGUI endGameText; // Текстовый объект для отображения результатов
    public TextMeshProUGUI highScoreText; // Текстовый объект для отображения высшего счета
    public Button restartButton; // Кнопка для перезапуска игры

    public ScoreData scoreData; // Ссылка на ScriptableObject ScoreData

    private float remainingGameTime;
    private bool isGameActive = false;
    private DuckCounter duckCounter;
    private Cannon_Shot cannonShot;
    private CannonControl cannonControl;

    void Start()
    {
        // Начать отсчет времени
        StartCoroutine(StartCountdown());
        duckCounter = FindObjectOfType<DuckCounter>();
        cannonShot = FindObjectOfType<Cannon_Shot>();
        cannonControl = FindObjectOfType<CannonControl>();

        // Скрыть панель с результатами
        endGamePanel.SetActive(false);

        // Обновить текст высшего счета
        UpdateHighScoreText();

        // Добавить слушателя к кнопке перезапуска
        restartButton.onClick.AddListener(RestartGame);
    }

    IEnumerator StartCountdown()
    {
        float currentTime = countdownTime;

        while (currentTime > 0)
        {
            // Обновляем текст на UI
            countdownText.text = currentTime.ToString("F0"); // Отображаем целое число

            // Ждем одну секунду
            yield return new WaitForSeconds(1f);

            // Уменьшаем текущее время
            currentTime--;
        }

        // Обновляем текст на UI на "Go!" или убираем текст
        countdownText.text = "Go!";

        // Ждем одну секунду, чтобы показать "Go!"
        yield return new WaitForSeconds(1f);

        // Убираем текст
        countdownText.gameObject.SetActive(false);

        // Начинаем игру
        StartGame();
    }

    void StartGame()
    {
        // Включить все необходимые объекты и механики для начала игры
        Object_Spawner[] objectSpawners = FindObjectsOfType<Object_Spawner>();
        foreach (var spawner in objectSpawners)
        {
            spawner.enabled = true;
        }

        L_Object_Spawner[] lObjectSpawners = FindObjectsOfType<L_Object_Spawner>();
        foreach (var spawner in lObjectSpawners)
        {
            spawner.enabled = true;
        }

        // Инициализировать оставшееся время игры и запустить таймер
        remainingGameTime = gameDuration;
        isGameActive = true;
        StartCoroutine(GameTimer());
    }

    IEnumerator GameTimer()
    {
        while (remainingGameTime > 0 && isGameActive)
        {
            // Обновляем текст таймера на UI
            timerText.text = "Time: " + remainingGameTime.ToString("F0"); // Отображаем целое число

            // Ждем одну секунду
            yield return new WaitForSeconds(1f);

            // Уменьшаем оставшееся время
            remainingGameTime--;
        }

        // Заканчиваем игру
        EndGame();
    }

    void EndGame()
    {
        isGameActive = false;

        // Отключаем спавнеры объектов
        Object_Spawner[] objectSpawners = FindObjectsOfType<Object_Spawner>();
        foreach (var spawner in objectSpawners)
        {
            spawner.enabled = false;
        }

        L_Object_Spawner[] lObjectSpawners = FindObjectsOfType<L_Object_Spawner>();
        foreach (var spawner in lObjectSpawners)
        {
            spawner.enabled = false;
        }

        // Отключаем возможность стрельбы и управления пушкой
        if (cannonShot != null) cannonShot.enabled = false;
        if (cannonControl != null) cannonControl.enabled = false;

        // Показать панель с результатами
        endGamePanel.SetActive(true);

        // Обновить текст с результатами
        endGameText.text = "The end of the game\nDucks Destroyed: " + duckCounter.duckCount;

        // Сохраняем текущий счет в объект ScoreData
        if (scoreData != null)
        {
            // Если текущий счет больше сохраненного наивысшего счета, обновляем его
            if (duckCounter.duckCount > scoreData.HighScore)
            {
                scoreData.HighScore = duckCounter.duckCount;
                SaveScoreData();
                UpdateHighScoreText(); // Обновить текст высшего счета
            }
        }
    }

    void RestartGame()
    {
        // Перезагрузить текущую сцену
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Метод для сохранения данных ScoreData
    void SaveScoreData()
    {
        if (scoreData != null)
        {
            // Сохраняем данные в PlayerPrefs
            PlayerPrefs.SetInt("HighScore", scoreData.HighScore);
            PlayerPrefs.Save();
        }
    }

    // Метод для обновления текста высшего счета
    void UpdateHighScoreText()
    {
        if (scoreData != null)
        {
            highScoreText.text = "High Score: " + scoreData.HighScore;
        }
    }

    // Метод для увеличения оставшегося времени игры
    public void AddTime(float additionalTime)
    {
        remainingGameTime += additionalTime;
        // Обновляем текст таймера на UI
        timerText.text = "Time: " + remainingGameTime.ToString("F0"); // Отображаем целое число
    }
}
