using UnityEngine;

public class FakeGravity : MonoBehaviour {

    // inspector variables
    [SerializeField, Tooltip("Amount of gravity to be applied to objects")]
    private float gravity = -10;
    [SerializeField, Tooltip("Planet Radius")]

    // privates
    private string _worldObjectTag = "World";
    private float _objRotSpeed = 50;
    private float _gravityBoost = 0;


    private void Awake()
    {
        gameObject.tag = _worldObjectTag;
    }
    
    public void Attract(Transform objBody)
    {
        // set planet gravity direction for the object body
        Vector3 gravityDir = (objBody.position - transform.position).normalized;
        Vector3 bodyUp = objBody.up;
        // apply gravity to objects rigidbody
        objBody.GetComponent<Rigidbody>().AddForce(gravityDir * (gravity + _gravityBoost));
        // update the objects rotation in relation to the planet
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityDir) * objBody.rotation;
        // smooth rotation
        objBody.rotation = Quaternion.Slerp(objBody.rotation, targetRotation, _objRotSpeed * Time.deltaTime);
    }
}
