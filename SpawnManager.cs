using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject mobPrefab;
    private float enemyCount = 0;
    private float maxEnemies = 2;
    public int waveNumber = 1; //temp
    private PlayerController playerControllerScript;

    private Transform target;
    private int maxRange = 10;
    // Start is called before the first frame update
    void Start()
    {
        SpawnMob(waveNumber);

    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(10, 29);
        float spawnPosY = Random.Range(-3, 5);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            //waveNumber++;
            SpawnMob(waveNumber);
        }
    }

    void SpawnMob(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(mobPrefab, GenerateSpawnPosition(), mobPrefab.transform.rotation);
        }

        if (Vector3.Distance(target.position, transform.position) <= maxRange && (enemyCount < maxEnemies))
        {
            
        }
    }
}
