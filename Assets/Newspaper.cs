using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Newspaper : MonoBehaviour
{
    public static Newspaper instance;

    [SerializeField] Sprite[] instruments;
    [SerializeField] ImageHolder[] ImageHolders;

    [SerializeField] TabTutorial tabTutorial;
    bool shouldDoTutorial = true;

    private void Start()
    {
        instance = this;
        //show
        shouldDoTutorial = true;
    }

    private void Update()
    {
        for (int i = 0; i < ImageHolders.Length; i++)
        {
            ImageHolders[i].sprite = instruments[TrendController.instance.topTrendingInstruments[i].InstrumentID];
            ImageHolders[i].image.overrideSprite = ImageHolders[i].sprite;

            ImageHolders[i].image.SetNativeSize();
            ImageHolders[i].image.transform.localScale = (Vector3.one * 180) / (i +1);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        if (shouldDoTutorial)
        {
            tabTutorial.Activate();
            shouldDoTutorial = false;
        }
        gameObject.SetActive(false);
    }

}



[System.Serializable]
public class ImageHolder
{
    public Image image;
    public Sprite sprite;
}
