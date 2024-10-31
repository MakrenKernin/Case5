using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3f;   // Скорость ходьбы
    public float runSpeed = 6f;    // Скорость бега
    private float moveSpeed;       // Текущая скорость движения

    private Rigidbody rb;
    private Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        moveSpeed = walkSpeed;     // Начальная скорость — ходьба
    }

    void Update()
    {
        // Получаем оси движения WASD или стрелок
        float moveHorizontal = Input.GetAxis("Horizontal"); // A / D или стрелки влево / вправо
        float moveVertical = Input.GetAxis("Vertical");     // W / S или стрелки вверх / вниз

        // Направление движения по горизонтали и вертикали
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        // Переключаемся между бегом и ходьбой при нажатии Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;  // Скорость бега при нажатом Shift
        }
        else
        {
            moveSpeed = walkSpeed; // Скорость ходьбы в обычном режиме
        }
    }

    void FixedUpdate()
    {
        // Применяем движение к Rigidbody, умножая на скорость и время
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
