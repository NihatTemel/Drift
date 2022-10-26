
using UnityEngine;
using TMPro;

public class CoinBuyScp : MonoBehaviour
{
    [SerializeField] TMP_Text totalDP;
    [SerializeField] TMP_Text TotalCoin;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        totalDP.text = "" + PlayerPrefs.GetInt("allscore");
        TotalCoin.text = "" + PlayerPrefs.GetInt("money");
    }

    public void Buycoin() 
    {
        Debug.Log("sa");
        if (PlayerPrefs.GetInt("allscore") > 25000) 
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money")+100);
            PlayerPrefs.SetInt("allscore", PlayerPrefs.GetInt("allscore")-25000);
        }
        totalDP.text = "" + PlayerPrefs.GetInt("allscore");
        TotalCoin.text = "" + PlayerPrefs.GetInt("money");
    }

}
