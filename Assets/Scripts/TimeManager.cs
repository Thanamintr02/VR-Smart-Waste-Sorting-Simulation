
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [Header("ตั้งค่าเวลา")]
    public float timeLimit = 80f;

    private float currentTime;
    private bool isPlaying = false;

    [Header("UI และระบบอ้างอิง")]
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;

    [Header("Spawner ทั้งหมด")]
    public GameObject[] spawners;

    private void Start()
    {
        // เริ่มต้นเกมโดยยังไม่เดินเวลา
        currentTime = timeLimit;
        isPlaying = false;

        UpdateTimerUI();

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        Debug.Log("TimeManager พร้อมแล้ว - รอผู้เล่นกด Play");
    }

    public void StartTimer()
    {
        // ป้องกันกรณีเกมเคยถูกหยุดด้วย timeScale = 0
        Time.timeScale = 1f;

        currentTime = timeLimit;
        isPlaying = true;

        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        UpdateTimerUI();

        Debug.Log("เริ่มนับเวลาแล้ว");
    }

    private void Update()
    {
        // ถ้ายังไม่ได้กด Play จะไม่ลดเวลา
        if (!isPlaying)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            UpdateTimerUI();
            EndGame();
            return;
        }

        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        if (timerText != null)
        {
            timerText.text =
                "Time: " + Mathf.CeilToInt(currentTime).ToString();
        }
    }

    private void EndGame()
    {
        isPlaying = false;

        // ปิด Spawner เมื่อหมดเวลา
        if (spawners != null)
        {
            foreach (GameObject spawner in spawners)
            {
                if (spawner != null)
                    spawner.SetActive(false);
            }
        }

        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        if (finalScoreText != null)
        {
            int score = 0;

            if (ScoreManager.instance != null)
                score = ScoreManager.instance.currentScore;

            finalScoreText.text = "Final Score: " + score;
        }

        Debug.Log("Game Over!");
    }

    public void StopTimer()
    {
        isPlaying = false;
        Debug.Log("หยุดนับเวลาแล้ว");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;

        // รีเซ็ตคะแนน
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.currentScore = 0;
            ScoreManager.instance.AddScore(0);
        }

        // เปิด Spawner ใหม่
        if (spawners != null)
        {
            foreach (GameObject spawner in spawners)
            {
                if (spawner != null)
                    spawner.SetActive(true);
            }
        }

        // เริ่มรอบใหม่
        StartTimer();
    }

    public void GoToHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
