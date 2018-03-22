using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public GameObject aaa;

    void OnMouseDown() // 타일을 클릭하면 타일위에 건물이 생겼다고 가정함
    {
        GameObject obj = Instantiate(aaa);
        //위치 적용
        obj.transform.position = transform.position;
    }
}
