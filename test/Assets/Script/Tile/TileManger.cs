using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TileManger : MonoBehaviour {
    static public TileManger Instance;

    public InputField inputGridNum; //그리드 갯수 설정

    //각 타일의 소팅레이어
    public int girdLayer, soilLayer, structureLayer;

    //그리드 갯수
    public int GridNum;

    // Use this for initialization
    void Start()
    {
        girdLayer = 0;
        soilLayer = 1;
        structureLayer = 2;
        DontDestroyOnLoad(this);//씬이 전환이 되도 그리드 갯수는 초기화 되지 않게
        inputGridNum = inputGridNum.GetComponent<InputField>();
    }
	
	// Update is called once per frame
	void Update () {
        //GridInput();
    }

    public void GridInput()
    {
        GridNum = int.Parse(inputGridNum.text); //입력 받은 그리드 수를 int로 변경
        Debug.Log(GridNum);
    }
}
