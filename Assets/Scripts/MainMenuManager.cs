
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("หน้าต่าง UI")]
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject tutorialPanel;

    [Header("ระบบเกม")]
    public TimeManager timeManager;

    [Header("กลุ่ม Spawner ทั้งหมด")]
    public GameObject[] spawners;

    [Header("ระบบเสียง")]
    public AudioSource bgmSource;

    public void PlayGame()
    {
        Time.timeScale = 1f;

        // ซ่อนเฉพาะหน้าต่างเมนู
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        // ซ่อนหน้าต่างอื่น หากเปิดค้างอยู่
        if (tutorialPanel != null)
            tutorialPanel.SetActive(false);

        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        // เปิด Spawner ทั้งหมด
        if (spawners != null)
        {
            foreach (GameObject spawner in spawners)
            {
                if (spawner != null)
                    spawner.SetActive(true);
            }
        }

        // เริ่มนับเวลาเมื่อกด Play เท่านั้น
        if (timeManager != null)
        {
            timeManager.StartTimer();
            Debug.Log("Play Game!");
        }
        else
        {
            Debug.LogError(
                "MainMenuManager: ยังไม่ได้กำหนด TimeManager ใน Inspector!"
            );
        }
    }

    public void OpenTutorial()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (tutorialPanel != null)
            tutorialPanel.SetActive(true);

        Debug.Log("เปิด Tutorial - ยังไม่เริ่มเกม");
    }

    public void CloseTutorial()
    {
        if (tutorialPanel != null)
            tutorialPanel.SetActive(false);

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);
    }

    public void OpenSettings()
    {
        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(false);

        if (settingsPanel != null)
            settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        if (settingsPanel != null)
            settingsPanel.SetActive(false);

        if (mainMenuPanel != null)
            mainMenuPanel.SetActive(true);
    }

    public void ToggleMusic()
    {
        if (bgmSource != null)
            bgmSource.mute = !bgmSource.mute;
    }

    public void QuitGame()
    {
        Debug.Log("ออกจากเกมแล้ว");
        Application.Quit();
    }
}
