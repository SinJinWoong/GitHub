using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCreater_2 : MonoBehaviour {

    public GameObject linePrefab;

    public Line activeLine;

    public int M_count = 10;


    float depth = 10.0f;
    public float speed = 1.5f;

    void Update()
    {
        Vector2 MousePos = Input.mousePosition;
        Vector2 wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(MousePos.x, MousePos.y, depth));

        if (Input.GetMouseButtonDown(0) && M_count > 0) 
        // 0 왼쪽 마우스버튼 / 1 중간? 스크롤인가 / 2 오른쪽
        {
            GameObject lineGO = Instantiate(linePrefab);
            activeLine = lineGO.GetComponent<Line>(); // 새로생긴 라인인것같다.
        }
        if (Input.GetMouseButton(0))
        {
            transform.position = Vector3.MoveTowards(transform.position, wantedPos, speed * Time.deltaTime);
        }

        if (activeLine != null )
        {
            Vector2 mousePos = transform.position;
            activeLine.UpdateLine(mousePos, M_count);

            if (Input.GetMouseButtonUp(0) || activeLine.count >= M_count)
            {
                M_count = M_count - activeLine.count;
                activeLine = null;
            }
        }
        else
        {
            transform.position = wantedPos;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            M_count = 20;
                }
}
