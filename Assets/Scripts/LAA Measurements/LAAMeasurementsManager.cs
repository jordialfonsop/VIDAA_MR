using Meta.WitAi.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UIElements;

public class LAAMeasurementsManager : MonoBehaviour
{

    [System.Serializable]
    public class LAAMeasurements
    {
        public List<CentrelineMeasurement> CentrelineMeasurements;
    }
    [System.Serializable]
    public class CentrelineMeasurement
    {
        public string _id;
        public string patient;
        public string centreline;
        public End end;
        public string user;
        public List<Contours> contours;

        public CentrelineMeasurement(string _id, string patient, string centreline, End end, string user, List<Contours> contours) {
        
            this._id = _id;
            this.patient = patient;
            this.centreline = centreline;
            this.end = end;
            this.user = user;
            this.contours = contours;
        }
    }

    [System.Serializable]
    public class Contours
    {
        public Measurements measurements;
        public List<Points_3D> points_3D;
        public List<Points_2D> points_2D;
        public Lines lines;
        public string name;

        public Contours(Measurements measurements, List<Points_3D> points_3D, List<Points_2D> points_2D, Lines lines, string name)
        {
            this.measurements = measurements;
            this.points_3D = points_3D;
            this.points_2D = points_2D;
            this.lines = lines;
            this.name = name;
        }
    }

    [System.Serializable]
    public class End
    {
        public string x;
        public string y;
        public string z;

        public End(string _x,string _y, string _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
    }

    [System.Serializable]
    public class Measurements
    {
        public float height_LAA;
        public float D1;
        public float D2;
        public float PDMD;
        public float Dmean;

        public Measurements(float height_LAA, float d1, float d2, float pDMD, float dmean)
        {
            this.height_LAA = height_LAA;
            D1 = d1;
            D2 = d2;
            PDMD = pDMD;
            Dmean = dmean;
        }
    }

    [System.Serializable]
    public class Points_3D
    {
        public float x;
        public float y;
        public float z;

        public Points_3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }

    [System.Serializable]
    public class Points_2D
    {
        public float x;
        public float y;

        public Points_2D(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
    }

    [System.Serializable]
    public class Lines
    {
        public Line3D D1_3D;
        public Line3D D2_3D;
        public Line2D D1_2D;
        public Line2D D2_2D;

        public Lines(Line3D d1_3D, Line3D d2_3D, Line2D d1_2D, Line2D d2_2D)
        {
            D1_3D = d1_3D;
            D2_3D = d2_3D;
            D1_2D = d1_2D;
            D2_2D = d2_2D;
        }
    }

    [System.Serializable]
    public class Line3D
    {
        public Points_3D start;
        public Points_3D end;

        public Line3D(Points_3D start, Points_3D end)
        {
            this.start = start;
            this.end = end;
        }
    }
    [System.Serializable]
    public class Line2D
    {
        public Points_2D start;
        public Points_2D end;

        public Line2D(Points_2D start, Points_2D end)
        {
            this.start = start;
            this.end = end;
        }
    }

    public LAAMeasurements _LAAMeasurements = new LAAMeasurements();

    [SerializeField] private TextAsset JSONFile;
    [SerializeField] private JSONNode JSONParse;

    public static LAAMeasurementsManager _instance;



    public static LAAMeasurementsManager Instance
    {
        get { return _instance; }
    }

    public void Awake()
    {
        _instance = this;
    }

    public void InitializeLAAMeasurements()
    {
        JSONParse = JSONNode.Parse(JSONFile.text);
        foreach (JSONNode centrelineMeasure in JSONParse)
        {

            List<string> EndValues = new List<string>();
            foreach (JSONNode endAxis in centrelineMeasure["end"])
            {
                EndValues.Add(endAxis);
            }
            End temp_end = new End(EndValues[0], EndValues[1], EndValues[2]);

            List<Contours> temp_contours_list = new List<Contours>();
            foreach (JSONNode contour in centrelineMeasure["contours"])
            {

                List<float> temp_measurements_values = new List<float>();
                foreach (JSONNode measurement in contour["measurements"])
                {
                    temp_measurements_values.Add(measurement);
                }
                Measurements temp_measurements = new Measurements(temp_measurements_values[0],
                                                                temp_measurements_values[1],
                                                                temp_measurements_values[2],
                                                                temp_measurements_values[3],
                                                                temp_measurements_values[4]);

                List<Points_3D> temp_Points_3D = new List<Points_3D>();
                List<float> Points3DValues = new List<float>();
                foreach (JSONNode Point3D in contour["points_3D"])
                {
                    foreach (JSONNode Axis in Point3D)
                    {
                        Points3DValues.Add(Axis);
                    }
                    Points_3D temp_Points_3D_values = new Points_3D(Points3DValues[0], Points3DValues[1], Points3DValues[2]);
                    temp_Points_3D.Add(temp_Points_3D_values);

                }

                List<Points_2D> temp_Points_2D = new List<Points_2D>();
                List<float> Points2DValues = new List<float>();
                foreach (JSONNode Point2D in contour["points_2D"])
                {
                    foreach (JSONNode Axis in Point2D)
                    {
                        Points2DValues.Add(Axis);
                    }
                    Points_2D temp_Points_2D_values = new Points_2D(Points3DValues[0], Points3DValues[1]);
                    temp_Points_2D.Add(temp_Points_2D_values);

                }

                List<Line3D> temp_Lines_3Dvalues = new List<Line3D>();
                List<Line2D> temp_Lines_2Dvalues = new List<Line2D>();
                foreach (JSONNode line in contour["lines"])
                {

                    List<Points_3D> temp_Line_Points_3D = new List<Points_3D>();
                    List<Points_2D> temp_Line_Points_2D = new List<Points_2D>();
                    foreach (JSONNode LinePoint in line)
                    {
                        List<float> LinePointsValues = new List<float>();
                        int i = 0;
                        foreach (JSONNode Axis in LinePoint)
                        {
                            LinePointsValues.Add(Axis);
                            i++;

                        }
                        if (i == 3)
                        {

                            Points_3D temp_Line_Points_3D_values = new Points_3D(LinePointsValues[0], LinePointsValues[1], LinePointsValues[2]);
                            temp_Line_Points_3D.Add(temp_Line_Points_3D_values);
                        }
                        else
                        {
                            Points_2D temp_Line_Points_2D_values = new Points_2D(LinePointsValues[0], LinePointsValues[1]);
                            temp_Line_Points_2D.Add(temp_Line_Points_2D_values);
                        }


                    }
                    if (temp_Line_Points_3D.Count > 0)
                    {
                        Line3D temp_Line_values = new Line3D(temp_Line_Points_3D[0], temp_Line_Points_3D[1]);
                        temp_Lines_3Dvalues.Add(temp_Line_values);
                    }
                    else
                    {
                        Line2D temp_Line_values = new Line2D(temp_Line_Points_2D[0], temp_Line_Points_2D[1]);
                        temp_Lines_2Dvalues.Add(temp_Line_values);
                    }

                }
                Lines temp_Lines = new Lines(temp_Lines_3Dvalues[0],
                                            temp_Lines_3Dvalues[1],
                                            temp_Lines_2Dvalues[0],
                                            temp_Lines_2Dvalues[1]);


                Contours temp_contours = new Contours(temp_measurements,
                                                    temp_Points_3D,
                                                    temp_Points_2D,
                                                    temp_Lines,
                                                    contour["name"]);
                temp_contours_list.Add(temp_contours);


            }

            CentrelineMeasurement element = new CentrelineMeasurement(centrelineMeasure["_id"],
                                                                centrelineMeasure["patient"],
                                                                centrelineMeasure["centreline"],
                                                                temp_end,
                                                                centrelineMeasure["user"],
                                                                temp_contours_list);

            _LAAMeasurements.CentrelineMeasurements.Add(element);

        }
    }
    // Start is called before the first frame update
    void Start()
    { 
        InitializeLAAMeasurements();
    }

// Update is called once per frame
void Update()
{

}
}
