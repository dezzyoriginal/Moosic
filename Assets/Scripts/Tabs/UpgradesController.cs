using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradesController : MonoBehaviour
{
    [SerializeField] private Upgrades[] upgrades;
    public TextMeshProUGUI milkPrice;

    //private int level = 0;

    public int price, actualPrice;

    void Start()
    {
        PlayerPrefs.SetInt("level", 0);
        //foreach (Upgrades item in upgrades) item.isBought = false;
    }

    private void Update()
    {
        actualPrice = price - 1900 * (7 - PlayerPrefs.GetInt("level", 0));
        //PlayerPrefs.SetInt("WheatUpgradePrice", actualPrice);
        milkPrice.text = actualPrice.ToString() + " $\n\nUnlocks New Instrument Tier";
    }
}

[System.Serializable]
public class Upgrades
{
    public Button button;
    //public bool isBought;
    public int price;
}
