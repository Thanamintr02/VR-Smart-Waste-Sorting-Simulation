using UnityEngine;

public class TrashDestroyer : MonoBehaviour
{
    [Header("ตั้งค่าคะแนน")]
    public int missPenalty = -5; // คะแนนที่โดนหักเมื่อผู้เล่นหยิบไม่ทัน

    private void OnTriggerEnter(Collider other)
    {
        // เช็คก่อนว่าวัตถุที่ตกลงมาคือ "ขยะ" หรือไม่
        if (other.tag.StartsWith("Trash_"))
        {
            // เรียกฟังก์ชันหักคะแนนจาก ScoreManager
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(missPenalty);
            }

            // สั่งทำลายวัตถุทิ้ง ต้องอยู่ข้างในนี้ครับ! วัตถุอื่นจะได้ไม่โดนลบ
            Destroy(other.gameObject);
        }
    }
}