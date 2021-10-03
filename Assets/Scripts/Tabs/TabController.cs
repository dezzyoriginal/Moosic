using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{
    [SerializeField] private GameObject[] _tabs;

    public  int selectedTab = 0;

    public void OnClick(int tabNumber)
    {
        selectedTab = tabNumber;
        //Debug.Log(tabNumber + " selected");
    }

    private void Update()
    {
        _tabs[selectedTab].SetActive(true);

        for (int i = 0; i < _tabs.Length; i++)
        {
            if (i != selectedTab)
            {
                _tabs[i].SetActive(false);
            }
        }
    }
}
