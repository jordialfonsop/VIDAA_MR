using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {
        Debug.Log(this.transform.localEulerAngles.y);
        if (this.transform.localEulerAngles.y > 200)
        {
            this.transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(true);
        }
        else{
            this.transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(false);
        }

    }*/

    private bool _menuPrev;
    private void Update()
    {
        var state = OVRPlugin.GetControllerState4((uint)OVRInput.Controller.Hands);
        bool menuGesture = (state.Buttons & (uint)OVRInput.RawButton.Start) > 0;
        if (menuGesture && !_menuPrev)
        {
            this.transform.GetChild(4).gameObject.SetActive(!this.transform.GetChild(4).gameObject.activeSelf);
        }
        _menuPrev = menuGesture;
    }
}
