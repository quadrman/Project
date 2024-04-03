 using UnityEngine;
using TMPro;
  
public class ChangeText : MonoBehaviour
{
    public static int itemCount=0;
    public TextMeshProUGUI textMeshPro; // Ссылка на компонент TextMeshPro
    private void Start()
    {
        // Пример изменения надписи при запуске игры
        textMeshPro.text = $@"coins:{itemCount}";
    }
  
         public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Проверяем, если персонаж входит в область объекта
        {
            itemCount++; // Увеличиваем счетчик
          textMeshPro.text= $@"coins:{itemCount}";
  
     Destroy(gameObject); // Уничтожаем объект после подбора
        }
           
    }

    }

  

