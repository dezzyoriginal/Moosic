using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public GameObject window;
    public BGMController bgm;
    public Slider slider;

    public bool activeStatus;

    private void Start()
    {
        window.SetActive(false);
        activeStatus = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !activeStatus)
        {
            activeStatus = true;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && activeStatus)
        {
            activeStatus = false;
        }


        window.SetActive(activeStatus);
        bgm.volume = slider.value / 10;
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Leave()
    {
        activeStatus = false;
    }
}
