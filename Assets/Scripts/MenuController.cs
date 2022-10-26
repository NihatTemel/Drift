using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuController : MonoBehaviour
{


    [SerializeField] TMP_Text totalscore;
    [SerializeField] TMP_Text LevelText;
    [SerializeField] TMP_Text CoinText;
    public GameObject joystickcanvas;
    public GameObject camerastart;
    [SerializeField] GameObject Shoppanel;
    [SerializeField] GameObject CoinShopPanel;
    [SerializeField] GameObject GamePlayCanvas;



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            PlayerPrefs.DeleteAll();
    }


    public void restartgame() 
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }


    private void OnEnable()
    {
        PlayerPrefs.SetInt("drift", 0);
        int a = (SceneManager.GetActiveScene().buildIndex + 1);
        CoinText.text = "" + PlayerPrefs.GetInt("money");
        LevelText.text = "Level : " + (PlayerPrefs.GetInt("level")+1);
        totalscore.text = "" + PlayerPrefs.GetInt("allscore");
    }

    public void StartGame() 
    {
        camerastart.GetComponent<CameraController>().enabled = true;
        joystickcanvas.SetActive(true);
        GameObject.FindGameObjectWithTag("car").GetComponent<CarController>().enabled = true;
        this.gameObject.transform.GetChild(0).transform.gameObject.SetActive(false);
        GamePlayCanvas.SetActive(true);
    }


    public void OpenShopPanel() 
    {
        SceneManager.LoadScene("SHOP MENU");
        
    }
    public void coinshoppanel()
    {
        CoinShopPanel.SetActive(true);

    }

    


}
