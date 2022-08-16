using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGravityAttract : MonoBehaviour
{
    private float _distanceToGround;
    private Vector3 _groundNormal;
    private bool _onGround = false;

    private Rigidbody _rb;

    public float gravity = 100;

    public GameObject planet;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    void Update()
    {

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
    }
}