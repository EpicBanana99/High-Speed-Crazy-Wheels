using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SpawnEnemies : MonoBehaviour
{
    private static SpawnEnemies _instance;
    
    public float EnemySpeed;

    //Time between spawn variables
    private float TimeBtwSpawn;
    public float TimeBtwSpawnAtStart;
    
    //Enemy prefabs
    [SerializeField]
    private GameObject[] cars;
    
    //Spawn positions(4)
    [SerializeField]
    private Transform[] spawnPos;
    

    public static SpawnEnemies Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("SpawnEnemies");
                go.AddComponent<SpawnEnemies>();
            }

            return _instance;
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //Timer
        if (TimeBtwSpawn <= 0)
        {
            float chances = Random.Range(1, 101);
            TimeBtwSpawn = TimeBtwSpawnAtStart;
            SpawnEnemy();
            TimeBtwSpawn = TimeBtwSpawnAtStart;
        }
        else
        {
            TimeBtwSpawn -= Time.deltaTime;
        }
    }
    //Spawn method
    void SpawnEnemy()
    {
        Vector3 pickedSpawnPos
    }
   

}
