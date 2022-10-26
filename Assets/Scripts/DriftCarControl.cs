using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftCarControl : MonoBehaviour
{

    public float movespeed;
    public float maxspeed = 15;
    public float drag = 0.97f;
    public float steerAngle = 20;
    public float Traction = 1;

    private Vector3 MoveForce;



    // Update is called once per frame
    void Update()
    {

        MoveForce += transform.forward * movespeed * Input.GetAxis("Vertical") * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        // steering

        float steerInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * steerInput * MoveForce.magnitude * steerAngle * Time.deltaTime);

        // drag and max speed limit
        MoveForce *= drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, maxspeed);

        //traxtion
        Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward*3, Color.blue);
        MoveForce = Vector3.Lerp(MoveForce.normalized, transform.forward, Traction * Time.deltaTime) * MoveForce.magnitude;



    }
}
