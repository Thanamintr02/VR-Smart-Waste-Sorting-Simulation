using UnityEngine;

public class TrashBin : MonoBehaviour
{
    [Header("ตั้งค่าถังขยะ")]
    public string correctTag;
    public int scoreReward = 10;
    public int scorePenalty = -5;

    [Header("เสียงเอฟเฟค")]
    public AudioClip correctSound; // ช่องใส่ไฟล์เสียงตอนทิ้งถูก
    public AudioClip wrongSound;   // ช่องใส่ไฟล์เสียงตอนทิ้งผิด
    private AudioSource audioSource;

    void Start()
    {
        // สั่งให้ระบบรู้จักคอมโพเนนต์ Audio Source ที่แปะอยู่กับถังขยะ
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.StartsWith("Trash_"))
        {
            if (other.CompareTag(correctTag))
            {
                ScoreManager.instance.AddScore(scoreReward);
                // เล่นเสียงตอนทิ้งถูก
                if (correctSound != null) audioSource.PlayOneShot(correctSound);
            }
            else
            {
                ScoreManager.instance.AddScore(scorePenalty);
                // เล่นเสียงตอนทิ้งผิด
                if (wrongSound != null) audioSource.PlayOneShot(wrongSound);
            }

            Destroy(other.gameObject);
        }
    }
}