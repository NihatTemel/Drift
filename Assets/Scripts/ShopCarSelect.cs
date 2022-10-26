using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCarSelect : MonoBehaviour
{
    public void SelectCar()
    {
        int childs =this.gameObject.transform.parent.transform.childCount;
        Debug.Log("chkd " + childs);
        Debug.Log("name - > " + this.gameObject.name);
        for(int i = 0; i < childs; i++) 
        {
            if(this.gameObject== this.gameObject.transform.parent.transform.GetChild(i).gameObject) 
            {
                Debug.Log("this ! " + i);
                PlayerPrefs.SetInt("skin", i);
            }
        }
        


    }
}
