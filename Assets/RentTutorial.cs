using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RentTutorial : MonoBehaviour
{
    [SerializeField] GameObject Understood;
    TextMeshProUGUI displayTexts;
    [SerializeField] string[] texts;
    private int i;
    public GameObject changePage;

    private void Start()
    {
        Understood.SetActive(false);
        i = 0;
        displayTexts = GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (i < texts.Length) displayTexts.text = texts[i];
        //if (Input.anyKeyDown) i++;
        if (i > texts.Length || Input.GetKey(KeyCode.S)) i = texts.Length;
        if (i == texts.Length) Understood.SetActive(true);
    }

    public void Next()
    {
        if (i < texts.Length) i++;
    }

    public void Previous()
    {
        if (i > 0) i--;

    }
}
