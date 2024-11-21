using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSlideX : MonoBehaviour
{
    // Скорость перемещения персонажа к его новой позиции
    [SerializeField] private float charSpeed = 30;
    // // Скорость поворота носа корабля
    // [SerializeField] private float rotationSpeed = 5;
    // // 
    // [SerializeField] private float targetAngle = 0;
    // // 
    // [SerializeField] private float rotationAngle = 45.0f;
     // Ось движения
    private string horizontal = "Horizontal";
    

    [SerializeField] private float
    minLeftPos = -7,    //Крайнее левое положение на экране
    maxRightPos = 7;    // Крайнее правое положение на экране
    private float pointPosX = 0; // Позиция, к которой движется char по X

    private float InputGetAxis (float pointPos) {
        // Горизонтально перемещает позицию указателя вправо или влево с учетом частоты кадров
        pointPos += Input.GetAxis(horizontal) * charSpeed * Time.deltaTime;
        // Попробовать GetAxisRow?
        return pointPos;
    }

    void Update()
    {
        // Перемещает позицию по X со скоростью charSpeed
        pointPosX = InputGetAxis (pointPosX);
        // Ограничивает перемещение указателя границами экрана
        pointPosX = Mathf.Clamp(pointPosX, minLeftPos, maxRightPos);
        // Персонаж движется в 2д пространстве к целевой позиции по X, через inputGetAxisClamp
        transform.position = new Vector2(pointPosX, transform.position.y);

            // Повороты корпуса доделаю, когда завершу рефакторинг кода
        // // Если цель справа, поворачиваем напрво
        // if (targetCharPos > transform.position.x) {
        //     targetAngle = rotationAngle; // поворот направо
        // }
        // if (targetCharPos < transform.position.x) {
        //     targetAngle = -rotationAngle; // поворот налево
        // }
        // if (targetCharPos == transform.position.x) {
        //     targetAngle = 0; // нос по курсу
        // }
        // Debug.Log("targetCharPos Delta " + (targetCharPos - transform.position.x));
        // Debug.Log("targetAngle " + targetAngle);
        
        // // Поворачиваем объект к целевому углу
        // Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        // transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
