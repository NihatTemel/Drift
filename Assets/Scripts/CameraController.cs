
using UnityEngine;

public class CameraController : MonoBehaviour
{

    GameObject car;
    
    Transform [] camlocations=new Transform[7];

    int count;


    public int locationindicator = 0;
    [Range(0, 1)] public float smoothTime = 0.5f;

    private void Start()
    {
        car = GameObject.FindGameObjectWithTag("car");
        count = GameObject.Find("Camlocations").transform.childCount;
        Debug.Log(count);
        for (int i = 0;i< count; i++) 
        {
            camlocations[i] = GameObject.Find("Camlocations").transform.GetChild(i);
        }
    }



    public void CamposChange() 
    {
        if (locationindicator >= camlocations.Length - 1)
            locationindicator = 0;
        else
            locationindicator++;

    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (locationindicator >= camlocations.Length-1 )
                locationindicator = 0;
            else
                locationindicator++;
        }

       
        transform.position = camlocations[locationindicator].position * (1 - smoothTime) + transform.position * smoothTime;
        transform.LookAt(car.transform);


    }



}
