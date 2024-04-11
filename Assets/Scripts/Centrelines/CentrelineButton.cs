using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrelineButton : MonoBehaviour
{
    private GameObject centrelineRender;

    public GameObject GetCentrelineRender() { return centrelineRender; }

    public void SetCentrelineRender(GameObject render) { centrelineRender = render;}

    public void SetActiveCentrelineRender()
    {
        centrelineRender.SetActive(!centrelineRender.activeSelf);
        if (centrelineRender.activeSelf)
        {
            CentrelineManager.Instance.SetActiveCentreline(centrelineRender);
        }
        else
        {
            CentrelineManager.Instance.SetActiveCentreline(null);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
