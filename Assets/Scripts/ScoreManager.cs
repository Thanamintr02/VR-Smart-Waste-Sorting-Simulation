using UnityEngine;
using TMPro; // เรียกใช้ระบบ TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; // สร้างตัวแปรให้สคริปต์อื่นเรียกใช้ได้ง่ายๆ

    [Header("UI Settings")]
    public TextMeshProUGUI scoreText; // ช่องสำหรับใส่ Text UI

    public int currentScore = 0;

    void Awake()
    {
        // กำหนดให้ instance คือสคริปต์ตัวนี้
        if (instance == null) instance = this;
    }

    // ฟังก์ชันสำหรับเพิ่มหรือลดคะแนน
    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();
    }
    void UpdateUI()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
}