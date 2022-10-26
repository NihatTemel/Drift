
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverScript : MonoBehaviour
{

    [SerializeField] GameObject gameoverpanel;
    [SerializeField] GameObject Gameplaycanvas;
    [SerializeField] GameObject joystickcanvas;


    Color mycolor;

    public float i = 0;
    public float speed = 0.01f;


    void Start()
    {
        gameoverpanel.SetActive(true);
      //  Gameplaycanvas.SetActive(false);
        joystickcanvas.SetActive(false);
        mycolor = gameoverpanel.GetComponent<Image>().color;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        i = i + speed;
        gameoverpanel.GetComponent<Image>().color = new Color(mycolor.r , mycolor.g , mycolor.b , i);

        if (i > 0.99f) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            this.gameObject.GetComponent<GameOverScript>().enabled = false;
        }

    }
}
