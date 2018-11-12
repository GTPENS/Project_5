using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {
    public Button Home;
    // Use this for initialization
    void Start () {
        Home.onClick.AddListener(OutOfCredit);
    }

    // Update is called once per frame
    public void OutOfCredit()
    {
        SceneManager.LoadScene("Menu");
    }
}
