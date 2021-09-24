using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLibrary : MonoBehaviour
{

    public Item[] items;

    public List<Item> unlockedItems = new List<Item>();

    public void UpdateUnlockedItems(int level)
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].instrumentLevel <= level) unlockedItems.Add(items[i]);
        }
    }
}
