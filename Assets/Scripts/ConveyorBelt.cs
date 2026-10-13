using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [Header("ตั้งค่าความเร็วและทิศทาง")]
    public float speed = 1.0f;
    public Vector3 direction = Vector3.forward; // ทิศทางที่ขยะจะไหล

    private Rigidbody rb;
    private Material beltMaterial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb != null) rb.isKinematic = true;

        // ดึง Material จาก MeshRenderer บนตัวสายพานเพื่อเอามาเลื่อนภาพ
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            beltMaterial = renderer.material;
        }
    }

    void Update()
    {
        // 1. ส่วนภาพ (Visual): เลื่อนลวดลาย Texture (UV Scrolling) ให้ดูเหมือนวิ่ง
        if (beltMaterial != null)
        {
            float offset = Time.time * speed;
            beltMaterial.mainTextureOffset = new Vector2(0, offset);
            // หมายเหตุ: ถ้าลายสายพานเลื่อนผิดแกน ให้สลับเป็น new Vector2(-offset, 0);
        }
    }

    void FixedUpdate()

    {

        // 2. ส่วนฟิสิกส์ (Physics): ดันวัตถุ 3D ที่ตกลงมาให้ไหลไปตามสายพาน

        // เทคนิค MovePosition จะทำให้ฟิสิกส์เนียนและของไม่กระตุก

        if (rb != null)

        {

            Vector3 currentPos = rb.position;

            rb.position += transform.TransformDirection(direction) * speed * Time.fixedDeltaTime;

            rb.MovePosition(currentPos);

        }

    }

}

