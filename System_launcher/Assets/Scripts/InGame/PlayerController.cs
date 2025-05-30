using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public FixedJoystick joystick; // 조이스틱 연결

    Rigidbody2D rb;
    private Camera cam;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    private float halfWidth, halfHeight;

    public Package carriedPackage;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;

        // 플레이어 사이즈 고려 (Sprite, Collider2D, Scale 등)
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector2 size = sr.bounds.size;
        halfWidth = size.x / 2;
        halfHeight = size.y / 2;

        // 화면 경계 계산 (카메라 뷰포트를 월드 좌표로 변환)
        minBounds = cam.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = cam.ViewportToWorldPoint(new Vector2(1, 1));
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

        

        Vector2 clampedPos = rb.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, minBounds.x + halfWidth, maxBounds.x - halfWidth);
        clampedPos.y = Mathf.Clamp(clampedPos.y, minBounds.y + halfHeight, maxBounds.y - halfHeight);
        rb.position = clampedPos;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (carriedPackage == null && other.CompareTag("Package"))
        {
            Debug.Log("플레이어 박스 충돌");
            Package pkg = other.GetComponent<Package>();
            if (!pkg.isPicked)
            {
                carriedPackage = pkg;
                pkg.PickUp(transform);
            }
            
        }
        if (other.CompareTag("Truck"))
        {
            Debug.Log("트럭 충돌");
        }
    }
}
