using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;


public class CentrelineToolbox : MonoBehaviour
{

    [SerializeField] private GameObject button;
    [SerializeField] private bool isToggle = false;
    // Start is called before the first frame update
    void Start()
    {
        GenerateButtons(); 
    }

    void GenerateButtons() {

        int row = 0;
        int column = 0;
        if (isToggle)
        {
            for (int i = 0; i < CentrelineManager.Instance.centrelinesList.Count; i++)
            {
                GameObject centrelineButton = Instantiate(button);
                centrelineButton.name = CentrelineManager.Instance.centrelinesList[i].name.Split("Render")[0] + "Button";
                centrelineButton.GetComponent<CentrelineButton>().SetCentrelineRender(CentrelineManager.Instance.centrelinesList[i]);
                centrelineButton.GetComponent<CentrelineButton>().SetIsToggle(true);
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
        else
        {
            CentrelineManager.Instance.CheckActiveToggleCentrelines();
            for (int i = 0; i < CentrelineManager.Instance.activeToggleCentrelinesList.Count; i++)
            {
                GameObject centrelineButton = Instantiate(button);
                centrelineButton.name = CentrelineManager.Instance.activeToggleCentrelinesList[i].name.Split("Render")[0] + "Button";
                centrelineButton.GetComponent<CentrelineButton>().SetCentrelineRender(CentrelineManager.Instance.activeToggleCentrelinesList[i]);
                centrelineButton.GetComponent<CentrelineButton>().SetIsToggle(false);
                centrelineButton.transform.parent = this.transform;
                centrelineButton.transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = CentrelineManager.Instance.activeToggleCentrelinesList[i].name.Split("Render")[0];
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
        

    }

    void DeleteButtons()
    {
        for(int i = transform.childCount-1; i > 1; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (!isToggle)
        {
            DeleteButtons();
            GenerateButtons();
        }   
    }
}
