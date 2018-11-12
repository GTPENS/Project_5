using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {
    public static int Money;
    public int startMoney = 400;
    //[HideInInspector]
    public static float PlayerHealth;
    public float StarterPlayerHealth = 100f;
    public Image HealthBar;
    public GameObject SFXlose;

    public static bool Lose = false;
    // Use this for initialization
    void Start () {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Money = startMoney;
        PlayerHealth = StarterPlayerHealth;
    }
	
	// Update is called once per frame
	void Update () {
        HealthBar.fillAmount = PlayerHealth / StarterPlayerHealth;

        if (PlayerHealth <= 0)
        {
            Time.timeScale = 0;
            Lose = true;
            GameObject SfxLose = (GameObject)Instantiate(SFXlose);
        }
    }
}
