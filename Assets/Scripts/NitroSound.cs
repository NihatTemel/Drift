using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitroSound : MonoBehaviour
{
    
    [SerializeField] AudioSource SlipSource;
    [SerializeField] Image nitroimg;
   

    // Update is called once per frame
    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("nitro")==1 && nitroimg.fillAmount>0)
        {

            if (!SlipSource.isPlaying)
                SlipSource.Play();


        }
        else
        {
            SlipSource.Stop();
        }
    }
}
