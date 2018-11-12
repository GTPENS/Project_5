using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveMaps : MonoBehaviour
{
    private SpriteRenderer rend;
    public Button Maps1;
    public Button Maps2;
    public Button Maps3;
    public Button Maps4;
    public Button Maps5;
    public Button Maps6;
    public Button Maps7;
    public Button Maps8;
    public Button Home;
    public static bool lets = false;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Maps1.onClick.AddListener(Maps1Touch);
        Maps2.onClick.AddListener(Maps2Touch);
        Maps3.onClick.AddListener(Maps3Touch);
        Maps4.onClick.AddListener(Maps4Touch);
        Maps5.onClick.AddListener(Maps5Touch);
        Maps6.onClick.AddListener(Maps6Touch);
        Maps7.onClick.AddListener(Maps7Touch);
        Maps8.onClick.AddListener(Maps8Touch);
        Home.onClick.AddListener(HomeTouch);
    }

    public void Maps1Touch()
    {
        SceneManager.LoadScene("Maps1");
        MoveScene.lets = false;
        lets = true;
    }
    public void Maps2Touch()
    {
        SceneManager.LoadScene("Maps2");
        MoveScene.lets = false;
        lets = true;
    }
    public void Maps3Touch()
    {
        SceneManager.LoadScene("Maps3");
        MoveScene.lets = false;
        lets = true;
    }
    public void Maps4Touch()
    {
        SceneManager.LoadScene("Maps4");
        MoveScene.lets = false;
        lets = true;
    }

    public void Maps5Touch()
    {
        SceneManager.LoadScene("Maps5");
        MoveScene.lets = false;
        lets = true;
    }
    public void Maps6Touch()
    {
        SceneManager.LoadScene("Maps6");
        MoveScene.lets = false;
        lets = true;
    }
    public void Maps7Touch()
    {
        SceneManager.LoadScene("Maps7");
        MoveScene.lets = false;
        lets = true;
    }
    public void Maps8Touch()
    {
        SceneManager.LoadScene("Maps8");
        MoveScene.lets = false;
        lets = true;
    }
    public void HomeTouch()
    {
        SceneManager.LoadScene("Menu");
        MoveScene.lets = false;
        lets = true;
    }

    /*public void ChangeSprite(Sprite spr)
    {
        rend.sprite = spr;
    }

    public void RollBackSprite(Sprite spr)
    {
        rend.sprite = spr;
    }*/
}
