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
    // Текст перед значением счета в игре
    private string gameScoerTextString = "Счет = ";
    // Тэг для обнаружения противников
    private string compareTagEnemy = "Enemy";
    // Отдаем счет в CharHealth
    public float SendScore{
        get {return gameScoer;}
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        CheckIfThisEnemy(other);
    }

    private void CheckIfThisEnemy(Collider2D other) {
    // Если это враг
        if (other.gameObject.CompareTag(compareTagEnemy)) {
            // тут нужно добавить счет к счетчику
            ChangeScore(enemyScorePrise);
            // Уничтожить врага
            Destroy(other.gameObject);
        }
    }
    
    public void ChangeScore(int upScore) { // Интерфейс изменения очков
        gameScoer += upScore; // Прибавляем очки к очкам заработаным игроком
        UpdateScoreText(); // Вызываем функцию обновления текста со счетом
    }
    void UpdateScoreText() // Функция обновления текста со счетом
    {
        gameScoreText.text = gameScoerTextString + gameScoer.ToString(); // Передаем в текст объекта с текстом строку с надписью и заработаными за раунд очками
    }
}
