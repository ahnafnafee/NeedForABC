using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterSpawner : MonoBehaviour
{

    private Vector3 _groundNormal;
    public SphereCollider sphereCol;
    public int numObjects = 10;
    public GameObject prefab;
  
    void Start() {
        var r = sphereCol.radius;
        Vector3 center = transform.position;

        

        for (int i = 0; i < numObjects; i++){
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
            {
                _groundNormal = hit.normal;
            }
            
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, _groundNormal) * transform.rotation;
            
            Instantiate(prefab, Random.onUnitSphere * 11f, toRotation);
        }
    }
}



