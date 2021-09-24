using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    [SerializeField] float maxVolume, lerpSpeed;
    [Space]
    [SerializeField] private StorageController storageController;
    [SerializeField] AudioSource[] bgms;


    private void Awake()
    {
        for (int i = 0; i < storageController.storedItems.Length; i++)
        {
            bgms[i].volume = 0;
        }
    }

    void Update()
    {
        if (Time.timeScale == 0)
        {
            foreach (AudioSource bgm in bgms)
            {
                //bgm.volume
            }
        }
        else
        {
            foreach (AudioSource bgm in bgms)
            {
                //bgm.UnPause();
            }
        }

        for (int i = 0; i < storageController.storedItems.Length; i++)
        {
            //if (bgms[0].time == bgms[0].)
            if (storageController.storedItems[i].items.Count > 0)
            {
                bgms[i].volume = Mathf.Lerp(bgms[i].volume,maxVolume, lerpSpeed);
            }
            else
            {
                bgms[i].volume = Mathf.Lerp(bgms[i].volume, 0, lerpSpeed);
            }
        }
    }
}
