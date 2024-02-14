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
    void Update()
    {
        Debug.Log(this.transform.localEulerAngles.y);
        if (this.transform.localEulerAngles.y > 200)
        {
            this.transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(true);
        }
        else{
            this.transform.GetChild(4).transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
