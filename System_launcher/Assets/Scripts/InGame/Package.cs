using UnityEngine;

public class Package : MonoBehaviour
{
    public bool isPicked = false;
    private Transform followTarget;

    void Update()
    {
        if (isPicked && followTarget != null)
        {
            // 플레이어의 앞쪽 방향으로 박스 위치 이동
            Vector3 offset = followTarget.right.normalized * 0.5f; // 앞 방향으로 오프셋
            transform.position = followTarget.position + offset;
            transform.rotation = followTarget.rotation;
        }
    }

    public void PickUp(Transform player)
    {
        isPicked = true;
        followTarget = player;
        GetComponent<Collider2D>().isTrigger = true; // 픽업 중엔 트리거
    }

    public void Deliver()
    {
        isPicked = false;
        followTarget = null;
        // 효과: 사라지거나, 트럭에 넣거나 등
        Destroy(gameObject); // 예시: 상차되면 사라짐
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Truck") && isPicked)
        {
            Deliver();
            Debug.Log("박스 충돌");
        }

    }

}
