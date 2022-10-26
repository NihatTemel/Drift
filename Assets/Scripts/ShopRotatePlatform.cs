using UnityEngine;

public class ShopRotatePlatform : MonoBehaviour
{
    [SerializeField] float RotateSpeed;
   
  

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, RotateSpeed);
    }
}
