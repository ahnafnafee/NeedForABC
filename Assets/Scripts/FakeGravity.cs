using UnityEngine;

public class FakeGravity : MonoBehaviour {
    
    private float gravity = -10;

    private string _worldObjectTag = "World";
    private float _objRotSpeed = 50;
    private float _gravityBoost = 0;


    private void Awake()
    {
        gameObject.tag = _worldObjectTag;
    }
    
    public void Attract(Transform objBody)
    {
        Vector3 gravityDir = (objBody.position - transform.position).normalized;
        Vector3 bodyUp = objBody.up;
        objBody.GetComponent<Rigidbody>().AddForce(gravityDir * (gravity + _gravityBoost));
        
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityDir) * objBody.rotation;
        objBody.rotation = Quaternion.Slerp(objBody.rotation, targetRotation, _objRotSpeed * Time.deltaTime);
    }
}
