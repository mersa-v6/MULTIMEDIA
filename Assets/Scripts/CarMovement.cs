using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5f; // سرعة السيارة
    private Rigidbody2D myRigidbody;
    private Vector3 change;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>(); // جلب مكون Rigidbody2D
    }

    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal"); // يمين ويسار
        change.y = Input.GetAxisRaw("Vertical");   // فوق وتحت
        MoveCar();
    }

    void MoveCar()
    {
        if (change != Vector3.zero)
        {
            // لو بتتحرك يمين أو يسار، ما تتحركش فوق أو تحت في نفس الوقت
            if (change.x != 0)
            {
                change.y = 0;
            }

            // تحريك السيارة
            myRigidbody.MovePosition(
                transform.position + change * speed * Time.fixedDeltaTime
            );

            // تدوير السيارة حسب اتجاه الحركة (اختياري)
            float angle = Mathf.Atan2(change.y, change.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90); // -90 عشان السيارة تكون في الاتجاه الصح
        }
    }
}