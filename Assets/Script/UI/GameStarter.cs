using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // ������ �� ��������� ������ ��� ����������� �������
    public float countdownTime = 5f; // ����� ������� �� ������ � ��������
    public TextMeshProUGUI timerText; // ������ �� ��������� ������ ��� ����������� �������� �������
    public float gameDuration = 60f; // ����������������� ���� � ��������
    public GameObject endGamePanel; // ������ � ������������
    public TextMeshProUGUI endGameText; // ��������� ������ ��� ����������� �����������
    public TextMeshProUGUI highScoreText; // ��������� ������ ��� ����������� ������� �����
    public Button restartButton; // ������ ��� ����������� ����

    public ScoreData scoreData; // ������ �� ScriptableObject ScoreData

    private float remainingGameTime;
    private bool isGameActive = false;
    private DuckCounter duckCounter;
    private Cannon_Shot cannonShot;
    private CannonControl cannonControl;

    void Start()
    {
        // ������ ������ �������
        StartCoroutine(StartCountdown());
        duckCounter = FindObjectOfType<DuckCounter>();
        cannonShot = FindObjectOfType<Cannon_Shot>();
        cannonControl = FindObjectOfType<CannonControl>();

        // ������ ������ � ������������
        endGamePanel.SetActive(false);

        // �������� ����� ������� �����
        UpdateHighScoreText();

        // �������� ��������� � ������ �����������
        restartButton.onClick.AddListener(RestartGame);
    }

    IEnumerator StartCountdown()
    {
        float currentTime = countdownTime;

        while (currentTime > 0)
        {
            // ��������� ����� �� UI
            countdownText.text = currentTime.ToString("F0"); // ���������� ����� �����

            // ���� ���� �������
            yield return new WaitForSeconds(1f);

            // ��������� ������� �����
            currentTime--;
        }

        // ��������� ����� �� UI �� "Go!" ��� ������� �����
        countdownText.text = "Go!";

        // ���� ���� �������, ����� �������� "Go!"
        yield return new WaitForSeconds(1f);

        // ������� �����
        countdownText.gameObject.SetActive(false);

        // �������� ����
        StartGame();
    }

    void StartGame()
    {
        // �������� ��� ����������� ������� � �������� ��� ������ ����
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

        // ���������������� ���������� ����� ���� � ��������� ������
        remainingGameTime = gameDuration;
        isGameActive = true;
        StartCoroutine(GameTimer());
    }

    IEnumerator GameTimer()
    {
        while (remainingGameTime > 0 && isGameActive)
        {
            // ��������� ����� ������� �� UI
            timerText.text = "Time: " + remainingGameTime.ToString("F0"); // ���������� ����� �����

            // ���� ���� �������
            yield return new WaitForSeconds(1f);

            // ��������� ���������� �����
            remainingGameTime--;
        }

        // ����������� ����
        EndGame();
    }

    void EndGame()
    {
        isGameActive = false;

        // ��������� �������� ��������
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

        // ��������� ����������� �������� � ���������� ������
        if (cannonShot != null) cannonShot.enabled = false;
        if (cannonControl != null) cannonControl.enabled = false;

        // �������� ������ � ������������
        endGamePanel.SetActive(true);

        // �������� ����� � ������������
        endGameText.text = "The end of the game\nDucks Destroyed: " + duckCounter.duckCount;

        // ��������� ������� ���� � ������ ScoreData
        if (scoreData != null)
        {
            // ���� ������� ���� ������ ������������ ���������� �����, ��������� ���
            if (duckCounter.duckCount > scoreData.HighScore)
            {
                scoreData.HighScore = duckCounter.duckCount;
                SaveScoreData();
                UpdateHighScoreText(); // �������� ����� ������� �����
            }
        }
    }

    void RestartGame()
    {
        // ������������� ������� �����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // ����� ��� ���������� ������ ScoreData
    void SaveScoreData()
    {
        if (scoreData != null)
        {
            // ��������� ������ � PlayerPrefs
            PlayerPrefs.SetInt("HighScore", scoreData.HighScore);
            PlayerPrefs.Save();
        }
    }

    // ����� ��� ���������� ������ ������� �����
    void UpdateHighScoreText()
    {
        if (scoreData != null)
        {
            highScoreText.text = "High Score: " + scoreData.HighScore;
        }
    }

    // ����� ��� ���������� ����������� ������� ����
    public void AddTime(float additionalTime)
    {
        remainingGameTime += additionalTime;
        // ��������� ����� ������� �� UI
        timerText.text = "Time: " + remainingGameTime.ToString("F0"); // ���������� ����� �����
    }
}
