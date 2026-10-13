using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    [Header("ตั้งค่าพรีแฟบขยะ")]
    [Tooltip("ลากพรีแฟบขยะต่างๆ มาใส่ในช่องนี้")]
    public GameObject[] trashPrefabs; // อาเรย์สำหรับเก็บพรีแฟบขยะหลายๆ แบบ

    [Header("ตั้งค่าเวลาและจุดเกิด")]
    public float spawnInterval = 3f; // ระยะเวลาในการสุ่มเสกขยะ (วินาที)
    public Transform spawnPoint; // ตำแหน่งที่จะให้ขยะเกิด

    void Start()
    {
        // สั่งให้ฟังก์ชัน SpawnRandomTrash ทำงานซ้ำๆ
        // โดยเริ่มทำงานวินาทีที่ 1 และทำซ้ำทุกๆ spawnInterval วินาที
        InvokeRepeating(nameof(SpawnRandomTrash), 1f, spawnInterval);
    }

    void SpawnRandomTrash()
    {
        // เช็คว่ามีการใส่พรีแฟบขยะไว้หรือไม่ ถ้าไม่ให้ข้ามไป
        if (trashPrefabs.Length == 0)
        {
            Debug.LogWarning("ยังไม่ได้ใส่พรีแฟบขยะในช่อง Trash Prefabs!");
            return;
        }

        // สุ่มตัวเลขตั้งแต่ 0 ถึงจำนวนพรีแฟบที่มี
        int randomIndex = Random.Range(0, trashPrefabs.Length);
        GameObject selectedTrash = trashPrefabs[randomIndex];

        // สร้างขยะออกมาตรงตำแหน่งและองศาของ spawnPoint
        Instantiate(selectedTrash, spawnPoint.position, spawnPoint.rotation);
    }
}