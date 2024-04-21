using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;
using static LAAMeasurementsManager;

public class ContourRenderer : MonoBehaviour
{

    private List<Points_3D> contourPoints = new List<Points_3D>();
    private List<GameObject> contourCubes = new List<GameObject>();

    public List<Points_3D> GetContourPoints() { return contourPoints; }

    void SetContourPoints(Contours contour)
    {
        contourPoints.Clear();
        contourPoints = contour.points_3D;

    }

    void RenderContourPoints(Contours contour)
    {
        SetContourPoints(contour);
        Mesh mesh = new Mesh();

        for (int i = 1;i < contourPoints.Count; i++)
        {
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Cube);

            capsule.transform.parent = transform;
            capsule.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            capsule.transform.localPosition = new Vector3((float)contourPoints[i].x, (float)contourPoints[i].y, (float)contourPoints[i].z);
            contourCubes.Add(capsule);
        }

    }

    public void Render(Contours contour)
    {
        RenderContourPoints(contour);
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        //transform.position = new Vector3(0.0f, 0.0f, -10.0f);
        this.gameObject.SetActive(false);
    }

    public void SetMaterial(Material material)
    {
        for (int i = 0; i < contourCubes.Count; i++)
        {
            contourCubes[i].GetComponent<Renderer>().material = material;
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
