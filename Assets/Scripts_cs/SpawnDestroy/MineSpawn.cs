using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawn : MonoBehaviour
{
    public GameObject minePrefab;

    void Start() {
        MineSpawnMaker();
    }

    private void MineSpawnMaker() {
        // Создаем одну мину
        Instantiate(minePrefab, transform.position, Quaternion.identity);
    }
}
