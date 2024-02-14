using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorSave : MonoBehaviour
{
    [SerializeField]private OVRSpatialAnchor spatialAnchor;
    // Start is called before the first frame update
    void Start()
    {
        spatialAnchor.Save();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnApplicationFocus(bool focus)
    {
        if (true)
        {
            //spatialAnchor.LoadUnboundAnchors();
        }
    }
}
