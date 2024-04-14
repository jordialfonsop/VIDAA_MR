using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slicer : MonoBehaviour
{
    [SerializeField] private Material slicerMaterial;

    public Material GetSlicerMaterial() { return slicerMaterial; }


    // Start is called before the first frame update
    void Start()
    {
       //heart.GetComponent<Renderer>().material.SetFloat("_Offset", -156.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
