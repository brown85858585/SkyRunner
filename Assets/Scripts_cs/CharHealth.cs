using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharHealth : MonoBehaviour
{
    [SerializeField] private int charHealth = 5; // Жизни обладателя задаются в движке
    public TextMeshProUGUI charHealthText; // Тащим объект из движка, чтобы отображать в нем значение жизней игрока

    public GameObject gameUI; // Тащим объект из движка с игровыми полями (обучение, жизни, счет)

    // public TextMeshProUGUI gameScoreText; // Тащим объект из движка, чтобы отображать в нем значение количества очков
    // public TextMeshProUGUI tutorText; // Тащим объект из движка, чтобы отображать в нем значение количества очков
    public TextMeshProUGUI endGameScoreText; // Тащим объект из движка, чтобы отображать в нем значение набранных очков
    public GameObject endPanel; // Тащим суда объект конечной панели
    public GameObject pointer; // Тащим объект из движка, чтобы отображать в нем значение количества очков
    public GameObject rowSpawn; // Ссылка на RowSpawn
    public CountDestroy countDestroy; // Тащим сдуа сам скрипт CountDestroy, чтобы получить значение счета через его метод
    public AudioSource audioSource; // Тащим ресурс с музыкой. При смерти остановим
    void Start()
    {
        UpdateHealthText();
    }

    void Update(){}
    public void TakeDamage(int damage)
    // Интерфейс. Функция получение урона владельцем. Урон в размере damage
    {
        charHealth -= damage; // Отнять жизни у владельца в размере damage
        if (charHealth <= 0) { // Если у обладателя закончились жизни
            // Пользуемся методом, который отдест значение игрового счетчика очков из его скрипта
            rowSpawn.GetComponent<RowSpawn>().togleSpawn (false); // Интерфейс спавнера, чтобы работать перестал
            float gameScore = countDestroy.SendScore;
            endGameScoreText.text = gameScore.ToString(); // Выводим это значение в текст с очками в конечной панели
            endPanel.SetActive (true); // Запускаем панель конца раунда
            gameObject.SetActive (false); // Скрываем обладателя
            charHealthText.gameObject.SetActive (false); // Скрываем жизни игрока
            gameUI.SetActive (false); // Скрываем игровые поля (обучение, жизни, счет)
            pointer.SetActive (false); // Скрываем целеуказатель
            audioSource.Stop(); // Останавливаем музыку
        }
        UpdateHealthText();
    }
    
    void UpdateHealthText()
    {
        charHealthText.text = "Жизни = " + charHealth.ToString();
    }
}
