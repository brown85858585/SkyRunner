using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResInter : MonoBehaviour
{
    void Update()
    {
        InputYDown();
    }

    private void InputYDown(){
        if (Input.GetKeyDown(KeyCode.Y)) {
            // Перезапускаем сцену
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
