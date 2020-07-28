using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class LetterSpawner : MonoBehaviour
{

    private Vector3 _groundNormal;
    public GameObject prefab;
    private bool _complete = false;
    string[] _letters = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
    private string[] _colors = {"Cyan", "Green", "Purple", "Red", "Yellow"};

    [Header("Block Faces")]
    public GameObject face01;
    public GameObject face02;
    public GameObject face03;
    public GameObject face04;
    public GameObject face05;
    public GameObject face06;

    public GameObject outerFace;
    
    
    private void Awake()
    {
        if (!_complete)
        {
            InstantiateLetters();
        }
    }
    
    private void LoadCharacter(string meshL) {
        string randCol = _colors[Random.Range (0, _colors.Length)];
        
        Mesh meshLetter = Resources.Load("Letters/LetterMesh/"+ meshL) as Mesh;
        Material matColor = Resources.Load("Letters/Color/"+ randCol) as Material;

        outerFace.GetComponent<MeshRenderer>().material = matColor;
        
        face01.GetComponent<MeshFilter>().mesh = meshLetter;
        face01.GetComponent<MeshRenderer>().material = matColor;
        
        face02.GetComponent<MeshFilter>().mesh = meshLetter;
        face02.GetComponent<MeshRenderer>().material = matColor;
        
        face03.GetComponent<MeshFilter>().mesh = meshLetter;
        face03.GetComponent<MeshRenderer>().material = matColor;
        
        face04.GetComponent<MeshFilter>().mesh = meshLetter;
        face04.GetComponent<MeshRenderer>().material = matColor;
        
        face05.GetComponent<MeshFilter>().mesh = meshLetter;
        face05.GetComponent<MeshRenderer>().material = matColor;
        
        face06.GetComponent<MeshFilter>().mesh = meshLetter;
        face06.GetComponent<MeshRenderer>().material = matColor;
        
    }

    void InstantiateLetters()
    {
        foreach (string s in _letters) {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(transform.position, -transform.up, out hit, 10))
            {
                Debug.DrawRay(transform.position, -transform.up * hit.distance, Color.blue);

                _groundNormal = hit.normal;
            }
            
            Vector3 normal = (Random.onUnitSphere * 10.2f - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(normal);

            prefab.name = s;
            prefab.SetActive(true);
            LoadCharacter(s);
            
            Quaternion toRotation = Quaternion.FromToRotation(transform.up, _groundNormal) * transform.rotation;
            // prefab.transform.rotation = toRotation;
            
            Instantiate(prefab, Random.onUnitSphere * 10.2f, rotation);
        }

        _complete = true;
    }
}



