using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using UnityEngine.EventSystems;




public class CarController : MonoBehaviour
{


    public enum Axel
    {
        Front,
        Rear
    }


    [Serializable]
    public struct Wheel
    {
        public GameObject model;
        public WheelCollider collider;
        public Axel axel;
    }



    [SerializeField]
    private float maxAcceleration = 50f;

    [SerializeField]
    private float turnSensitivity = 0.70f;

    [SerializeField]
    private float maxSteerAngle = 45.0f;
    [SerializeField]
    private Vector3 _centerOfMass;
    [SerializeField]
    public List<Wheel> wheels;

    private float inputX, inputY;
    public float DriftValue;
    public float Nitro;
    [SerializeField] GameObject nitro;
    [SerializeField] Image nitroimg;
    public float nitroconsume = 1f;
    private Rigidbody _rb;
    float timer = 3;
    [SerializeField] bool grounded = false;
    public float groundheight;
    public float raystartY;
    public int MoneyGainFromCoin = 5;

    public float nitroimgheight;
    [SerializeField] FixedJoystick goandback;
    public GameObject Nitroholder;
    [SerializeField] FixedJoystick leftright;


     bool pc =false;
     public bool joystick = false;
       [SerializeField] DynamicJoystick vertical;
      [SerializeField] DynamicJoystick horizontal;

    [SerializeField] GameObject Cars;
    public GameObject WheelColliderRoot;
    public GameObject WheelsMeshRoot;


   


    private void Start()
    {
        PlayerPrefs.SetInt("nitro", 2);
        PlayerPrefs.SetInt("drift", 0);
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = Vector3.zero;
        _rb.centerOfMass = _centerOfMass;
        PlayerPrefs.SetInt("nitro", 2);
        WheelSelecter();


    }




    void WheelSelecter() 
    {

        GameObject SelectedCar = Cars.transform.GetChild(PlayerPrefs.GetInt("skin")).transform.gameObject;
        GameObject WheelsRoot = SelectedCar.transform.GetChild(1).transform.gameObject;

         WheelColliderRoot = WheelsRoot.transform.GetChild(1).transform.gameObject;
         WheelsMeshRoot = WheelsRoot.transform.GetChild(0).transform.gameObject;

        
        
    }



    public void SelectArrowLeft() 
    {
        inputX = -1;
        Debug.Log("left");
    }
    public void SelectArrowRight()
    {
        Debug.Log("right");
        inputX = +1;
    }
    public void SelectArrowCancel()
    {
        Debug.Log("left cancel");
        inputX = 0;
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F)) 
        {
            finishgame();
        }



        nitroplace();
        //SelectArrow();


        AnimateWheels();
            GetInputs();
        if (Input.GetKey(KeyCode.LeftShift))
            PlayerPrefs.SetInt("nitro", 1);
        if (Input.GetKeyUp(KeyCode.LeftShift))
            PlayerPrefs.SetInt("nitro", 2);
        Debug.DrawRay(transform.position, _rb.velocity.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3, Color.blue);

        GroundCheck();




        if (Input.GetKeyDown(KeyCode.T)) 
        {
            WheelSelecter();
        }

    }

    IEnumerator GroundRestart() 
    {

        yield return new WaitForSeconds(1.5f);

        if (!grounded) 
        {
            this.gameObject.GetComponent<GameOverScript>().enabled = true;
            //this.gameObject.GetComponent<CarController>().enabled = false;
               
        }
            
    }




    void GroundCheck() 
    {
        RaycastHit hit;
        var pos = transform.GetChild(0).transform.position;
        pos.y +=1;
        

        Ray ray = new Ray(pos, Vector3.down*5);
        Debug.DrawRay(pos, Vector3.down * 5, Color.black);

       // Debug.Log("gro hit " + hit.collider.tag);

       if(Physics.Raycast(ray,out hit)) 
        {
           
            if (hit.collider.tag == "Road")
            {
                grounded = true;

                
            }
            else 
            {
                grounded = false;
                StartCoroutine(GroundRestart());
            }
        }
        else 
        {
            grounded = false;
            StartCoroutine(GroundRestart());
        }
        
    }


    void DriftAngle() 
    {
        timer = timer - Time.deltaTime;
        Vector3 Godir = transform.forward.normalized;
        Vector3 driftdir = _rb.velocity.normalized;
        DriftValue = Vector3.Angle(Godir, driftdir);
        //Debug.Log("timer -> " + timer + " drift mi = " + PlayerPrefs.GetInt("drift"));
        if (DriftValue > 18 && timer<0 && grounded && _rb.velocity.magnitude>3) 
        {
            PlayerPrefs.SetInt("drift", 1);
        }
        else 
        {
            PlayerPrefs.SetInt("drift", 0);
        }
    }



    public void UseNitro() 
    {
        if (nitroimg.fillAmount > 0)
        {
            nitroimg.fillAmount = nitroimg.fillAmount - nitroconsume / 100;
            _rb.AddForce(transform.forward.normalized * Nitro, ForceMode.Force);
            nitro.gameObject.SetActive(true);
        }
        else
        {
            nitro.gameObject.SetActive(false);

        }
    }

    void nitroplace() 
    {
        GameObject nb = GameObject.Find("NB");
        if (Nitroholder.activeInHierarchy == true && inputY > 0.5f && Input.mousePosition.y > 500) 
        {
            PlayerPrefs.SetInt("nitro", 1);
        }
        else 
        {
            PlayerPrefs.SetInt("nitro", 2);
        }
        
    }


    public void NitroOn() 
    {
        PlayerPrefs.SetInt("nitro", 1);
    }
    public void NitroOff()
    {
        PlayerPrefs.SetInt("nitro",2);
    }


    private void FixedUpdate()
    {

        

        
        
        if(PlayerPrefs.GetInt("nitro") == 1)
            UseNitro();
        if (PlayerPrefs.GetInt("nitro") == 2)
            nitro.gameObject.SetActive(false);


        DriftAngle();
        Move();
        Turn();
    }

   

    private void GetInputs()
    {

        /*inputY = goandback.Vertical;
        inputX = leftright.Horizontal;*/
        if (pc) 
        {
            inputX = Input.GetAxis("Horizontal");
            inputY = Input.GetAxis("Vertical");
        }
        else 
        {
            inputY = goandback.Vertical;
            if (joystick)
                inputX = horizontal.Horizontal;
        }

        /*inputX = horizontal.Horizontal;
        inputY = vertical.Vertical;*/
    }

    private void Move()
    {

        for (int i = 0; i < 4; i++)
        {
            WheelColliderRoot.transform.GetChild(i).transform.gameObject.GetComponent<WheelCollider>().motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
        }

        /*foreach (var wheel in wheels)
        {
            wheel.collider.motorTorque = inputY * maxAcceleration * 500 * Time.deltaTime;
            
        }*/
    }

    private void Turn()
    {
        for (int i = 0; i < 2; i++)
        {
            var _steerAngle = inputX * turnSensitivity * maxSteerAngle;
            WheelColliderRoot.transform.GetChild(i).transform.gameObject.GetComponent<WheelCollider>().steerAngle = Mathf.Lerp(WheelColliderRoot.transform.GetChild(i).transform.gameObject.GetComponent<WheelCollider>().steerAngle, _steerAngle, 0.5f);
        }

        /*foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                var _steerAngle = inputX * turnSensitivity * maxSteerAngle;
                wheel.collider.steerAngle = Mathf.Lerp(wheel.collider.steerAngle, _steerAngle, 0.5f);
            }
        }*/
    }

    private void AnimateWheels()
    {
        for (int i = 0; i < 4; i++)
        {
            Quaternion _rot;
            Vector3 _pos;
            WheelColliderRoot.transform.GetChild(i).transform.gameObject.GetComponent<WheelCollider>().GetWorldPose(out _pos, out _rot);
            WheelsMeshRoot.transform.GetChild(i).transform.rotation = _rot;
            WheelsMeshRoot.transform.GetChild(i).transform.position = _pos;

        }
        /*
        foreach (var wheel in wheels)
        {
            Quaternion _rot;
            Vector3 _pos;
            wheel.collider.GetWorldPose(out _pos, out _rot);
            wheel.model.transform.position = _pos;
            wheel.model.transform.rotation = _rot;
        }*/
    }

    void finishgame() 
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        if(PlayerPrefs.GetInt("level")<20)
            SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
        else 
        {
            int i = GameObject.Find("GamePlay Canvas").GetComponent<CanvasController>().randomizer();


            PlayerPrefs.SetInt("randomlevel", i);
            SceneManager.LoadScene(i);
        }
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Finish") 
        {

            GameObject.Find("Main Camera").GetComponent<CameraController>().enabled = false;
            PlayerPrefs.SetInt("drift", 0);

            Invoke("finishgame", 1.5f);
        }
        if (other.gameObject.tag == "coin")
        {
            PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + MoneyGainFromCoin);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.tag == "road") 
        {
            grounded = true;
            Debug.Log("sa");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "road")
        {
            grounded = false;
            Debug.Log("as");
        }
    }


}