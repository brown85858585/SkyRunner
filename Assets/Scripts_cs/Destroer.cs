using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroer : MonoBehaviour
{
    public float lifeTime = 0; // Время жизни объекта и его скрипта. Задается в движке!!! Не тут

    void Update()
    {
        Destroy (gameObject, lifeTime); // Уничтожим объект через lifeTime секунд
    }
}
