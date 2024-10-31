using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3f;   // �������� ������
    public float runSpeed = 6f;    // �������� ����
    private float moveSpeed;       // ������� �������� ��������

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = walkSpeed;     // ��������� �������� � ������
    }

    void Update()
    {
        // �������� ��� �������� WASD ��� �������
        float moveHorizontal = Input.GetAxis("Horizontal"); // A / D ��� ������� ����� / ������
        float moveVertical = Input.GetAxis("Vertical");     // W / S ��� ������� ����� / ����

        // ����������� �������� �� ����������� � ���������
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        // ������������� ����� ����� � ������� ��� ������� Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;  // �������� ���� ��� ������� Shift
        }
        else
        {
            moveSpeed = walkSpeed; // �������� ������ � ������� ������
        }
    }

    void FixedUpdate()
    {
        // ��������� �������� � Rigidbody, ������� �� �������� � �����
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
