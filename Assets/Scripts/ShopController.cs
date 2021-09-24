using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    public static ShopController instance;

    [SerializeField] private ItemLibrary itemLibrary;
    [SerializeField] ItemDisplay[] itemDisplay;
    private int level = 0;

    public int price, actualPrice;

    private void Start()
    {
        instance = this;

        level = 0;
        itemLibrary.UpdateUnlockedItems(level);
        StoreReset();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            StoreReset();
        }
        actualPrice = price - 1900 * (7 - level);
        level = PlayerPrefs.GetInt("level", 0);
    }

    public void StoreReset()
    {
        MoneyController.instance.money -= 10;
        for (int i = 0; i < itemDisplay.Length; i++)
        {
            itemDisplay[i].item = itemLibrary.unlockedItems[Random.Range(0, itemLibrary.unlockedItems.Count)];
        }
    }

    public void IncreaseLevel(int priceButton)
    {
        //price = priceButton;
        bool check = false;
        if (MoneyController.instance.money >= actualPrice)
        {
            check = true;
            MoneyController.instance.money -= actualPrice;
        }
        if (check)
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 0) + 1);
            itemLibrary.UpdateUnlockedItems(PlayerPrefs.GetInt("level", 0));
        }
    }
}
