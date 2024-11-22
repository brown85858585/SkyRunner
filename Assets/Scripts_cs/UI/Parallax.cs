using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length; // Длинна петил паралакса
    private Vector3 startPosition; // Начальная позиция фона
    public float paralSpeed = 0.5f; // Скорость паралакса фона
    void Start()
    {
        StartPositionLength();
    }

    void Update()
    {
        BackMove();
        BackPortal();
    }

    private void StartPositionLength() {
        // Размер по оси y
        length = GetComponent<SpriteRenderer>().bounds.size.y;
        // Сохраняем начальную позицию
        startPosition = transform.position;
    }

    private void BackMove() {
        // Перемещаем фон
        transform.position += Vector3.down * paralSpeed * Time.deltaTime;
    }

    private void BackPortal() {
        // Проверяем, нужно ли переместить фон
        if (transform.position.y <= startPosition.y - length){
            // Возвращаем фон в начальную позицию
            transform.position = startPosition;
        }
    }
}
