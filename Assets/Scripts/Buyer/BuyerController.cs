using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerController : MonoBehaviour
{
    private static BuyerController instance;
    //[SerializeField] private ItemLibrary itemLibrary;
    [SerializeField] private StorageController storageController;



    private Item.instrumentType chosenItem;


    private void Start()
    {
        instance = this;
    }


    private void SelectItem()
    {
        float selectedValue = Random.Range(0f, 100);

        float accumulatedPop = 0;
        for (int i = 0; i < TrendController.instance.trendingValues.Length; i++)
        {
            accumulatedPop += TrendController.instance.trendingValues[i];

            float accPopRatio = (accumulatedPop / TrendController.instance.totalTrendingValue) * 100;
            if (selectedValue <= accPopRatio)
            {
                ConvertIDtoType(i);
                break;
            }

        }

    }


    public void BuyProcess()
    {
        SelectItem();
        
        storageController.CheckIfBuyable(chosenItem);
    }

    public static void BuyProcess_Static()
    {
        instance.BuyProcess();
    }

    private void ConvertIDtoType(int id)
    {
        switch (id)
        {
            case 0:
                chosenItem = Item.instrumentType.Drums;
                break;
            case 1:
                chosenItem = Item.instrumentType.Guitar;
                break;
            case 2:
                chosenItem = Item.instrumentType.Keyboard;
                break;
            case 3:
                chosenItem = Item.instrumentType.Piano;
                break;
            case 4:
                chosenItem = Item.instrumentType.Ukulele;
                break;
            case 5:
                chosenItem = Item.instrumentType.Violin;
                break;
        }
        
    }
}

[System.Serializable]
public class RunTimeInstrumentPopularity
{
    public Item.instrumentType itemType;
    public int popularity;
}

