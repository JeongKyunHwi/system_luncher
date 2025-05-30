using UnityEngine;

public class Package : MonoBehaviour
{
    public bool isPicked = false;
    private Transform followTarget;

    void Update()
    {
        if (isPicked && followTarget != null)
        {
            // �÷��̾��� ���� �������� �ڽ� ��ġ �̵�
            Vector3 offset = followTarget.right.normalized * 0.5f; // �� �������� ������
            transform.position = followTarget.position + offset;
            transform.rotation = followTarget.rotation;
        }
    }

    public void PickUp(Transform player)
    {
        isPicked = true;
        followTarget = player;
        GetComponent<Collider2D>().isTrigger = true; // �Ⱦ� �߿� Ʈ����
    }

    public void Deliver()
    {
        isPicked = false;
        followTarget = null;
        // ȿ��: ������ų�, Ʈ���� �ְų� ��
        Destroy(gameObject); // ����: �����Ǹ� �����
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Truck") && isPicked)
        {
            Deliver();
            Debug.Log("�ڽ� �浹");
        }

    }

}
