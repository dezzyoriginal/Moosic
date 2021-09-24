using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrendController : MonoBehaviour
{
    public static TrendController instance;

    public TopTrendingInstruments[] topTrendingInstruments;
    public float[] trendingValues;
    [HideInInspector] public float totalTrendingValue;
    //private float[] highestTrendingValue;

    private void Start()
    {
        instance = this;
        SelectNewTopTrendingInstruments();
    }

    void CalculateTotalValue()
    {
        totalTrendingValue = 0;
        foreach (float value in trendingValues)
        {
            totalTrendingValue += value;
        }
    }

    public void SelectNewTopTrendingInstruments()
    {
        for (int i = 0; i < trendingValues.Length; i++)
        {
            trendingValues[i] = Random.Range(15, 25);
        }

        topTrendingInstruments[0].trendingValue = 0;
        topTrendingInstruments[1].trendingValue = 0;
        for (int i = 0; i < trendingValues.Length; i++)
        {
            if (topTrendingInstruments[0].trendingValue < trendingValues[i])
            {
                topTrendingInstruments[0].trendingValue = trendingValues[i];
                topTrendingInstruments[0].InstrumentID = i;
            }
        }
        for (int i = 0; i < trendingValues.Length; i++)
        {
            if (topTrendingInstruments[1].trendingValue < trendingValues[i] && trendingValues[i] != topTrendingInstruments[0].trendingValue)
            {
                topTrendingInstruments[1].trendingValue = trendingValues[i];
                topTrendingInstruments[1].InstrumentID = i;
            }

        }
        CalculateTotalValue();
    }


}

[System.Serializable]
public class TopTrendingInstruments
{
    public int InstrumentID = 0;
    public float trendingValue = 0;
}