using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
    public float StartSpeed = 8f;
    [HideInInspector]
    public float speed;
    /*public float speedawal;
    private Waypoints Points;*/
    //public float CD = 5f;
    public float Starthealth = 100f;
    private float health;
    public float Damage = 50f;
    public int Defense = 40;

    public Image life;
	// Use this for initialization
	void Start () {
        speed = StartSpeed;
        health = Starthealth;
        //Points = GameObject.FindGameObjectWithTag("Waypoints").GetComponent<Waypoints>();
	}

    public void TakeDamage(float amount)
    {
        health -= amount;

        life.fillAmount = health / Starthealth;

        if (health <= 0)
        {
            Die();
            PlayerStats.Money += 100;
        }
    }

    public void Slow(float pct)
    {
        speed = StartSpeed * (1f - pct);
    }

    void Die()
    {
        Destroy(gameObject);
    }

	// Update is called once per frame
}
