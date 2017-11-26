using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;
    //private array
    [SerializeField]
    private GameObject[] powerups;

    //Spawn behaviour fix variable gamemanager
    private GameManager gameManager;

	// Use this for initialization
	void Start ()
    {

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
	}
	
    //Method to start spawn routines when game begins
    public void StartSpawnRoutines()
    {
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }

	//every five seconds we want to spawn an enemy
    IEnumerator EnemySpawnRoutine()
    {
        //while game over is false spawn
        while (gameManager.gameOver == false)
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }


    IEnumerator PowerupSpawnRoutine()
    {
        //while gameover is false spawn
        while (gameManager.gameOver == false) {
            //random range 1-2-3
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
