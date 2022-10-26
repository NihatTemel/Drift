using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScp : MonoBehaviour
{

    public float Rspeed=1;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, Rspeed);
    }
}
