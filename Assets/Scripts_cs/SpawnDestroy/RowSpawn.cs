using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSpawn : MonoBehaviour
{
    // Суда нужно передать все префабы с рядами мин
    public GameObject[] mineRows;
    // Интерфейс, чтобы суда записывалась последняя мина
    public GameObject lastSpawnMine;
    // Увеличение скорости мин в секунду. Ускорение
    [SerializeField] private float _accelMineSpeed = 1;
    // Безопасное расстояние для создания нового ряда бомб
    [SerializeField] private float saveIntrval = 5;
    // [SerializeField] private float spawnDelay = 2; // Время в секундах до нового создания ряда с минами

    // Множитель скорости мин приходится писать суда. Мины слишком мало живут, чтобы чтото запомнить
    private float _mineSpeedPlus = 0f;
    // Случайный ряд по индексу массима
    private int selectMineRow;
    // Переменная указывающая стоит ли спавнить бомбы дальше
    private bool contineSpawn = true;

    public void togleSpawn (bool togle) {
        // Интерфейс для включения спавна
        if (togle) {
            contineSpawn = true;
        } else {
            contineSpawn = false;
        }
    }

    public float mineSpeedPlus {
        get {return _mineSpeedPlus;}
    }

    void Update() {
        SpawnRowCheck(); 
    }

    private void SpawnRowCheck() {
        if (contineSpawn){
            // Увеличиваем скорость каждую секунду. Так игра быстрее сходится.
            _mineSpeedPlus += _accelMineSpeed * Time.deltaTime;
            SpawnRow();
        }
    }

    private void SpawnRow(){
        if (lastSpawnMine) { // Если существует последняя мина
            // Вычисляем расстояние между Создателем рядов и Миной
            float distanceMine = Mathf.Abs(transform.position.y - lastSpawnMine.transform.position.y);
            // Если расстояние больше безопасного интервала, тогда
            if (distanceMine >= saveIntrval) {
                // Получаем случайный ряд мин по индексу массива
                selectMineRow = Random.Range(0, mineRows.Length);
                // Создаем ряд мин номер 0 на позиции Создавателя
                Instantiate(mineRows[selectMineRow], transform.position, Quaternion.identity);
            }
        } else { // Если мина не существует, создаем ее
            // Получаем случайный ряд мин по индексу массива
            selectMineRow = Random.Range(0, mineRows.Length);
            // Создаем ряд мин номер 0 на позиции Создавателя
            Instantiate(mineRows[selectMineRow], transform.position, Quaternion.identity);
        }
    }
}
