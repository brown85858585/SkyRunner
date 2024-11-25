using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSlideX : MonoBehaviour
{
    // Скорость перемещения персонажа к его новой позиции
    [SerializeField] private float charSpeed = 30f;
    // // Скорость поворота носа корабля
    // [SerializeField] private float rotationSpeed = 5f;
    // угол поворота
    [SerializeField] private float rotationAngle = 45.0f;
    // Ограничения по X
    [SerializeField] private float minLeftPos = -7f;
    [SerializeField] private float maxRightPos = 7f;
    private float pointPosX = 0f; // Текущая позиция по X
     // Ось движения
    private string horizontal = "Horizontal";
    // Найдем звук двигателя на себе
    private AudioSource engineSound;
    // Найдем частицы двигателя на себе
    private ParticleSystem engineParticles;

    void Start() {
        warInitializer();
    }

    private void warInitializer() {
        engineSound = GetComponent<AudioSource>();
        engineParticles = GetComponent<ParticleSystem>();
    }

    void Update() {
        UpdatePosition();
        // UpdateRotation();
    }

    private void UpdatePosition() {
        pointPosX = GetInputMovement(pointPosX);
        pointPosX = ClampPosition(pointPosX);
        MoveToPosition(pointPosX);
    }

    private float GetInputMovement(float pointPos) {
        // Функция учитывает скорость и частоту кадров
        float movementInput = Input.GetAxis(horizontal);
        if (movementInput != 0) {
            SparksSoundsByMovingOn();
        }
        else {
            SparksSoundsByMovingOff();
        }
        pointPos += movementInput * charSpeed * Time.deltaTime;
        return pointPos;
    }

    private void SparksSoundsByMovingOn() {
        // Играем звук двигателя и разбрасываем частицы
        if (!engineSound.isPlaying) engineSound.Play();
        // if (!engineParticles.isPlaying) {
        //     engineParticles.Play();
        // };
    }

    private void SparksSoundsByMovingOff() {
        // Выключаем звук двигателя и частицы
        if (engineSound.isPlaying) engineSound.Stop();
        // if (engineParticles.isPlaying) {
        //     engineParticles.Stop();
        // };
    }

    private float ClampPosition(float pointPos) {
        // Ограничивает позичию по X правой и левой стороной экранац
        return Mathf.Clamp(pointPos, minLeftPos, maxRightPos);
    }

    private void MoveToPosition(float targetPosX) {
        // Перемещаем gameObject в позицию заданую GetAxisX
        transform.position = new Vector2(targetPosX, transform.position.y);
    }

    private void UpdateRotation() {
        // в теории, должен немного поворачивать нос в стороны
        float targetAngle = GetTargetAngle();
        RotateToTargetAngle(targetAngle);
    }

    private float GetTargetAngle() {
        float targetAngle = 0f;
        float movementInput = Input.GetAxis(horizontal);

        if (movementInput > 0) {
            targetAngle = rotationAngle; // поворот направо
        }
        else if (movementInput < 0) {
            targetAngle = -rotationAngle; // поворот налево
        }
        else {// Если нет ввода, ставим нос по курсу
            targetAngle = 0;
        }

        return targetAngle;
    }

    private void RotateToTargetAngle(float targetAngle)
    {
        // Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
        // Debug.Log("targetRotation " + targetRotation);
        transform.Rotate(0, 0, targetAngle, Space.World);
        Debug.Log("transform.rotation " + transform.rotation);
    }

    // void Update()
    // {
    //     // Перемещает позицию по X со скоростью charSpeed
    //     pointPosX = InputGetAxis (pointPosX);
    //     // Ограничивает перемещение указателя границами экрана
    //     pointPosX = Mathf.Clamp(pointPosX, minLeftPos, maxRightPos);
    //     // Персонаж движется в 2д пространстве к целевой позиции по X, через inputGetAxisClamp
    //     transform.position = new Vector2(pointPosX, transform.position.y);

    //     targetAngle = rotateHullMaker();
    //     // Поворачиваем объект к целевому углу
    //     Quaternion targetRotation = Quaternion.Euler( 0, 0, targetAngle);
    //     transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    // }

    private float InputGetAxis (float pointPos) {
        // Горизонтально перемещает позицию указателя вправо или влево с учетом частоты кадров
        pointPos += Input.GetAxis(horizontal) * charSpeed * Time.deltaTime;
        // Попробовать GetAxisRow?
        return pointPos;
    }

    private float rotateHullMaker() {
        float targetAngle = 0;
        // Если цель справа, поворачиваем напрво
        if (Input.GetAxis(horizontal) > 0) {
            targetAngle = rotationAngle; // поворот направо
        }
        else if (Input.GetAxis(horizontal) < 0) {
            targetAngle = -rotationAngle; // поворот налево
        }
        // Если нет ввода, ставим нос по курсу
        else {
            targetAngle = 0;
        }
        Debug.Log("targetCharPos Delta " + Input.GetAxis(horizontal) );
        Debug.Log("targetAngle " + targetAngle);
        return targetAngle;
    }
}
