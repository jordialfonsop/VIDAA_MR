using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrelineButton : MonoBehaviour
{
    private GameObject centrelineRender;
    private bool isToggle = false;
    public void SetButtonColor(Color color)
    {
        this.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Oculus.Interaction.RoundedBoxProperties>().Color = color;
    }

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
            SetButtonColor(new Color(255, 255, 0, 20));
            CentrelineManager.Instance.SetActiveCentreline(centrelineRender);
        }
        else
        {
            SetButtonColor(new Color(255, 255, 255, 20));
            if (CentrelineManager.Instance.GetActiveCentreline() == centrelineRender)
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
