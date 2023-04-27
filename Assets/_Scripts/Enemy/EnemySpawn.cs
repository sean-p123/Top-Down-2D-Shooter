using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float SpawnRate = 2f;
    public GameObject EnemyPrefab;
    public GameObject BigEnemyPrefab;
    public Transform[] Spawnpoints;
    public PlayerController player;
    private float lastSpawnTime;
    public int maxSmallEnemies = 15;
    public int maxBigEnemies = 0;
    public int currentEnemies = 0;
    
    // Update is called once per frame
    void Update()
    {
        if (player == null) return;
        if(lastSpawnTime + SpawnRate < Time.time)
        {
            if (currentEnemies == maxSmallEnemies + maxBigEnemies)
            {
                Debug.Log("No more enemies");
                return;
            }

            var randomSpawnPoint = Spawnpoints[Random.Range(0, Spawnpoints.Length - 1)];
            //pick random number between 1 and 2 to decide if large or small enemy
            int randomNum = Random.Range(1, 3);
            //if there are small enemies left and the random number is 1
            if(randomNum == 1 && maxSmallEnemies >= 1)
            {
                GameObject enemy = Instantiate(EnemyPrefab, randomSpawnPoint.position, Quaternion.identity);
                enemy.transform.rotation = Quaternion.identity;
                currentEnemies++;
                maxSmallEnemies--;
            }
            //if there are big enemies left and the random number is 2
            else if (randomNum == 2 && maxBigEnemies >=1)
            {
                GameObject enemy = Instantiate(BigEnemyPrefab, randomSpawnPoint.position, Quaternion.identity);
                enemy.transform.rotation = Quaternion.identity;
                currentEnemies++;
                maxBigEnemies--;
            }
          
            
            lastSpawnTime = Time.time;
        }
        
    }
}
