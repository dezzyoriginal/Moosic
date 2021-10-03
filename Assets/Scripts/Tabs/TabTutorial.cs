using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TabTutorial : MonoBehaviour
{
    //[SerializeField] GameObject Understood;
    [SerializeField] TextMeshProUGUI displayArrows, displayTexts;
    [SerializeField] string[] arrows;
    [SerializeField] string[] texts;
    public int i;
    bool run = false;

    private void Start()
    {
        i = 0;
        run = false;
    }

    void Update()
    {
        if (run)
        {
            if (i < texts.Length)
            {
                displayTexts.text = texts[i];
                displayArrows.text = arrows[i];
            }
            if (Input.anyKeyDown) i++;
            if (i > texts.Length || Input.GetKey(KeyCode.S))
            {
                i = texts.Length;
            }
        }
    }

    public void Activate()
    {
        i = 0;
        run = true;
        i = 0;
    }
}
