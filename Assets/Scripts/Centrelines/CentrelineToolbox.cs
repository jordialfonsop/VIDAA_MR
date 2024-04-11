using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;


public class CentrelineToolbox : MonoBehaviour
{

    [SerializeField] private GameObject button;
    [SerializeField] private string path;
    // Start is called before the first frame update
    void Start()
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        FileInfo[] info = dir.GetFiles("*.*");
        foreach (FileInfo f in info)
        {
            string name = f.Name.Split(".txt")[0];
            Debug.Log(name);
            GameObject centrelineButton = Instantiate(button);
            centrelineButton.transform.parent = this.transform;
            centrelineButton.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = name;
            centrelineButton.transform.localPosition = new Vector3(0,0,0);
            centrelineButton.transform.rotation = new Quaternion(0,0,0,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
