using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
    void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("drift") == 1) 
        {
            this.gameObject.GetComponent<TrailRenderer>().widthMultiplier = 0.2f;
        }
        else 
        {
            this.gameObject.GetComponent<TrailRenderer>().widthMultiplier = 0f;
        }
    }
}
