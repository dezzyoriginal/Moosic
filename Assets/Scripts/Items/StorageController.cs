using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StorageController : MonoBehaviour
{
    public static StorageController instance;
    public StoredItems[] storedItems;
    public TextMeshProUGUI[] itemNumberDisplay;

    public int selectedInstrument = 0;
    public bool hasUpdated = false;

    private void Start()
    {
        instance = this;
    }

    void Update()
    {
        for (int i = 0; i < storedItems.Length; i++)
        {
            itemNumberDisplay[i].text = storedItems[i].items.Count.ToString();
            if (storedItems[i].items.Count == 0) itemNumberDisplay[i].color = new Color(0.627f, 0.0784f, 0.0784f, 1f);
            else itemNumberDisplay[i].color = Color.black;
        }
    }

    public void AddStorage(Item item)
    {
        storedItems[item.instrumentID].items.Add(item);
    }


    public void CheckIfBuyable(Item.instrumentType type)
    {
        int instrumentID = 0;
        bool hasPrinted = false;
        bool hasBought = false;

        switch (type)
        {
            case Item.instrumentType.Drums:
                instrumentID = 0;
                break;
            case Item.instrumentType.Guitar:
                instrumentID = 1;
                break;
            case Item.instrumentType.Keyboard:
                instrumentID = 2;
                break;
            case Item.instrumentType.Piano:
                instrumentID = 3;
                break;
            case Item.instrumentType.Ukulele:
                instrumentID = 4;
                break;
            case Item.instrumentType.Violin:
                instrumentID = 5;
                break;
        }

        //float buyChance = PopularityController.instance.BuyChanceofInstrument(instrumentID);
        float buyChance = PopularityController.instance.GeneralBuyChance();
        float random = Random.Range(0f, 1f);
        //Debug.Log(random);

        if (random <= buyChance)
        {
            for (int i = 0; i < storedItems.Length; i++)
            {
                if (instrumentID == i)
                {
                    if (storedItems[i].items.Count > 0)
                    {
                        if (!hasBought)
                        {
                            PopularityController.instance.IncreasePop(instrumentID);
                            MoneyController.instance.AddMoney(storedItems[i].items[0]);
                            storedItems[i].items.RemoveAt(0);
                            if (!hasPrinted)
                            {
                                selectedInstrument = instrumentID;
                                hasUpdated = true;
                                hasPrinted = true;
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (!hasPrinted)
                        {
                            PopularityController.instance.DecreasePop(instrumentID);
                            selectedInstrument = 6;
                            hasUpdated = true;
                            hasPrinted = true;
                        }
                    }
                }
            }
        }
        else
        {
            shouldNotBuy();
        }
    }

    private void shouldNotBuy()
    {
        Debug.Log("Popularity too low");
        selectedInstrument = 6;
        hasUpdated = true;
    }

    public void ResetUpdateStatus()
    {
        hasUpdated = false;
    }
}

[System.Serializable]
public class StoredItems
{
    public List<Item> items;
}
