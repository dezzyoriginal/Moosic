using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    [Header("Time Settings")]
    public int timeWithinDay = 240;
    [Space(10)] public int dayCounter = 0;
    public int timeCounter = 0;
    [Space(10)] public int timeSpeed = 1;
    public float timeScaling;

    [Space(10), SerializeField] MoneyController moneyController;
    [SerializeField] SpawnerController spawnerController;
    [SerializeField] GameObject newspaper;
    [SerializeField] RentController rent;

    [Header("Button Settings")]
    [SerializeField] Image icon;
    [SerializeField] GameObject speedButton;
    /*
    public bool IsPaused()
    {
        if (Time.timeScale == 0) return true;
        else return false;
    }
    */
    public bool isPaused = false;
    public GameObject newDayButton;
    [SerializeField] private Sprite pause, play;

    public enum days {MON, TUE, WED, THU, FRI, SAT, SUN }
    public days currentDay;
    public bool initiated = false;
    //List<GameObject> cowsLeft;
    public bool noCowsLeft;
    public GameObject yellowWindow;
    private bool duringDaytime;

    //bool run = false;
    private void Start()
    {
        instance = this;
        currentDay = days.SUN;
        Sunday();
        initiated = true;
        //run = false;
        duringDaytime = false;
        timeCounter = 350;
        Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        //if (Input.GetMouseButtonDown(1)) OnPlay();
        if (duringDaytime == true)
        {
            newDayButton.SetActive(false);
            OpenYellowWindow(false);
        }
        else
        {
            newDayButton.SetActive(true);
            OpenYellowWindow(true);
        }


        if (MoneyController.instance.money > 0)
        {
            if (dayCounter % 7 == 1) currentDay = days.MON;
            else if (dayCounter % 7 == 2) currentDay = days.TUE;
            else if (dayCounter % 7 == 3) currentDay = days.WED;
            else if (dayCounter % 7 == 4) currentDay = days.THU;
            else if (dayCounter % 7 == 5) currentDay = days.FRI;
            else if (dayCounter % 7 == 6)
            {
                currentDay = days.SAT;
                initiated = false;
            }
            else if (dayCounter % 7 == 0)
            {
                currentDay = days.SUN;
                if (!initiated)
                {
                    //Debug.Log("fuck");
                    //if (timeCounter >= 100) Sunday();
                    Sunday();
                    initiated = true;
                }
            }

            noCowsLeft = (GameObject.FindGameObjectsWithTag("Cow").Length == 0);

            if (timeCounter < timeWithinDay) timeCounter += timeSpeed;
            else
            {
                if (noCowsLeft)
                {
                    //newDayButton.SetActive(true);
                    //StartNewDay();
                    duringDaytime = false;
                }
            }

            SpeedUIDisplayChanger();

        }
        else
        {
            
        }

        
    }

    private void Sunday()
    {
        //Debug.Log("this shit works bruh");
        //if(RentController.instance != null) RentController.instance.Show();
        if (TrendController.instance != null) TrendController.instance.SelectNewTopTrendingInstruments();
        //if (Newspaper.instance != null) Newspaper.instance.Show();
        moneyController.updateMoneyGraph();

        newspaper.SetActive(true);
        rent.Show();
        //Time.timeScale = 0;
        //icon.overrideSprite = pause;
        //isPaused = true;

        //OnPlay();
    }

    public void StartNewDay()
    {
        newDayButton.SetActive(true);
        OpenYellowWindow(true);
        dayCounter++;
        spawnerController.Reset();
        timeCounter = 0;    
        //OnPlay();
        duringDaytime = true;
    }

    public void OnPlay()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            icon.overrideSprite = play;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            icon.overrideSprite = pause;
            isPaused = true;
        }
    }

    public void OnSpeed()
    {
        Time.timeScale = timeScaling;
    }

    private void SpeedUIDisplayChanger()
    {
        
        if (!isPaused)
        {
            icon.overrideSprite = play;
            speedButton.SetActive(true);
        }
        else
        {
            icon.overrideSprite = pause;
            speedButton.SetActive(false);
        }
    }


    private void OpenYellowWindow(bool willOpen)
    {
        if (!willOpen)
        {
            if (yellowWindow.transform.localPosition.y < 300) yellowWindow.transform.Translate(Vector2.up * 0.8f);
            else yellowWindow.transform.localPosition = new Vector2(-66.5f, 300f);
        }
        else
        {
            if (yellowWindow.transform.localPosition.y > 0) yellowWindow.transform.Translate(Vector2.down * 0.8f);
            else yellowWindow.transform.localPosition = new Vector2(-66.5f, 0); 
        }
    }

    public void EndDay()
    {
        //timeCounter = timeWithinDay - 125;
    }
}
