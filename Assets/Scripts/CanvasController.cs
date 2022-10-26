using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class CanvasController : MonoBehaviour
{
    public TMP_Text DriftScoreText;
    public TMP_Text DriftTotalText;
    int DriftScore;
    public int Driftscorescale = 15;
    int TotalScore;
    int driftMultipler;
    public int driftmultiplerate = 200;

    bool scoreadd;


    [SerializeField] GameObject DynamicJoystick;
    [SerializeField] GameObject Arrows;
    [SerializeField] GameObject Car;

    bool arrows = true;



    public int randomizer() 
    {
        return Random.Range(10, 20);
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("arrow")==0)
        {
            arrows = true;
            DynamicJoystick.SetActive(false);
            Arrows.SetActive(true);
            Car.GetComponent<CarController>().joystick = false;
        }
        else 
        {
            arrows = false;
            DynamicJoystick.SetActive(true);
            Arrows.SetActive(false);
            Car.GetComponent<CarController>().joystick = true;
        }
    }

    public void SwitchArrows() 
    {
        if (PlayerPrefs.GetInt("arrow") == 1) 
        {
            PlayerPrefs.SetInt("arrow", 0);
            arrows = true;
            DynamicJoystick.SetActive(false);
            Arrows.SetActive(true);
            Car.GetComponent<CarController>().joystick = false;
        }
        else 
        {
            PlayerPrefs.SetInt("arrow", 1);

            arrows = false;
            DynamicJoystick.SetActive(true);
            Arrows.SetActive(false);
            Car.GetComponent<CarController>().joystick = true;
        }
        
    }


 


    void DriftingScore() 
    {
        if(PlayerPrefs.GetInt("drift") == 1) 
        {
            scoreadd = true;
            
            DriftScoreText.gameObject.SetActive(true);

            driftMultipler = (DriftScore / driftmultiplerate)+1;

            DriftScore = DriftScore + (Driftscorescale*driftMultipler);
            DriftScoreText.text = "" + DriftScore;
            
        }
        else 
        {
            TotalScore = TotalScore + DriftScore;
            if (scoreadd)
            {
                PlayerPrefs.SetInt("allscore", PlayerPrefs.GetInt("allscore") + DriftScore);
                Debug.Log("totalscore -> " + TotalScore);
                Debug.Log("totalscore pref -> " + PlayerPrefs.GetInt("totalscore"));
                Debug.Log("Allscore pref -> " + PlayerPrefs.GetInt("allscore"));
            }
            DriftScore = 0;
            driftMultipler = 0;
            DriftTotalText.text = "" + TotalScore;
            PlayerPrefs.SetInt("totalscore", TotalScore);
            DriftScoreText.gameObject.SetActive(false);
            scoreadd = false;
            
        }
       


    }

    

    
    
    
    void FixedUpdate()
    {
        DriftingScore();
    }
}
