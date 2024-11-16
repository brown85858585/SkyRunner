using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInter : MonoBehaviour
{
    private bool isPaused; // Если true - то игра на паузе
    public GameObject pausePanel; // Принимаем объект панели паузы, чтобы ее скрыть и показать
    void Start(){}
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { // Если раз нажали Пробел
            if (isPaused) { // Если игра на паузе
                ResumeMake(); // Вызов функции венуть игру с паузы
            } else { // Если же игра не на паузе
                PauseMake(); // Поставить игру на паузу
            }
        }
    }
    private void ResumeMake() { // Функция убрать с паузы
        pausePanel.SetActive(false); // Скрываем панель паузы
// Возвращает всем зависимым от времени переменным нормальны машштаб
        Time.timeScale = 1f;
        isPaused = false; // Теперь игра не на паузе
    }
    private void PauseMake() { // Функция ставит игру на паузу
        pausePanel.SetActive(true); // Показываем панель паузы
// Умножаем на ноль все скорости в игре зависящие от Time
        Time.timeScale = 0f;
        isPaused = true; // Теперь игра не на паузе
    }
}
