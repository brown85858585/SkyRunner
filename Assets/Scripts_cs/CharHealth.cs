using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharHealth : MonoBehaviour
{
    // Надпись в графе жизней
    private string HealthBarText = "Жизни = ";
    // Жизни обладателя задаются в движке
    [SerializeField] private int charHealth = 5;

    // Тащим объект из движка, чтобы отображать в нем значение жизней игрока
    public TextMeshProUGUI charHealthText;
    // Тащим объект из движка, чтобы отображать в нем значение набранных очков
    public TextMeshProUGUI endGameScoreText;

    // Тащим объект из движка с игровыми полями (обучение, жизни, счет)
    public GameObject gameUI;
    // Тащим суда объект конечной панели
    public GameObject endPanel;
    // Тащим объект из движка, чтобы отображать в нем значение количества очков
    public GameObject pointer;
    public GameObject rowSpawn; // Ссылка на RowSpawn

    // Тащим сдуа сам скрипт CountDestroy, чтобы получить значение счета через его метод
    public CountDestroy countDestroy;
    // Тащим ресурс с музыкой. При смерти остановим
    public AudioSource audioSource;
    
    void Start() {
        UpdateHealthText();
    }

    public void TakeDamage(int damage) {
    // Интерфейс. Функция получение урона владельцем. Урон в размере damage
        DecrisHealth(damage);
        IfPlayerDie();
        UpdateHealthText();
    }
    
    void UpdateHealthText() {
    // Записывает количество жизней в объект в Canvas
        charHealthText.text = HealthBarText + charHealth.ToString();
    }

    private void DecrisHealth(int damage) {
    // Отнять жизни у владельца в размере damage
        charHealth -= damage;
    }

    private void IfPlayerDie() {
        // Если у обладателя закончились жизни
        if (charHealth <= 0) {
            ShowEndGameScore();
            EndGameSetInactive();
        }
    }

    private void ShowEndGameScore() {
            // Пользуемся методом, который отдест значение игрового счетчика очков из его скрипта
            float gameScore = countDestroy.SendScore;
            // Выводим это значение в текст с очками в конечной панели
            endGameScoreText.text = gameScore.ToString();
            // Запускаем панель конца раунда
            endPanel.SetActive (true);
    }

    private void EndGameSetInactive() {
            // Интерфейс спавнера, чтобы работать перестал
            rowSpawn.GetComponent<RowSpawn>().togleSpawn (false);
            // Скрываем обладателя
            gameObject.SetActive (false);
            // Скрываем жизни игрока
            charHealthText.gameObject.SetActive (false);
            // Скрываем игровые поля (обучение, жизни, счет)
            gameUI.SetActive (false);
            // Останавливаем музыку
            audioSource.Stop();
    }
}
