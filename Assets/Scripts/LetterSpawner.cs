using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LetterSpawner : MonoBehaviour
{

    private Vector3 _groundNormal;
    public Transform sphereTransform;
    public int numObjects = 26;
    public GameObject prefab;
    private int _asciiNum = 65;
    private bool _complete = false;
  
    void Start() {
        Vector3 center = transform.position;

        

        for (int i = 0; i < numObjects; i++){
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
            {
                _groundNormal = hit.normal;
            }
            
            Vector3 normal = (Random.onUnitSphere * 10.2f - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(normal);

            prefab.GetComponent<TextMeshPro>().text = Convert.ToChar(_asciiNum++).ToString();
            
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, _groundNormal) * transform.rotation;
            // prefab.transform.LookAt(Camera.main.transform);
            Instantiate(prefab, Random.onUnitSphere * 10.2f, rotation);
        }
    }

    private void Awake()
    {
        if (!_complete)
        {
            InstantiateLetters();
        }
    }

    void InstantiateLetters()
    {
        for (int i = 0; i < numObjects; i++){
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
            {
                _groundNormal = hit.normal;
            }
            
            Vector3 normal = (Random.onUnitSphere * 10.2f - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(normal);

            String letter = Convert.ToChar(_asciiNum).ToString();
            
            //TODO: Doesn't instantiate all letters
            
            Debug.Log(letter);
            prefab.name = letter;
            prefab.GetComponent<TextMeshPro>().text = letter;

            _asciiNum++;
            
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, _groundNormal) * transform.rotation;
            // prefab.transform.LookAt(Camera.main.transform);
            Instantiate(prefab, Random.onUnitSphere * 10.2f, rotation);
        }

        _complete = true;
    }
}



