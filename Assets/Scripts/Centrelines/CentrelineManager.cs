using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class CentrelineManager : MonoBehaviour
{
    [SerializeField] string centrelinesPath;
    [SerializeField] GameObject centrelinesPrefab;
    [SerializeField] public GameObject renderCube;
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

    private string currentCentreline;

    private GameObject[] centrelines;

    public static CentrelineManager Instance
    {
        get { return _instance; }
    }

    public string GetCurrentCentreline()
    {
        return currentCentreline;
    }

    public void SetCurrentCentreline(string centreline)
    {
        currentCentreline = centreline;
    }


    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        DirectoryInfo dir = new DirectoryInfo(centrelinesPath);
        FileInfo[] info = dir.GetFiles("*.*");
        foreach (FileInfo f in info)
        {
            string name = f.Name.Split(".txt")[0];
            GameObject centrelineRender = Instantiate(centrelinesPrefab);
            centrelineRender.name = name;
            centrelineRender.transform.parent = this.transform;
            centrelineRender.GetComponent<CentrelineRender>().SetFilePathCentreline(f.FullName);
            centrelineRender.GetComponent<CentrelineRender>().StartRender();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
