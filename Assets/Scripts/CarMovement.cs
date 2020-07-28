using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class CarMovement : MonoBehaviour
{
    private float _distanceToGround;
    private Vector3 _groundNormal;

    private Rigidbody _rb;
    private float _z;
    
    
    
    
    
    public Transform carModel;
    public Transform carNormal;
    public Rigidbody sphere;
    float speed, currentSpeed;
    float rotate, currentRotate;
    public float acceleration = 30f;
    public float steering = 80f;
    public float gravity = 10f;
    
    [Header("Model Parts")]

    public Transform frontWheels;
    public Transform backWheels;
    
    
    
    

    public float iSpeed = 4;
    public float turnAngle = 70f;

    void Start()
    {
        // _rb = GetComponent<Rigidbody>();
        // _rb.freezeRotation = true;
    }

    // Update is called once per frame

    private void Update()
    {
        //Follow Collider
        transform.position = sphere.transform.position - new Vector3(0, 0.4f, 0);

        //Accelerate
        if (Input.GetButton("Vertical"))
            speed = acceleration;
        
        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 12f); speed = 0f;
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f); rotate = 0f;

        //b) Wheels
        frontWheels.localEulerAngles = new Vector3(0, (Input.GetAxis("Horizontal") * 15), frontWheels.localEulerAngles.z);
        frontWheels.localEulerAngles += new Vector3(0, 0, sphere.velocity.magnitude/2);
        backWheels.localEulerAngles += new Vector3(0, 0, sphere.velocity.magnitude/2);
    }

    void FixedUpdate()
    {
        sphere.AddForce(-carModel.transform.right * currentSpeed, ForceMode.Acceleration);
        
        // //Gravity
        // sphere.AddForce(Vector3.down * gravity, ForceMode.Acceleration);
        
        //Steering
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime * 5f);
        
        RaycastHit hitOn;
        RaycastHit hitNear;

        Physics.Raycast(transform.position + (transform.up*.1f), Vector3.down, out hitOn, 1.1f);
        Physics.Raycast(transform.position + (transform.up * .1f)   , Vector3.down, out hitNear, 2.0f);

        //Normal Rotation
        carNormal.up = Vector3.Lerp(carNormal.up, hitNear.normal, Time.deltaTime * 8.0f);
        carNormal.Rotate(0, transform.eulerAngles.y, 0);
        
        
        //
        // //TURNING
        // if (Input.GetKey(KeyCode.D))
        // {
        //     transform.Rotate(0, turnAngle * Time.deltaTime, 0);
        // }
        //
        // if (Input.GetKey(KeyCode.A))
        // {
        //     transform.Rotate(0, -turnAngle * Time.deltaTime, 0);
        // }
        //
        // RaycastHit hit = new RaycastHit();
        // if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        // {
        //     _groundNormal = hit.normal;
        // }
        //
        // Quaternion toRotation = Quaternion.FromToRotation(transform.up, _groundNormal) * transform.rotation;
        // transform.rotation = toRotation;
    }
    
    public void Steer(int direction, float amount)
    {
        rotate = (steering * direction) * amount;
    }
    
    private void Speed(float x)
    {
        currentSpeed = x;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("PlanetObj"))
        {
            Debug.Log("Collision!");
            // _rb.isKinematic = true;
        }
        
        if (other.collider.CompareTag("Letter"))
        {
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.SetActive(false);
            Debug.Log("YOU GOT THE LETTER " + other.gameObject.GetComponent<TextMeshPro>().text);
        }
        
        
        
        
    }
}