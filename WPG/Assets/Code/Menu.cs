using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {
    public Button Pause;
    public Button Play;
    public Button Restart;
    public Button Exit;
    public Button Maps;
    public GameObject MenuScreen;
    public Button Ok;
    public Button Oks;
    public GameObject pnl;

    // Use this for initialization
    void Start () {
        Time.timeScale = 1;
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        Pause.onClick.AddListener(pause);
        Play.onClick.AddListener(play);
        Restart.onClick.AddListener(restart);
        Maps.onClick.AddListener(maps);
        Exit.onClick.AddListener(exit);
        Ok.onClick.AddListener(ok);
        Oks.onClick.AddListener(oks);
    }
	
	// Update is called once per frame
	public void pause ()
    {
        Time.timeScale = 0;
        MenuScreen.SetActive(true);

    }
    public void play()
    {
        Time.timeScale = 1;
        MenuScreen.SetActive(false);
    }
    public void restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void maps()
    {
        SceneManager.LoadScene("ConquerMaps");
    }
    public void exit()
    {
        Time.timeScale = 1;
        MenuScreen.SetActive(false);
    }

    void Update()
    {
        if (PlayerStats.PlayerHealth <= 0)
        {
            pnl.gameObject.SetActive(true);
        }
    }
    public void ok()
    {
        SceneManager.LoadScene("ConquerMaps");
        MoveScene.lets = true;
        MoveMaps.lets = false;
    }
    public void oks()
    {
        SceneManager.LoadScene("ConquerMaps");
        MoveScene.lets = true;
        MoveMaps.lets = false;
    }
}
