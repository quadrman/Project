 using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public Transform target; // Целевой объект, за которым игрок будет следовать
    [Header("Enemy Stats")]
    [Range(1,20)] public float moveSpeed = 5f; // Скорость движения игрока
    [Range(1,20)]public float jumpForce = 5f; // Сила прыжка игрока
    [HideInInspector]public bool isGrounded = true; // Флаг, указывающий, находится ли игрок на земле
    
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Проверяем, нажата ли клавиша прыжка и игрок находится на земле
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Применяем силу к Rigidbody для прыжка
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        // Вычисляем направление к целевому объекту
        Vector3 direction = (target.position - transform.position).normalized;

        // Вычисляем новую позицию игрока с учетом скорости и направления
        Vector3 newPosition = transform.position + direction * moveSpeed * Time.deltaTime;

        // Перемещаем игрока к новой позиции
        transform.position = newPosition;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Проверяем, столкнулся ли игрок с землей
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}