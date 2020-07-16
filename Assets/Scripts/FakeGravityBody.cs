using UnityEngine;
using System.Collections;
 
[RequireComponent (typeof (Rigidbody))]
public class FakeGravityBody : MonoBehaviour {
 
    FakeGravity planet;
 
    void Awake () {
        planet = GameObject.FindGameObjectWithTag("Planet").GetComponent<FakeGravity>();
 
        // Disable rigidbody gravity and rotation as this is simulated in GravityAttractor script
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
    }
       
    void FixedUpdate () {
        // Allow this body to be influenced by planet's gravity
        planet.Attract(transform);
    }
}