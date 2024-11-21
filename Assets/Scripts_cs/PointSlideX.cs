using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSlideX : MonoBehaviour
{
    [SerializeField]
    private float
    minLeftPos = -8,    //Крайнее левое положение на экране
    maxRightPos = 8,    // Крайнее правое положение на экране
    pointDist = 30,     // Расстояние, которое прибавляется к позиции указателя каждый кадр
    pointPos;           // позиция целеуказателя
    public float PointPosX {
        get { return pointPos; }
    }

    void Update()
    {
        // Горизонтально перемещает позицию указателя вправо или влево с учетом частоты кадров
        pointPos += Input.GetAxis("Horizontal") * pointDist * Time.deltaTime;
        // Ограничивает перемещение указателя границами экрана
        pointPos = Mathf.Clamp(pointPos, minLeftPos, maxRightPos);

        // Перемещаем указатель со скоростью pointSpeed в положение pointPos из его текущей позиции
        transform.position = new Vector2(pointPos, transform.position.y);
    }
}
