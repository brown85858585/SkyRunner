using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDestroy : MonoBehaviour
{
    private int gameScoer; // Количество очков заработаных игроком
    public int enemyScorePrise = 1; // Цена врагов на счетчике. Кажется, нужно убрать эту переменную во врага и вызов функции тоже
    public TextMeshProUGUI gameScoreText; // Тащим объект из движка, чтобы отображать в нем значение количества очков
    void Start(){}
    void Update(){}
    
    private void OnTriggerEnter2D(Collider2D other){ // При косании колайдера
        if (other.gameObject.CompareTag("Enemy")) { // Если это враг
            // other.gameObject.GetComponent<CharHealth>().TakeDamage(mineDamage);
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
    public float SendScore{
        get {return gameScoer;}
    }
}
