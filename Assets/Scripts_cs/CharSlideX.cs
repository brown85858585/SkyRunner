using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSlideX : MonoBehaviour
{
    [SerializeField]
    private float charSpeed = 30; // Скорость перемещения персонажа к его новой позиции
    private float targetCharPos = 0; // Целевая позиция персонажа по оси X
    public PointSlideX pointSlideX; // Забираем суда скрипт целеуказателя, чтобы узнать его позицию по X и следовать за ним
    void Start(){}

    void Update() // Каждый кадр
    {
        targetCharPos = pointSlideX.PointPosX; // Задаем целевую позицию персонажа по X, как позицию целеуказателя по X
        transform.position = Vector2.MoveTowards ( // Персонаж движется в 2д пространстве
            transform.position, // от своей позиции
            new Vector2 (targetCharPos, transform.position.y), // К целевой позиции по X и своей позиции по Y
            charSpeed * Time.deltaTime); // по скоростью charSpeed и учетом частоты кадров
    }
}
