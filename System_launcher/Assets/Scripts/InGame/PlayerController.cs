using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public FixedJoystick joystick; // 조이스틱 연결

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 move = new Vector2(joystick.Horizontal, joystick.Vertical);
        
        if (move.sqrMagnitude > 0.01f)
        {
            rb.linearVelocity = move * moveSpeed;

            // 회전 방향 설정 (이동 벡터가 바라보는 방향)
            float angle = Mathf.Atan2(move.y, move.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
}
