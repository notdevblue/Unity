using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BezierCurve : MonoBehaviour
{
    public GameObject obj;

    [Range(0, 1)]
    public float value;



    public void Update()
    {
        obj.transform.position = Bezier(points, value);
    }


    public Vector3[] points = new Vector3[4];

    public Vector3 Bezier(Vector3[] points, float val)
    {
        Vector3 pA = Vector3.Lerp(points[0], points[1], val);
        Vector3 pB = Vector3.Lerp(points[1], points[2], val);
        Vector3 pC = Vector3.Lerp(points[2], points[3], val);

        Vector3 pD = Vector3.Lerp(pA, pB, val);
        Vector3 pE = Vector3.Lerp(pB, pC, val);

        Vector3 pF = Vector3.Lerp(pD, pE, val);

        return pF;
    }



    [CanEditMultipleObjects]
    [CustomEditor(typeof(BezierCurve))]
    public class Test : Editor
    {
        private void OnSceneGUI()
        {
            BezierCurve generator = (BezierCurve)target;

            generator.points[0] = Handles.PositionHandle(generator.points[0], Quaternion.identity);
            generator.points[1] = Handles.PositionHandle(generator.points[1], Quaternion.identity);
            generator.points[2] = Handles.PositionHandle(generator.points[2], Quaternion.identity);
            generator.points[3] = Handles.PositionHandle(generator.points[3], Quaternion.identity);


            Handles.DrawLine(generator.points[0], generator.points[1]);
            Handles.DrawLine(generator.points[2], generator.points[3]);

            int curve = 50;
            for(int i = 0; i < curve; ++i)
            {
                Vector3 before = generator.Bezier(generator.points, i / (float)curve);
                Vector3 after = generator.Bezier(generator.points, (i + 1) / (float)curve);

                Handles.DrawLine(before, after);
            }
        }
    }
}
