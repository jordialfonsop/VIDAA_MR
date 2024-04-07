using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using static UnityEngine.GraphicsBuffer;
using Unity.VisualScripting;

public class HeartRender : MonoBehaviour
{

    struct Point
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

    private List<Point> heartPoints = new List<Point>();
    private string heartInput;
    [SerializeField] private string filePathHeart;



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

    void ReadHeartPoints(string input)
    {
        heartPoints.Clear();

        string[] points = input.Split(" ");


        int coordaxis = 0;

        double coordx = 0;
        double coordy = 0;
        double coordz = 0;

        for (int i = 0; i < points.Length; i++)
        {
            Debug.Log(points[i]);

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
                    Point point = new Point(coordx, coordy, coordz);
                    heartPoints.Add(point);
                    break;
            }

        }

    }

    void RenderHeartPoints(string input)
    {
        ReadHeartPoints(input);
        Mesh mesh = new Mesh();

        for (int i = 1;i < heartPoints.Count; i++)
        {
            Vector3 Oldpos = new Vector3((float)heartPoints[i - 1].coordx, (float)heartPoints[i - 1].coordy, (float)heartPoints[i - 1].coordz);
            Vector3 Newpos = new Vector3((float)heartPoints[i].coordx, (float)heartPoints[i].coordy, (float)heartPoints[i].coordz);
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Cube);

            capsule.transform.parent = transform;
            capsule.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            capsule.transform.localPosition = new Vector3((float)heartPoints[i].coordx, (float)heartPoints[i].coordy, (float)heartPoints[i].coordz);
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        heartInput = ReadTextFile(filePathHeart);
        RenderHeartPoints(heartInput);
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        transform.position = new Vector3(0.0f, 0.0f, -10.0f);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
