using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundScript : MonoBehaviour
{
    
    [SerializeField] AudioSource SlipSource;
        
    //float angle;                  check this later

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("drift") ==1) 
        {

            if(!SlipSource.isPlaying)
            SlipSource.Play();

            /*
            angle = this.gameObject.transform.parent.transform.parent.GetComponent<CarController>().DriftValue;

            Debug.Log("angle -> " + angle);

            SlipSource.volume = 0.75f +angle / 400;             check this later
            SlipSource.pitch = 0.75f + angle / 400;*/


            // volume - 0   to 1
            // pitch  -    0.75  to 1


        }
        else 
        {
            SlipSource.Stop();
        }
    }
}
