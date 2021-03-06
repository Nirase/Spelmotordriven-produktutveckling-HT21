using System;
using UnityEngine;

public enum BezierControlPointMode
{
    Free,
    Aligned,
    Mirrored
}
public class BezierSpline : MonoBehaviour
{
    [SerializeField]
    Vector3[] points;

    [SerializeField]
    BezierControlPointMode[] modes;

    [SerializeField]
    bool loop;
    [SerializeField]
    bool _2d;

    public int ControlPointCount
    {
        get
        {
            return points.Length;
        }
    }
    public Vector3 GetControlPoint(int index)
    {
        return points[index];
    }
    public void SetControlPoint(int index, Vector3 point)
    {
        if (index % 3 == 0)
        {
            Vector3 delta = point - points[index];
            if (loop)
            {
                if (index == 0)
                {
                    points[1] += delta;
                    points[points.Length - 2] += delta;
                    points[points.Length - 1] = point;
                }
                else if (index + 1 < points.Length)
                {
                    points[index] = point;
                    points[index + 1] += delta;
                    points[index - 1] += delta;
                }
                else
                {
                    points[index - 1] += delta;
                    points[0] += delta;
                }
            }
            else
            {
                if (index > 0)
                {
                    points[index - 1] += delta;
                }
                if (index + 1 < points.Length)
                {
                    points[index + 1] += delta;
                }
            }

            if (_2d)
            {
                point.y = 0;
            }
        }
        points[index] = point;
        EnforceMode(index);
    }
    public BezierControlPointMode GetControlPointMode(int index)
    {
        return modes[(index + 1) / 3];
    }
    public void SetControlPointMode(int index, BezierControlPointMode mode)
    {
        int modeIndex = (index + 1) / 3;
        modes[modeIndex] = mode;
        if (loop)
        {
            if (modeIndex == 0)
            {
                modes[modes.Length - 1] = mode;
            }
            else if (modeIndex == modes.Length - 1)
            {
                modes[0] = mode;
            }
        }
        EnforceMode(index);
    }
    public bool Loop
    {
        get { return loop; }
        set
        {
            loop = value;
            if (value == true)
            {
                modes[modes.Length - 1] = modes[0];
                SetControlPoint(0, points[0]);
            }
        }
    }

    public bool _2D{
        get { return _2d;}
        set
        {
            _2d = value;
            if(_2d)
                Enforce2D();
        }
    }

    private void Enforce2D()
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].y = 0;
        }
    }

    void EnforceMode(int index)
    {
        int modeIndex = (index + 1) / 3;
        BezierControlPointMode mode = modes[modeIndex];
        if(mode == BezierControlPointMode.Free || !loop && (modeIndex == 0 || modeIndex == modes.Length - 1))
        {
            return;
        }
        int middleIndex = modeIndex * 3;
        int fixedIndex, enforcedIndex;
        if(index <= middleIndex)
        {
            fixedIndex = middleIndex - 1;
            if(fixedIndex < 0)
            {
                fixedIndex = points.Length - 2;
            }
            enforcedIndex = middleIndex + 1;
            if( enforcedIndex >= points.Length)
            {
                enforcedIndex = 1;
            }
        }
        else
        {
            fixedIndex = middleIndex + 1; 
            if (fixedIndex >= points.Length)
            {
                fixedIndex = 1;
            }
            enforcedIndex = middleIndex - 1;
            if (enforcedIndex < 0)
            {
                enforcedIndex = points.Length - 2;
            }
        }
        Vector3 middle = points[middleIndex];
        Vector3 enforcedTangent = middle - points[fixedIndex];
        if(mode == BezierControlPointMode.Aligned)
        {
            enforcedTangent = enforcedTangent.normalized * Vector3.Distance(middle, points[enforcedIndex]);
        }
        points[enforcedIndex] = middle + enforcedTangent;
    }
    public void RemoveSelected(int selectedIndex)
    {
        int selectedPoint = GetIndex(selectedIndex);
        if (selectedPoint == GetIndex(points.Length - 1))
        {
            RemoveCurve();
            return;
        }
        for (int i = selectedPoint-1; i < points.Length; i++)
        {
            if(i+3 < points.Length-1)
                points[i] = points[i + 3];
        }
        Array.Resize(ref points, points.Length - 3);

        Array.Resize(ref modes, modes.Length - 1);

        EnforceMode(points.Length - 4);
        if (loop)
        {
            points[points.Length - 1] = points[0];
            modes[modes.Length - 1] = modes[0];
            EnforceMode(0);
        }
    }

    private int GetIndex(int selectedIndex)
    {
        if (selectedIndex % 3 == 1)
            selectedIndex -= 1;
        if (selectedIndex % 3 == 2)
            selectedIndex += 1;
        return selectedIndex;
    }
    public Vector3 GetPoint(float t)
    {
        int i;
        if ( t >= 1f)
        {
            t = 1f;
            i = points.Length - 4;
        }
        else
        {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }
        return transform.TransformPoint(Bezier.GetPoint(points[i], points[i + 1], points[i + 2], points[i + 3], t));
    }

    public Vector3 GetVelocity(float t)
    {
        int i;
        if (t >= 1f)
        {
            t = 1f;
            i = points.Length - 4;
        }
        else
        {
            t = Mathf.Clamp01(t) * CurveCount;
            i = (int)t;
            t -= i;
            i *= 3;
        }
        return transform.TransformPoint(Bezier.GetFirstDerivative(points[i], points[i + 1], points[i + 2], points[i + 3], t)) - transform.position;
    }

    public Vector3 GetDirection(float t)
    {
        return GetVelocity(t).normalized;
    }

    public void AddCurve()
    {
        Vector3 point = points[points.Length - 1];
        Array.Resize(ref points, points.Length + 3);
        point.x += 1f;
        points[points.Length - 3] = point;
        point.x += 1f;
        points[points.Length - 2] = point;
        point.x += 1f;
        points[points.Length - 1] = point;

        Array.Resize(ref modes, modes.Length + 1);
        modes[modes.Length - 1] = modes[modes.Length - 2];
        EnforceMode(points.Length - 4);
        if (loop)
        {
            points[points.Length - 1] = points[0];
            modes[modes.Length - 1] = modes[0];
            EnforceMode(0);
        }
    }

    public void RemoveCurve()
    {
        
        Array.Resize(ref points, points.Length - 3);

        Array.Resize(ref modes, modes.Length - 1);

        EnforceMode(points.Length - 4);
        if (loop)
        {
            points[points.Length - 1] = points[0];
            modes[modes.Length - 1] = modes[0];
            EnforceMode(0);
        }
    }

    public int CurveCount
    {
        get
        {
            return (points.Length - 1) / 3;
        }
    }
    public void Reset()
    {
        points = new Vector3[]
        {
            new Vector3(1, 0, 0),
            new Vector3(2, 0, 0),
            new Vector3(3, 0, 0),
            new Vector3(4, 0, 0)
        };
        modes = new BezierControlPointMode[]
        {
            BezierControlPointMode.Free,
            BezierControlPointMode.Free
        };
    }

}
