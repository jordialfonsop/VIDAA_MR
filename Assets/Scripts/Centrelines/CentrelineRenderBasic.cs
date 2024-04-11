using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class CentrelineRenderBasic : MonoBehaviour
{

    

    private List<CentrelineManager.Point> centrelinePoints = new List<CentrelineManager.Point>();
    private string filePathCentreline;
    private string placeholderExample1 = "";
    private string placeholderExample2 = "";
    private string placeholderExample3 = "";
    public string GetFilePathCentreline()
    {
        return filePathCentreline;
    }

    public void SetFilePathCentreline(string path)
    {
        filePathCentreline = path;
    }

    public List<CentrelineManager.Point> GetCentrelinePoints() { return centrelinePoints; }



    string ReadTextFile(string filePath)
    {
        StreamReader inp_stm = new StreamReader(filePath);

        string input = "";

        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            input += inp_ln; 
        }

        inp_stm.Close();

        return input;
    }

    void ReadCentrelinePoints(string input)
    {
        centrelinePoints.Clear();

        string[] points = input.Split(" ");


        int coordaxis = 0;

        double coordx = 0;
        double coordy = 0;
        double coordz = 0;

        for (int i = 0; i < points.Length; i++)
        {

            switch (coordaxis)
            {
                case 0:
                    coordaxis++;
                    coordx = double.Parse(points[i], CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case 1:
                    coordaxis++;
                    coordy = double.Parse(points[i], CultureInfo.InvariantCulture.NumberFormat);
                    break;
                case 2:
                    coordaxis = 0;
                    coordz = double.Parse(points[i], CultureInfo.InvariantCulture.NumberFormat);
                    CentrelineManager.Point point = new CentrelineManager.Point(coordx, coordy, coordz);
                    centrelinePoints.Add(point);
                    break;
            }

        }

    }

    void RenderCentrelinePoints(string input)
    {
        ReadCentrelinePoints(input);
        Mesh mesh = new Mesh();

        for (int i = 1;i < centrelinePoints.Count; i++)
        {
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Cube);

            capsule.transform.parent = transform;
            capsule.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            capsule.transform.localPosition = new Vector3((float)centrelinePoints[i].coordx, (float)centrelinePoints[i].coordy, (float)centrelinePoints[i].coordz);
        }

    }

    public void StartRender()
    {
        RenderCentrelinePoints(ReadTextFile(filePathCentreline));
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        transform.position = new Vector3(0.0f, 0.0f, -10.0f);
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
