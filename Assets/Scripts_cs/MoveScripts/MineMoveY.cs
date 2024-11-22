using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMoveY : MonoBehaviour
{
    // Скорость движения мин
    [SerializeField] private float mineSpeed = 30;
    // Урон наносимы миной игроку. Задается в редакторе
    [SerializeField] private int mineDamage = 1;
    
    private float moveY; // Позиция мины
    private RowSpawn rowSpawn; // Ссылка на RowSpawn
    void Start()
    {
        moveY = transform.position.y; // Записываем позицию мины
        // Находим компонент RowSpawn на сцене (предполагается, что он добавлен к другому объекту)
        rowSpawn = FindObjectOfType<RowSpawn>(); // Ищим Спавнер
        if(rowSpawn != null) { // Если нашли спавнер
            rowSpawn.lastSpawnMine = this.gameObject; // Сохраняем ссылку в спавнере на последнюю созданную мину
        }
        mineSpeed += rowSpawn.mineSpeedPlus; // Получаем обзее ускорение мин из спавнера. Так каждый ряд в игре будет лететь все быстрее в рамках раунда
    }

    void Update()
    {
        moveY -= mineSpeed * Time.deltaTime; // Позиция мины все время уменльшается. Мина движется вниз
        transform.position = new Vector2(transform.position.x, moveY); // Двигаем мину вниз по Y и оставляем по X
        // Лучше конечно, когда она пройдет опредененное расстояние
        // Если положение мины меньше, чем нижний край поля (-7 с запасом), уничтожаем со взрывом
    }

    private void OnTriggerEnter2D(Collider2D other) // Если задел объект, то один раз
    {
        if (other.gameObject.CompareTag("Player")) { // Если это игрок
            other.gameObject.GetComponent<CharHealth>().TakeDamage(mineDamage); // Отнять у игрока одну жизнь. Прописана в жизнях игрока
            Destroy(gameObject); // Уничтожить саму мину
        }
    }
}

