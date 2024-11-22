using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowSpawn : MonoBehaviour
{
    public GameObject lastSpawnMine; // Интерфейс, чтобы суда записывалась последняя мина
    [SerializeField] private float _accelMineSpeed = 1; // Увеличение скорости мин в секунду. Ускорение
    private float _mineSpeedPlus = 0f; // Множитель скорости мин приходится писать суда. Мины слишком мало живут, чтобы чтото запомнить
    public GameObject[] mineRows; // Суда нужно передать все префабы с рядами мин
    // [SerializeField] private float spawnDelay = 2; // Время в секундах до нового создания ряда с минами
    [SerializeField] private float saveIntrval = 5; // Безопасное расстояние для создания нового ряда бомб
    private int selectMineRow; // Случайный ряд по индексу массима
    private bool contineSpawn = true; // Переменная указывающая стоит ли спавнить бомбы дальше
    public void togleSpawn (bool togle){
        if (togle) {
            contineSpawn = true;
        } else {
            contineSpawn = false;
        }
    }

    public float mineSpeedPlus => _mineSpeedPlus; // Даем на чтение интерфейс для увели

    void Start(){}

    void Update()
    {
        if (contineSpawn){ // Если работает спавнер
            _mineSpeedPlus += _accelMineSpeed * Time.deltaTime; // Увеличиваем скорость каждую секунду. Так игра быстрее сходится.
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
