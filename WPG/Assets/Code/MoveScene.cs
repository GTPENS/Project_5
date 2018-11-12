using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public Button Play;
    public Button Credit;
    public Button Exit;
    public Button Help;
    public Button Cross;
    public GameObject tutorial;
    public GameObject menu;
    public static bool lets = false;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Play.onClick.AddListener(PlayTouch);
        Credit.onClick.AddListener(CreditTouch);
        Exit.onClick.AddListener(ExitTouch);
        Help.onClick.AddListener(HelpTouch);
        Cross.onClick.AddListener(CrossTouch);
    }

    public void PlayTouch()
    {
        SceneManager.LoadScene("ConquerMaps");
        lets = true;
    }
    public void CreditTouch()
    {
        SceneManager.LoadScene("Credit");
    }
    public void ExitTouch()
    {
        Debug.Log("Exitting The Game");
        Application.Quit();
    }
    public void HelpTouch()
    {
        tutorial.gameObject.SetActive(true);
        menu.gameObject.SetActive(false);
    }
    public void CrossTouch()
    {
        tutorial.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }
}
