using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentrelineButton : MonoBehaviour
{
    private GameObject centrelineRender;
    private bool isToggle = false;
    public void SetButtonColor(Color color)
    {
        Oculus.Interaction.InteractableColorVisual.ColorState colorState = new Oculus.Interaction.InteractableColorVisual.ColorState() { Color = color };
        this.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Oculus.Interaction.InteractableColorVisual>().InjectOptionalNormalColorState(colorState);
    }

    public void SetIsToggle(bool toggle) {  isToggle = toggle; }

    public void SetCentrelineRender(GameObject render) { centrelineRender = render;}

    public void SetActiveCentrelineRender()
    {
        CentrelineManager.Instance.SetActiveCentreline(centrelineRender);
        transform.parent.gameObject.GetComponent<CentrelineToolbox>().RegenerateButtons();
    }

    public void ToggleActiveCentrelineRender()
    {
        centrelineRender.SetActive(!centrelineRender.activeSelf);
        if (centrelineRender.activeSelf)
        {
            SetButtonColor(new Color(255, 255, 0, 0.2f));
        }
        else
        {
            SetButtonColor(new Color(255, 255, 255, 0.2f));
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
