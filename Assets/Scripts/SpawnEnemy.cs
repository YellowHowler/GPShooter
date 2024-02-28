using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;
    void Start()
    {
        StartCoroutine(SpawnEnemyCor());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnEnemyCor()
    {
        while(true) //repeat forever
        {
            Vector2 randomPos = Random.insideUnitCircle.normalized * 15; //get random position for enemy spawn
            Instantiate(enemy, randomPos, Quaternion.identity); //spawn enemy at location

            yield return new WaitForSeconds(2f); //wait for 2 seconds
        }
    }
}
