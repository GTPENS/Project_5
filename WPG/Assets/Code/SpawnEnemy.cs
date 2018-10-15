using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform enemies;
    public Transform enemy;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;
    private float countdown = 5f;

    public Text WaveCD;

    private int waveNumber = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        WaveCD.text = "Next Wave : " + string.Format("{0:00.00}", countdown);
	}

    IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++)
        {
            Debug.Log("Wave Incoming");
            yield return new WaitForSeconds(0.5f);
            SpawnEnemies();
        }
        
    }

    void SpawnEnemies()
    {
        int n = Random.Range(1, 9);
        if (n == 1 || n == 2 || n ==3)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
        else if (n == 4 || n == 5 || n == 6)
        {
            Instantiate(enemies, spawnPoint.position, spawnPoint.rotation);
        }
        else if (n == 7 || n == 8 || n == 9)
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
