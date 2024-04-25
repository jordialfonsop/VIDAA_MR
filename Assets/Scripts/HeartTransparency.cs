using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartTransparency : MonoBehaviour
{

    [SerializeField] Material X_Downwards_Transparent;
    [SerializeField] Material X_Upwards_Transparent;
    [SerializeField] Material Y_Downwards_Transparent;
    [SerializeField] Material Y_Upwards_Transparent; 
    [SerializeField] Material Z_Downwards_Transparent;
    [SerializeField] Material Z_Upwards_Transparent;
    [SerializeField] Material X_Downwards;
    [SerializeField] Material X_Upwards;
    [SerializeField] Material Y_Downwards;
    [SerializeField] Material Y_Upwards;
    [SerializeField] Material Z_Downwards;
    [SerializeField] Material Z_Upwards;

    [SerializeField] Texture2D heartTexture_90;
    [SerializeField] Texture2D heartTexture_75;
    [SerializeField] Texture2D heartTexture_50;
    [SerializeField] Texture2D heartTexture_25;

    [SerializeField] GameObject heart;
    // Start is called before the first frame update

    public void SetTransparentTexture(Texture2D texture)
    {
        X_Downwards_Transparent.mainTexture = texture;
        X_Upwards_Transparent.mainTexture = texture;
        Y_Downwards_Transparent.mainTexture = texture;
        Y_Upwards_Transparent.mainTexture = texture;
        Z_Downwards_Transparent.mainTexture = texture;
        Z_Upwards_Transparent.mainTexture = texture;
    }

    public void ButtonPress(string quantity)
    {
        GameObject currentSlicer;
        string currentDirection = "";
        string currentAxis = "";
        if (SliceConfiguratorManager.Instance.GetCurrentSlicer())
        {
            currentSlicer = SliceConfiguratorManager.Instance.GetCurrentSlicer();
            currentDirection = SliceConfiguratorManager.Instance.GetCurrentDirection();
            currentAxis = currentSlicer.name.Split("_")[0];
        }
        else
        {
            currentSlicer = null;
        }

        

        if (quantity == "100")
        {
            SliceConfiguratorManager.Instance.SetIsTransparent(false);
            if (currentSlicer)
            {
                switch (currentAxis)
                {
                    case "X":
                        switch (currentDirection)
                        {
                            case "Downwards":
                                heart.GetComponent<Renderer>().material = X_Downwards;
                                break;
                            case "Upwards":
                                heart.GetComponent<Renderer>().material = X_Upwards;
                                break;
                            default: break;
                        }
                        break;
                    case "Y":
                        switch (currentDirection)
                        {
                            case "Downwards":
                                heart.GetComponent<Renderer>().material = Y_Downwards;
                                break;
                            case "Upwards":
                                heart.GetComponent<Renderer>().material = Y_Upwards;
                                break;
                            default: break;
                        }
                        break;
                    case "Z":
                        switch (currentDirection)
                        {
                            case "Downwards":
                                heart.GetComponent<Renderer>().material = Z_Downwards;
                                break;
                            case "Upwards":
                                heart.GetComponent<Renderer>().material = Z_Upwards;
                                break;
                            default: break;
                        }
                        break;
                    default:break;
                }
            }
            else
            {
                heart.GetComponent<Renderer>().material = X_Downwards;
            }
            
        }
        else
        {
            SliceConfiguratorManager.Instance.SetIsTransparent(true);
            switch (quantity)
            {
                case "90":
                    SetTransparentTexture(heartTexture_90);
                    break;
                case "75":
                    SetTransparentTexture(heartTexture_75);
                    break;
                case "50":
                    SetTransparentTexture(heartTexture_50);
                    break;
                case "25":
                    SetTransparentTexture(heartTexture_25);
                    break;
                default: break;
            }

            if (currentSlicer)
            {
                switch (currentAxis)
                {
                    case "X":
                        switch (currentDirection)
                        {
                            case "Downwards":
                                heart.GetComponent<Renderer>().material = X_Downwards_Transparent;
                                break;
                            case "Upwards":
                                heart.GetComponent<Renderer>().material = X_Upwards_Transparent;
                                break;
                            default: break;
                        }
                        break;
                    case "Y":
                        switch (currentDirection)
                        {
                            case "Downwards":
                                heart.GetComponent<Renderer>().material = Y_Downwards_Transparent;
                                break;
                            case "Upwards":
                                heart.GetComponent<Renderer>().material = Y_Upwards_Transparent;
                                break;
                            default: break;
                        }
                        break;
                    case "Z":
                        switch (currentDirection)
                        {
                            case "Downwards":
                                heart.GetComponent<Renderer>().material = Z_Downwards_Transparent;
                                break;
                            case "Upwards":
                                heart.GetComponent<Renderer>().material = Z_Upwards_Transparent;
                                break;
                            default: break;
                        }
                        break;
                    default: break;
                }
            }
            else
            {
                heart.GetComponent<Renderer>().material = X_Downwards_Transparent;
            }
        }
        if (currentSlicer)
        {
            SliceConfiguratorManager.Instance.UpdateShader();
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
