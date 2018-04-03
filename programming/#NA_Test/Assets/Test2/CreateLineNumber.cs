using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateLineNumber : MonoBehaviour
{

    public Image[] childLineCount;
    public Image countImage;
    public int lineCount = 5;

    void Start()
    {

        childLineCount = gameObject.GetComponentsInChildren<Image>();
        lineCount = childLineCount.Length;

         StartCoroutine(CreateLineCount_1()); // 3초마다 1칸 회복
    }

    void Update()
    {

    }

    public void DestroyLineCount()
    {
        if (lineCount > 0)
        {
            Destroy(childLineCount[lineCount - 1].gameObject);
            lineCount--;
        }
    }

    public IEnumerator CreateLineCount_1()
    {// 3초마다 1칸 자동회복       
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (lineCount < 5)
            {
                yield return new WaitForSeconds(3f);

                Image cou = Instantiate(countImage);
                cou.transform.parent = this.transform;
                cou.transform.localScale = new Vector3(1, 1, 1); // 안하니까 엄청 크게 생성되었다....

                childLineCount = gameObject.GetComponentsInChildren<Image>();
                lineCount = childLineCount.Length;
            }
        }

    }

    public void CreateLineCount_2()
    {// 실행 취소(회수) 한 숫자만큼 회복 (최대 5)
        if (lineCount < 5)
        {
            Image cou = Instantiate(countImage);
            cou.transform.parent = this.transform;
            cou.transform.localScale = new Vector3(1, 1, 1); // 안하니까 엄청 크게 생성되었다....

            childLineCount = gameObject.GetComponentsInChildren<Image>();
            lineCount = childLineCount.Length;
        }

    }

    public IEnumerator CreateLineCount_3()
    {// F키 누르고있는 동안 회복 (1초에 1칸 / 중간에 취소하면 초기화)
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            if (lineCount < 5)
            {
                yield return new WaitForSeconds(1f);

                Image cou = Instantiate(countImage);
                cou.transform.parent = this.transform;
                cou.transform.localScale = new Vector3(1, 1, 1); // 안하니까 엄청 크게 생성되었다....

                childLineCount = gameObject.GetComponentsInChildren<Image>();
                lineCount = childLineCount.Length;
            }
        }

    }
}
