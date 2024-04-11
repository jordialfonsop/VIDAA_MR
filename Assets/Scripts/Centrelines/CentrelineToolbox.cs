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
        int row = 0;
        int column = 0;

        for(int i = 0; i < CentrelineManager.Instance.centrelinesList.Count; i++)
        {
            GameObject centrelineButton = Instantiate(button);
            centrelineButton.name = CentrelineManager.Instance.centrelinesList[i].name.Split("Render")[0] + "Button";
            centrelineButton.GetComponent<CentrelineButton>().SetCentrelineRender(CentrelineManager.Instance.centrelinesList[i]);
            centrelineButton.transform.parent = this.transform;
            centrelineButton.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = CentrelineManager.Instance.centrelinesList[i].name.Split("Render")[0];
            centrelineButton.transform.localPosition = new Vector3(0.0f + (0.055f * row), 0.055f - (0.055f * column), 0);
            centrelineButton.transform.rotation = new Quaternion(0, 0, 0, 0);

            if (column == 2)
            {
                column = 0;
                row++;
            }
            else
            {
                column++;
            }
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
