using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDestroy : MonoBehaviour
{
    // Количество очков заработаных игроком
    private int gameScoer;

    // Цена врагов на счетчике. Кажется, нужно убрать эту переменную во врага и вызов функции тоже
    public int enemyScorePrise = 1;
    // Тащим объект из движка, чтобы отображать в нем значение количества очков
    public TextMeshProUGUI gameScoreText;
    // Отдаем счет в CharHealth
    public float SendScore{
        get {return gameScoer;}
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        CheckThisEnemy(other);
    }

    private void CheckThisEnemy(Collider2D other) {
    // Если это враг
        if (other.gameObject.CompareTag("Enemy")) {
            // тут нужно добавить счет к счетчику
            ChangeScore(enemyScorePrise);
            Destroy(other.gameObject); // Уничтожить врага
        }
    }
    
    public void ChangeScore(int upScore) { // Интерфейс изменения очков
        gameScoer += upScore; // Прибавляем очки к очкам заработаным игроком
        UpdateScoreText(); // Вызываем функцию обновления текста со счетом
    }
    void UpdateScoreText() // Функция обновления текста со счетом
    {
        gameScoreText.text = "Счет = " + gameScoer.ToString(); // Передаем в текст объекта с текстом строку с надписью и заработаными за раунд очками
    }
}
