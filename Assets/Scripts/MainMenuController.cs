using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    private GameObject Background;

    private void Awake()
    {
        GameObject.Find("Background");
    }

    void Update()
    {
        /*
        if (Input.anyKey || Input.GetMouseButton(0))
        {

            SceneManager.LoadScene(1);
        }
        */
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
