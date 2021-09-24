using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyController : MonoBehaviour
{
    public static MoneyController instance;
    public float money = 4500;
    public int rentPrice = 100;
    [SerializeField] public int initialValue;

    [SerializeField] private TextMeshProUGUI moneyDisplay;
    public float sellingPriceBonus;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private int addBy = 5;
    [SerializeField] private int sellLimit = 20;

    public List<int> moneyGraph;

    private void Awake()
    {
        instance = this;
        sellingPriceBonus= initialValue;
    }

    // Update is called once per frame
    void Update()
    {
        money = Mathf.RoundToInt(money);
        //string number = money.ToString();

        //System.String.Format("{0:n}", money);
        moneyDisplay.text = money.ToString() + " $";
        price.text = "You earn  " + sellingPriceBonus.ToString() + " %  profit /item";
        if (money < 0) money = 0;

        if (Input.GetKeyDown(KeyCode.M)) money += 5000;
    }

    public void PayRent()
    {
        money -= 100;
    }

    public void ChangeMoney(float changeBy)
    {
        money += changeBy;
    }

    public void updateMoneyGraph()
    {
        moneyGraph.Add(Mathf.RoundToInt(money));
    }

    public void PriceIncrease()
    {
        if (sellingPriceBonus < sellLimit) sellingPriceBonus += addBy;
        else sellingPriceBonus = sellLimit;
    }

    public void PriceDecrease()
    {
        if (sellingPriceBonus > -sellLimit) sellingPriceBonus -= addBy;
        else sellingPriceBonus = -sellLimit;
    }

    public void AddMoney(Item item)
    {
        float bonus = 1 + (sellingPriceBonus / 100f);
        money += item.price * bonus;
    }

}
