using System;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _distanceToGround;
    private Vector3 _groundNormal, _movement;

    private Rigidbody _rb;
    private float z;

    public float speed = 4;
    public float turnAngle = 70f;
    
    public Transform frontWheel1;
    public Transform frontWheel2;
    public Transform backWheel1;
    public Transform backWheel2;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        if (Input.GetButton("Vertical")) 
        {
            //FORWARD MOVEMENT
            z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

            //WHEELS
            frontWheel1.Rotate(120f * Time.deltaTime, 0, 0);
            frontWheel2.Rotate(120f * Time.deltaTime, 0, 0);
            backWheel1.Rotate(120f * Time.deltaTime, 0, 0);
            backWheel2.Rotate(120f * Time.deltaTime, 0, 0);
            
            transform.Translate(0, 0, z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //TURNING

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnAngle * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -turnAngle * Time.deltaTime, 0);
        }
        
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.yellow);
            _groundNormal = hit.normal;
        }

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, _groundNormal) * transform.rotation;
        transform.rotation = toRotation;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("PlanetObj"))
        {
            Debug.Log("Collision!");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Letter"))
        {
            GameObject o = other.gameObject;
            o.GetComponent<Rigidbody>().isKinematic = true;
            o.SetActive(false);
            Debug.Log("YOU GOT THE LETTER " + o.name);
        }
    }
}