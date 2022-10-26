using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcamera : MonoBehaviour
{
    public Transform car;
    public float smoothing;
    public float rotsmoothing;
    Vector3 startrotation;


    private void Start()
    {
        startrotation = transform.eulerAngles;
    }


    void FixedUpdate()
    {

        transform.position = Vector3.Lerp(transform.position, car.transform.position, smoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, car.rotation, rotsmoothing);
        //  transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0
        transform.rotation = Quaternion.Euler(startrotation);
    }
}
