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
        length = GetComponent<SpriteRenderer>().bounds.size.y; // Размер по оси y
        startPosition = transform.position; // Сохраняем начальную позицию
    }

    void Update()
    {
        transform.position += Vector3.down * paralSpeed * Time.deltaTime; // Перемещаем фон

        // Проверяем, нужно ли переместить фон
        if (transform.position.y <= startPosition.y - length){
            transform.position = startPosition; // Возвращаем фон в начальную позицию
        }
    }
}
