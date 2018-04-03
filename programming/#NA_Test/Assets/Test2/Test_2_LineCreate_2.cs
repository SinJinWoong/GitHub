using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_2_LineCreate_2 : MonoBehaviour {

    private Vector3 mousePos;
    private Vector3 startPos;    // Start position of line
    private Vector3 endPos;    // End position of line
    public int isStart;

    public GameObject linePrefab;
    public GameObject startPosObj; // 시작좌표 표시용 오브젝트
    private GameObject Spos; // 새로생성된 시작좌표 표시용 오브젝트

    public CreateLineNumber lineNumberCounter; // 게이지 계산

    private RaycastHit2D hit;

    public IEnumerator coroutine;
    public bool kenaz = false; // 회복 (회복중이 아니다) 
    // 병과 부정적 에너지 그리고 끊임없이 괴롭히는 생각을 떨쳐준다. 정신적인 교화를 강화시킨다. 집중력 향상
    void Start () {
		
	}
	
	void Update () {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        hit = Physics2D.Raycast(mousePos, Vector2.zero, 0f);

        if (Input.GetMouseButtonDown(0) && hit.transform == null && lineNumberCounter.lineCount > 0 && !kenaz)
        {// 마우스 좌클릭을 했다 / 클릭한곳이 선이 아니다(아무것도 없다) / 게이지가 0이상이다.
            if (isStart == 0) // 0 = 시작좌표가 안찍혔다. // 1 = 시작좌표가 찍혔고 이제 끝좌표차례다.
            {
                startPos = mousePos;
                isStart++;

                Spos = Instantiate(startPosObj);
                Spos.transform.position = startPos;

            }
            else
            {
                endPos = mousePos;
                isStart = 0;
                CreateLine();

                Destroy(Spos);
                lineNumberCounter.DestroyLineCount(); // 게이지 줄이기

            }

        }

        if (hit.transform != null && hit.transform.tag == "Line" && Input.GetMouseButtonDown(0)) // 마우스 좌클릭으로 생성한 선 제거
        {
            Destroy(hit.transform.parent.gameObject);
       //     lineNumberCounter.CreateLineCount_2(); // 게이지 회복방법 2
        }

        if (Input.GetMouseButtonDown(1)) // 시작좌표를 잘못눌렀을때 좌클릭하면 취소할수있따.
        {
            if (isStart == 1) // 시작좌표가 찍혔다.
            {
                isStart--;
                Destroy(Spos);
            }
        }


        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    kenaz = true;
        //    coroutine = lineNumberCounter.CreateLineCount_3(); // 게이지 채우기
        //    StartCoroutine(coroutine);

        //}

        //if (Input.GetKeyUp(KeyCode.F))
        //{
        //    kenaz = false;
        //    StopCoroutine(coroutine);
        //}

    }

    void CreateLine()
    {
        GameObject lineGO = Instantiate(linePrefab);
        lineGO.transform.position = startPos;
        lineGO.transform.rotation = GetRotFromVectors(startPos, endPos);
        Destroy(lineGO, 3); // 회복방법이 _2 라면 사라지지않는다.
    }

    Quaternion GetRotFromVectors(Vector2 posStart, Vector2 posend)
    {
        return Quaternion.Euler(0.0f, 0.0f, -Mathf.Atan2(posend.x - posStart.x, posend.y - posStart.y) * Mathf.Rad2Deg);
    }
}
