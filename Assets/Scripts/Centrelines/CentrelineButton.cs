using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrelineButton : MonoBehaviour
{
    private GameObject centrelineRender;
    private bool isToggle = false;

    public bool GetIsToggle() {  return isToggle; }

    public void SetIsToggle(bool toggle) {  isToggle = toggle; }

    public GameObject GetCentrelineRender() { return centrelineRender; }

    public void SetCentrelineRender(GameObject render) { centrelineRender = render;}

    public void SetActiveCentrelineRender()
    {

        CentrelineManager.Instance.SetActiveCentreline(centrelineRender);

    }

    public void ToggleActiveCentrelineRender()
    {
        centrelineRender.SetActive(!centrelineRender.activeSelf);
        if (centrelineRender.activeSelf)
        {
            CentrelineManager.Instance.SetActiveCentreline(centrelineRender);
        }
        else
        {
            if(CentrelineManager.Instance.GetActiveCentreline() == centrelineRender)
            {
                CentrelineManager.Instance.SetActiveCentreline(null);
            }
        }
    }

    public void ButtonPress()
    {
        if(isToggle)
        {
            ToggleActiveCentrelineRender();
        }
        else
        {
            SetActiveCentrelineRender();
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
