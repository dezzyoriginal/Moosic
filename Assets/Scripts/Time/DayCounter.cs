using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayCounter : MonoBehaviour
{
    [SerializeField] TimeController timeController;

    TextMeshProUGUI dayCounterText;

    void Start()
    {
        dayCounterText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //dayCounterText.text = " Day " + timeController.dayCounter.ToString();
        int weekNum = (TimeController.instance.dayCounter - (TimeController.instance.dayCounter % 7)) / 7;
        dayCounterText.text = " Week " + weekNum.ToString() + ": " + TimeController.instance.currentDay.ToString(); ;
    }
}
