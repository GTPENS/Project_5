using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public static int Money;
    public int startMoney = 400;
    //[HideInInspector]
    public static float PlayerHealth;
    public float StarterPlayerHealth = 100f;
    public Image HealthBar;
    public Text GameOver;
    // Use this for initialization
    void Start () {
        Money = startMoney;
        PlayerHealth = StarterPlayerHealth;
    }
	
	// Update is called once per frame
	void Update () {
        HealthBar.fillAmount = PlayerHealth / StarterPlayerHealth;

        if (PlayerHealth <= 0)
        {
            GameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
