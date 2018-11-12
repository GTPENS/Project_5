using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpawnEnemy : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform enemies;
    public Transform enemy;

    public Transform spawnPoint;
    public Transform otherPoint;

    public float timeBetweenWaves = 10f;
    private float countdown = 5f;

    public Text WaveCD;
    public static bool Above = false;
    public static bool Under = false;

    private int waveNumber = 0;
    public static int numberwaves;

    public GameObject panel;
    public static bool Win = false;
    public GameObject SFXwin;

    public int way;

    // Use this for initialization
    void Start () {
        numberwaves = waveNumber;
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
        if (waveNumber >= 10)
        {
            Time.timeScale = 0;
            panel.gameObject.SetActive(true);
            Win = true;
            GameObject SfxWin = (GameObject)Instantiate(SFXwin);
        }
        else
        {
            for (int i = 0; i < waveNumber; i++)
            {
                Debug.Log("Wave Incoming");
                yield return new WaitForSeconds(0.5f);
                SpawnEnemies();
            }
        }
    }

    void SpawnEnemies()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Maps3" || sceneName == "Maps4" || sceneName == "Maps5" || sceneName == "Maps6" || sceneName == "Maps8")
        {
            way = Random.Range(1, 4);
        }
        else if (sceneName == "Maps1" || sceneName == "Maps2" || sceneName == "Maps7")
        {
            way = Random.Range(1, 2);
        }
        int n = Random.Range(1, 9);
        if (way == 1 ||way == 2)
        {
            Above = true;
            Under = false;
            if (n == 1 || n == 2 || n == 3)
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

        else if (way == 3 || way == 4)
        {
            Under = true;
            Above = false;
            if (n == 1 || n == 2 || n == 3)
            {
                Instantiate(enemyPrefab, otherPoint.position, otherPoint.rotation);
            }
            else if (n == 4 || n == 5 || n == 6)
            {
                Instantiate(enemies, otherPoint.position, otherPoint.rotation);
            }
            else if (n == 7 || n == 8 || n == 9)
            {
                Instantiate(enemy, otherPoint.position, otherPoint.rotation);
            }
        }
    }
}
