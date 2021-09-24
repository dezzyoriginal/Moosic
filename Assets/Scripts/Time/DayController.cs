using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayController : MonoBehaviour
{
    [SerializeField] GameObject day, night;
    [SerializeField] Sprite[] colors;
    [SerializeField] Image backlights;
    [SerializeField] float changeBackLightSpeed;
    //[SerializeField] TimeController timeController;
    public float timer = 0;
    void Update()
    {
        

        //if (TimeController.instance.timeCounter < (TimeController.instance.timeWithinDay * 0.25f) + 20 || TimeController.instance.timeCounter > (TimeController.instance.timeWithinDay * 0.90f))
        if (TimeController.instance.timeCounter > (TimeController.instance.timeWithinDay * 0.90f))
        {
            day.SetActive(false);

            night.SetActive(true);



            backlights.enabled = true;

            timer += Time.deltaTime;
            if (timer > colors.Length-1) timer = 0;
            backlights.overrideSprite = colors[Mathf.RoundToInt(timer)];
            /*
            for (int i = 0; i < colors.Length; i++)
            {
                if ((TimeController.instance.timeCounter * changeBackLightSpeed) % colors.Length == i) backlights.overrideSprite = colors[i];
            }
            */
        }
        else
        {
            timer = 0;
            day.SetActive(true);

            night.SetActive(false);
            backlights.enabled = false;
        }

    }
}
