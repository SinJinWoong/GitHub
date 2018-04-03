using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour {

    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;

    List<Vector2> points;

    public int count = -1;

    public void UpdateLine(Vector2 mousePos, int Max)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos, Max);
            return;
        }

        // Check if the mouse has moved enough for us to insert new point
        // if it has : insert point at mouse position
        // 새로운 점을 삽입 할만큼 마우스가 움직 였는지 확인합니다. 
        // 있는 경우 : 마우스 위치에 삽입 점

        if(Vector2.Distance(points.Last(),mousePos) > 0.1f && count < Max )
        {
            SetPoint(mousePos, Max);
        }
    }

    void SetPoint(Vector2 point, int max)
    {
        if(count < max)
        {
            points.Add(point);

            lineRenderer.positionCount = points.Count;
            lineRenderer.SetPosition(points.Count - 1, point);

            if (points.Count > 1)
            {
                edgeCol.points = points.ToArray();
            }

            max -= count;
            count++;
        }
    }
}
