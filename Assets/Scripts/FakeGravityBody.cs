using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FakeGravityBody : MonoBehaviour {
    
    private FakeGravity _attractor;
    private bool setSolid = false;
    
    private Transform _objTransform;
    private Rigidbody _objRigidbody;
    
	private void Start () {
        _objRigidbody = GetComponent<Rigidbody>();
        _objRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        _objRigidbody.useGravity = false;
        _objTransform = transform;
        
        if (_attractor == null)
        {
            _attractor = GameObject.FindGameObjectWithTag("World").GetComponent<FakeGravity>();
        }
	}
	
	private void Update () {
        if (_objRigidbody.isKinematic)
        {
            return;
        }
        
        if (setSolid)
        {
            ObjectResting();
        }
        if (_attractor != null)
        {
            _attractor.Attract(_objTransform);
        }
	}

    private void ObjectResting()
    {
        if(gameObject.GetComponent<Rigidbody>().IsSleeping())
        {
            _objRigidbody.isKinematic = true;
        }
    }
}
