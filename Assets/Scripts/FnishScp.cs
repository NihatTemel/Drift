
using UnityEngine;
using UnityEngine.SceneManagement;

public class FnishScp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "car")
        {
            other.gameObject.GetComponent<CarController>().enabled = false;
            PlayerPrefs.SetInt("drift", 0);
            Invoke("finishgame", 1.5f);
        }
    }
    void finishgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
