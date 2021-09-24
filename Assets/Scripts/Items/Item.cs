using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public bool isInstrument;
    public enum instrumentType {Violin, Guitar, Piano, Drums, Keyboard, Ukulele };
    public instrumentType type = instrumentType.Drums;
    public int instrumentID = 0;
    public int instrumentLevel = 0;

    public enum proficiencyLevel {Kid, Beginner, Intermediate, Advance, Professional, WorldClass}; //change this into int based

    public proficiencyLevel level;

    public int price;
    public Sprite artwork;

    private void Awake()
    {
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

        /*
        switch (level)
        {
            case Item.proficiencyLevel.Kid:
                instrumentLevel = 0;
                break;
            case Item.proficiencyLevel.Beginner:
                instrumentLevel = 1;
                break;
            case Item.proficiencyLevel.Intermediate:
                instrumentLevel = 2;
                break;
            case Item.proficiencyLevel.Advance:
                instrumentLevel = 3;
                break;
            case Item.proficiencyLevel.Professional:
                instrumentLevel = 4;
                break;
            case Item.proficiencyLevel.WorldClass:
                instrumentLevel = 5;
                break;
        }
        */
    }
}
