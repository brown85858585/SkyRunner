using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroer : MonoBehaviour
{
    // Время жизни объекта и его скрипта. Задается в движке!!! Не тут
    [SerializeField] public float lifeTime = 0;

    void Update()
    {
        // Уничтожим объект через lifeTime секунд
        Destroy (gameObject, lifeTime);
    }
}
