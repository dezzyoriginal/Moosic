using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private StorageController storageController;
    [SerializeField] private MoneyController moneyController;

    public Item item;
    public Image thisInstrument, thisLevel;
    public RectTransform thisInstrumentRect, thisLevelRect;
    public Sprite[] instruments, levels;

    private int instrumentID;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.instance.ShowToolTip(item);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.instance.HideToolTip();
    }

    private void Start()
    {
        thisInstrumentRect.localScale = thisLevelRect.localScale = new Vector3(2.5f, 2.5f, 1);
    }

    private void Update()
    {
        switch (item.type)
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

        thisInstrument.sprite = instruments[instrumentID];
        thisInstrument.SetNativeSize();
        thisInstrument.transform.localScale = Vector3.one * 90f;

        switch (item.level)
        {
            case Item.proficiencyLevel.Kid:
                thisLevel.sprite = levels[0];
                break;
            case Item.proficiencyLevel.Beginner:
                thisLevel.sprite = levels[1];
                break;
            case Item.proficiencyLevel.Intermediate:
                thisLevel.sprite = levels[2];
                break;
            case Item.proficiencyLevel.Advance:
                thisLevel.sprite = levels[3];
                break;
            case Item.proficiencyLevel.Professional:
                thisLevel.sprite = levels[4];
                break;
            case Item.proficiencyLevel.WorldClass:
                thisLevel.sprite = levels[5];
                break;
        }

        thisLevel.SetNativeSize();
        thisLevel.transform.localScale = Vector3.one * 90f;
    }

    public void OnClick()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            for (int i = 0; i < 4; i++)
            {
                if (moneyController.money > item.price)
                {
                    moneyController.money -= item.price;
                    storageController.AddStorage(item);
                }
            }
        }

        if (moneyController.money > item.price)
        {
            moneyController.money -= item.price;
            storageController.AddStorage(item);
        }
    }

}
