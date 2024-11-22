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
        FindSpawnerPos();
        // Получаем общее ускорение мин из спавнера
        // Так каждый ряд в игре будет лететь все быстрее в рамках раунда
        mineSpeed += rowSpawn.mineSpeedPlus;
    }

    void Update()
    {
        MineMoveHandler();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Если задел объект, то один раз бъем игрока
        PlayerAtack(other);
    }

    private void FindSpawnerPos() {
        moveY = transform.position.y; // Записываем позицию мины
        // Находим компонент RowSpawn на сцене (предполагается, что он добавлен к другому объекту)
        rowSpawn = FindObjectOfType<RowSpawn>(); // Ищим Спавнер
        if(rowSpawn != null) { // Если нашли спавнер
            // Сохраняем ссылку в спавнере на последнюю созданную мину
            rowSpawn.lastSpawnMine = this.gameObject;
        }
    }

    private void MineMoveHandler() {
        // Позиция мины все время уменльшается. Мина движется вниз
        moveY -= mineSpeed * Time.deltaTime;
        // Двигаем мину вниз по Y и оставляем по X
        transform.position = new Vector2(transform.position.x, moveY);
    }

    private void PlayerAtack(Collider2D playerOther) {
        string playerCompareTagPlayer = "Player"; // Просто люблю это слово
        if (playerOther.gameObject.CompareTag(playerCompareTagPlayer)) { // Если это игрок
            // Отнять у игрока одну жизнь. Прописана в жизнях игрока
            playerOther.gameObject.GetComponent<CharHealth>().TakeDamage(mineDamage);
            Destroy(gameObject); // Уничтожить саму мину
        }
    }
}

