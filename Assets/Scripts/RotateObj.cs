using UnityEngine;
public class RotateWithCamera : MonoBehaviour
{
    private Transform cameraTransform;
    private void Start()
    {
        // Получаем компонент Transform камеры
        cameraTransform = Camera.main.transform;
    }
    private void Update()
    {
        // Получаем текущий угол поворота камеры по оси Y
        float cameraRotationY = cameraTransform.eulerAngles.y;
        
        // Создаем новый вектор поворота для объекта
        Vector3 newRotation = new Vector3(transform.eulerAngles.x, cameraRotationY, transform.eulerAngles.z);
        
        // Применяем новый вектор поворота для объекта
        transform.rotation = Quaternion.Euler(newRotation);
    }
}