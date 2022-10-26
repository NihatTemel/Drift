using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuySelectButton : MonoBehaviour
{
    [SerializeField] TMP_Text SelectBuyText;
    [SerializeField] int Price;
    int index;
    [SerializeField] GameObject CarRoot;
    void Start()
    {
        index = transform.parent.GetSiblingIndex();

        if (index == 0) 
        {
            PlayerPrefs.SetInt(this.gameObject.name, 1);
            this.GetComponent<Button>().interactable = true;
            SelectBuyText.text = "SELECT";
            Debug.Log("buy");
        }


        if (PlayerPrefs.GetInt(this.gameObject.name) == 0) 
        {
            SelectBuyText.text = "" + Price;
            if (PlayerPrefs.GetInt("money") <= Price) 
            {
                this.GetComponent<Button>().interactable = false;
            }
        }
        else 
        {
            SelectBuyText.text = "SELECT";
        }
    }

    

    public void BuySelect() 
    {
        if (PlayerPrefs.GetInt(this.gameObject.name) == 0 && PlayerPrefs.GetInt("money") >= Price)
        {
            PlayerPrefs.SetInt(this.gameObject.name,1);
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") - Price);
            this.GetComponent<Button>().interactable = true;
            SelectBuyText.text = "SELECT";
            Debug.Log("buy");
        }
        else 
        {
            SelectBuyText.text = "SELECTED";
            PlayerPrefs.SetInt("skin", index);
            
        }

    }

    private void FixedUpdate()
    {
        if (PlayerPrefs.GetInt("money") >= Price)
        {
            this.GetComponent<Button>().interactable = true;
        }
        if(PlayerPrefs.GetInt(this.gameObject.name) == 1) 
        {
            if (PlayerPrefs.GetInt("skin") == index) 
            {
                SelectBuyText.text = "SELECTED";
            }
            else 
            {
                SelectBuyText.text = "SELECT";
            }
        }

    }
}
