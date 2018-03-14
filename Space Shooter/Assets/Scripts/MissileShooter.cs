using UnityEngine;
using System.Collections;

public class MissileShooter : MonoBehaviour
{

    public Vector3 spawnValues;
    public float spawnDelay;
    public float respawnDelay;
    public GameObject missilePrefab;
    private int loop = 1;
    static bool gameOver = false;



    void Start()
    {
        // Calls Coroutine to start spawning rockets
        StartCoroutine(SpawnWaves());

    }

    // used to spawn rockets
    IEnumerator SpawnWaves()
     {
         yield return new WaitForSeconds(spawnDelay);

         while (true)
         {
            if (gameOver == true)
            {
                break;
            }

            Instantiate(missilePrefab, new Vector3(Random.Range(-spawnValues.x, spawnValues.x) , 0, 20), Quaternion.identity);
             loop++;

            yield return new WaitForSeconds(respawnDelay);

        }
    }
}
