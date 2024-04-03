using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollower : MonoBehaviour
{ 
    [HideInInspector]public float sensitivity = 100f; // Чувствительность мышки
    private float rotationX = 0f;
    [Header("Camera Preferences")]
    public Transform target; // Ссылка на объект, за которым должна следовать камера
    public float smoothSpeed = 0.125f; // Скорость сглаживания

    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Ограничение угла обзора камеры
        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f); // Вращение камеры по оси X
        transform.parent.Rotate(Vector3.up * mouseX); // Вращение всего игрового объекта по оси 
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
   
   
}
