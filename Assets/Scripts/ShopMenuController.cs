using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class ShopMenuController : MonoBehaviour
{
    [SerializeField] GameObject bodyiesRoot;
    [SerializeField] GameObject CarImagesRoot;
    [SerializeField] TMP_Text MoneyText;

    int totalcar;
    int index;

    void Start()
    {
        totalcar = bodyiesRoot.transform.childCount;
        index = PlayerPrefs.GetInt("skin");
        Debug.Log("index start" + index);
        bodyiesRoot.transform.GetChild(PlayerPrefs.GetInt("skin")).gameObject.SetActive(true);
        CarImagesRoot.transform.GetChild(PlayerPrefs.GetInt("skin")).gameObject.SetActive(true);
        
    }




    public void LeftArrowShop() 
    {
        if (index > 0) 
        {
            CloseFirstOpenSecond(bodyiesRoot.transform.GetChild(index).gameObject, bodyiesRoot.transform.GetChild(index - 1).gameObject);
            CloseFirstOpenSecond(CarImagesRoot.transform.GetChild(index).gameObject, CarImagesRoot.transform.GetChild(index - 1).gameObject);
            index--;
        }
    }
    public void RightArrowShop()
    {
        if (index+1 < totalcar)
        {
            CloseFirstOpenSecond(bodyiesRoot.transform.GetChild(index).gameObject, bodyiesRoot.transform.GetChild(index + 1).gameObject);
            CloseFirstOpenSecond(CarImagesRoot.transform.GetChild(index).gameObject, CarImagesRoot.transform.GetChild(index + 1).gameObject);
            index++;
        }
    }

    void CloseFirstOpenSecond(GameObject first,GameObject second) 
    {
        first.SetActive(false);
        second.SetActive(true);
    }

    public void PlayScene() 
    {
        if(PlayerPrefs.GetInt("level")<20)
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        else
            SceneManager.LoadScene(PlayerPrefs.GetInt("randomlevel"));
    }


    private void Update()
    {
        MoneyText.text = "" + PlayerPrefs.GetInt("money");

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            PlayerPrefs.SetInt("money", 1000);
        }


    }
}
