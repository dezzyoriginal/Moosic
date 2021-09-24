using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RentController : MonoBehaviour
{
    public static RentController instance;
    public bool isActive;
    private bool initiated;
    [SerializeField] GameObject tutorialWindow, rentWindow, background;

    private bool showingTutorial, showingRent, hiding;

    public int remainingDebt= 10000;
    public TextMeshProUGUI text, debtCounter;
    public int debtPayment;


    void Start()
    {
        instance = this;
        initiated = false;
    }

    void Update()
    {
        if (!hiding)
        {
            if (showingTutorial) tutorialWindow.SetActive(true);
            if (showingRent) rentWindow.SetActive(true);
            background.SetActive(true);
        }
        else
        {
            tutorialWindow.SetActive(false);
            rentWindow.SetActive(false);
            background.SetActive(false);
        }

        text.text = remainingDebt.ToString() + " $\nDebt Remaining";
        debtCounter.text = remainingDebt.ToString() + " $\nDebt Remaining";
    }

    public void Show()
    {
        if (!initiated) ShowTutorial();
        else ShowRent();
        Time.timeScale = 0;
    }

    private void ShowRent()
    {
        showingRent = true;
        hiding = false;
        MoneyController.instance.PayRent();
    }
    private void ShowTutorial()
    {
        showingTutorial = true;
        initiated = true;
        hiding = false;
    }

    public void Hide()
    {
        showingTutorial = false;
        showingRent = false;
        hiding = true;
    }

    public void PayRent()
    {
        MoneyController.instance.ChangeMoney(debtPayment);
        remainingDebt -= debtPayment;
        Hide();
    }
}
