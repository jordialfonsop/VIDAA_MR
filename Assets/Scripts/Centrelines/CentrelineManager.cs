using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class CentrelineManager : MonoBehaviour
{
    [SerializeField] string centrelinesPath;
    [SerializeField] GameObject centrelinesPrefab;
    [SerializeField] Material centrelineActiveMaterial;
    [SerializeField] Material centrelineUnactiveMaterial;
    private GameObject activeCentreline;
    public List<GameObject> centrelinesList = new List<GameObject>();

    public struct Point
    {
        //Variable declaration
        //Note: I'm explicitly declaring them as public, but they are public by default. You can use private if you choose.
        public double coordx;
        public double coordy;
        public double coordz;

        //Constructor (not necessary, but helpful)
        public Point(double coordx, double coordy, double coordz)
        {
            this.coordx = coordx;
            this.coordy = coordy;
            this.coordz = coordz;
        }
    }

    private static CentrelineManager _instance;

    

    public static CentrelineManager Instance
    {
        get { return _instance; }
    }

    public GameObject GetActiveCentreline()
    {
        return activeCentreline;
    }

    public void SetActiveCentreline(GameObject centreline)
    {

        if (activeCentreline)
        {
            activeCentreline.GetComponent<CentrelineRenderer>().SetMaterial(centrelineUnactiveMaterial);
        }
        if(centreline)
        {
            activeCentreline = centreline;
            activeCentreline.GetComponent<CentrelineRenderer>().SetMaterial(centrelineActiveMaterial);
        }
        else
        {
            activeCentreline = null;
        }
        
    }


    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DirectoryInfo dir = new DirectoryInfo(centrelinesPath);
        FileInfo[] info = dir.GetFiles("*.txt");
        foreach (FileInfo f in info)
        {
            string name = f.Name.Split(".txt")[0];
            GameObject centrelineRender = Instantiate(centrelinesPrefab);
            centrelineRender.name = name + " Render";
            centrelineRender.transform.parent = this.transform;
            centrelineRender.GetComponent<CentrelineRenderer>().SetFilePathCentreline(f.FullName);
            centrelineRender.GetComponent<CentrelineRenderer>().Render();
            centrelineRender.GetComponent<CentrelineRenderer>().SetMaterial(centrelineUnactiveMaterial);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
