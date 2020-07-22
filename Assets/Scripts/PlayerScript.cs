using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float _distanceToGround;
    private Vector3 _groundNormal;
    private bool _onGround = false;

    private Rigidbody _rb;

    public float gravity = 100;

    public GameObject planet;

    public float speed = 4;
    public float turnAngle = 70f;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        //FORWARD MOVEMENT

        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(0, 0, z);

        //TURNING

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, turnAngle * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -turnAngle * Time.deltaTime, 0);
        }

        //GroundControl

        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
        {
            _distanceToGround = hit.distance;
            _groundNormal = hit.normal;

            if (_distanceToGround <= 0.05f)
            {
                _onGround = true;
            }
            else
            {
                _onGround = false;
            }
        }


        //GRAVITY and ROTATION

        Vector3 gravDirection = (transform.position - planet.transform.position).normalized;

        if (_onGround == false)
        {
            _rb.AddForce(gravDirection * -gravity);
        }

        //

        Quaternion toRotation = Quaternion.FromToRotation(transform.up, _groundNormal) * transform.rotation;
        transform.rotation = toRotation;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("PlanetObj"))
        {
            _rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            _rb.isKinematic = true;
            Debug.Log("Collision!");
        }
        else
        {
            _rb.isKinematic = false;
        }
    }
}