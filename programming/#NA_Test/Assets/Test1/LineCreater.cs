using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreater : MonoBehaviour {

    public GameObject linePrefab;

    public Line activeLine;

    public int M_count = 10;


    void FixedUpdate()
    {

        if (Input.GetMouseButtonDown(0) && M_count > 0)
        // 0 왼쪽 마우스버튼 / 1 우클릭 / 2 휠
        {
            GameObject lineGO = Instantiate(linePrefab);
            activeLine = lineGO.GetComponent<Line>(); // 새로생긴 라인인것같다.
        }

        if (activeLine != null)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            activeLine.UpdateLine(mousePos, M_count);

            if (Input.GetMouseButtonUp(0) || activeLine.count >= M_count)
            {
                M_count = M_count - activeLine.count;
                activeLine = null;
            }
        }


        if (Input.GetKeyDown(KeyCode.Space))
            M_count = 10;
    }
}