using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopularityController : MonoBehaviour
{
    public static PopularityController instance;

    public float addBy = 1.5f;
    public float decreaseBy = 1f;
    public float generalPopularity, generalBuyChance; 
    public List<ItemBuyChance> itemBuyChance;
    public int offset;
    public void Start()
    {
        instance = this;
        offset = MoneyController.instance.initialValue;
    }
    /*
    public float BuyChanceofInstrument(int ID)
    {
        float storePop = itemBuyChance[ID].popularity;
        float price = MoneyController.instance.sellingPriceBonus;
        float buyChance = itemBuyChance[ID].buyChance;

        if (storePop <= price - 35) buyChance = storePop / (2 * price);
        else buyChance = 1;

        return buyChance;
    }
    */
    public float GeneralBuyChance()
    {
        float price = MoneyController.instance.sellingPriceBonus;
        if (generalPopularity <= price - offset - 5) generalBuyChance = generalPopularity / (2 * price);
        else generalBuyChance = 1;

        return generalBuyChance;
    }

    public void IncreasePop(int ID)
    {
        if (itemBuyChance[ID].popularity + addBy <= 100) itemBuyChance[ID].popularity += addBy;
        if (generalPopularity + addBy <= 100) generalPopularity += addBy;
    }

    public void DecreasePop(int ID)
    {
        if (itemBuyChance[ID].popularity -decreaseBy >=0) itemBuyChance[ID].popularity -= decreaseBy;
        if (generalPopularity -decreaseBy >=0) generalPopularity -= decreaseBy;
    }
}

[System.Serializable]
public class ItemBuyChance
{
    [Range(0f, 100f)] public float popularity = 0;
    public float buyChance; //from 0 to 1
}
