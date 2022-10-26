
using UnityEngine;

public class ShopSettings : MonoBehaviour
{

    [SerializeField] GameObject c1;
    [SerializeField] GameObject c2;
    [SerializeField] GameObject MainCam;


    private void OnEnable()
    {
        MainCam.SetActive(false);
        c1.SetActive(false);
        c2.SetActive(false);


    }

    public void BackToMenu() 
    {
        c1.SetActive(true);
        c2.SetActive(true);
        MainCam.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void SelectCar() 
    {
        /*int childs =this.gameObject.transform.parent.transform.childCount;
        for(int i = 0; i < childs; i++) 
        {
            if(this.gameObject== this.gameObject.transform.GetChild(i)) 
            {
                Debug.Log("this ! " + i);
                PlayerPrefs.SetInt("skin", i);
            }
        }*/
        Debug.Log("name-> " + this.gameObject.name);
        PlayerPrefs.SetInt("skin", 1);


    }


}
