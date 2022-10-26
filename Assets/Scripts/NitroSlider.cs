using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitroSlider : MonoBehaviour
{
    Image nitroimg;
    public float NitroResource=1f;
    private void Start()
    {
        nitroimg = GetComponent<Image>();
    }

    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("drift") == 1 && nitroimg.fillAmount<1)
        {
            nitroimg.fillAmount = nitroimg.fillAmount + NitroResource/100;
        }
    }
}
