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
    //Some singleton things
    private static SpawnEnemies _instance;
    
    //General enemy speed
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
    

    //Some singleton things
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
        //Reset function, just to make it easy
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //Timer to spawn
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
        //Getting random position in spawnPos[] array
        Vector3 pickedSpawnPos = spawnPos[Random.Range(0, spawnPos.Length)].position;
        //Instantiating
        Instantiate(cars[Random.Range(0, cars.Length)], pickedSpawnPos, quaternion.Euler(0, 0, 0));
    }
   

}
