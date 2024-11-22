using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInter : MonoBehaviour
{
    private bool isPaused = true; // Если true - то игра на паузе
    public GameObject pausePanel; // Принимаем объект панели паузы, чтобы ее скрыть и показать
    void Update()
    {
        InputSpaceDown();
    }

    private void InputSpaceDown() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (isPaused) { // Если игра на паузе
                // Вызов функции венуть игру с паузы
                ResumeMake();
            } else {
                // Поставить игру на паузу
                PauseMake();
            }
        }
    }
    private void ResumeMake() { // Функция убрать с паузы
        // Скрываем панель паузы
        pausePanel.SetActive(false);
        // Возвращает всем зависимым от времени переменным нормальны машштаб
        Time.timeScale = 1f;
        isPaused = false; // Теперь игра не на паузе
    }
    private void PauseMake() { // Функция ставит игру на паузу
        // Показываем панель паузы
        pausePanel.SetActive(true);
        // Умножаем на ноль все скорости в игре зависящие от Time
        Time.timeScale = 0f;
        // Теперь игра не на паузе
        isPaused = true;
    }
}
