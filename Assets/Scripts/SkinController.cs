using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinController : MonoBehaviour
{
    public GameObject DriftCars;
    public GameObject DriftCarBodies;


    private void Start()
    {
        PlayerPrefs.SetInt("nitro", 2);
        skinchange();
    }

    public void skinchange() 
    {
        Debug.Log("skinchange - > " + PlayerPrefs.GetInt("skin"));
        int skin = PlayerPrefs.GetInt("skin");
        if (skin < 6) 
        {
            DriftCars.SetActive(true);
           int children = DriftCarBodies.transform.childCount;
            for (int i = 0; i < children; ++i)
                DriftCarBodies.transform.GetChild(i).gameObject.SetActive(false);
            DriftCarBodies.transform.GetChild(skin).gameObject.SetActive(true);
        }
        else 
        {
            DriftCars.SetActive(false);
        }
    }



}
