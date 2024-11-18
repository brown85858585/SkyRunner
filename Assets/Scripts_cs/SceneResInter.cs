using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResInter : MonoBehaviour
{
    void Start()    {}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
