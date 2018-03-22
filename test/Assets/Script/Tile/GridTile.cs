using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour {

    public GameObject gridTile; //그리드 오브젝트
    public Sprite selectSprite; //그리드 스프라이트 설치
    public SpriteRenderer gLayer; //레이어 0  깊이를 위해 할 예정
    public int setGridTile; //그리드 갯수


    // Use this for initialization
    void Start()
    {
        //setGridTile = TileManger.Instance.GridNum;
        setGridTile = 7;
        GridTileCreate();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GridTileCreate()
    {
        float tileX = 0.64f; //x 축
        float tileY = 0.39f; //y축
        float tileCenter = 0f; //그리드 타일의 중심
        float odd = 0; //홀수
        float even = 0; //짝수
        

        if (setGridTile > 0 && setGridTile <= 61) // 그리드 갯수 제한 (변경 예정)
        {
            if (setGridTile % 2 != 0)  //홀수 일 때(짝수 불가)
            {
                odd = ((tileX * (setGridTile - 1) * (-1))); //홀수 그리드 위치
                even = ((tileY * (setGridTile - 1) * (-1) + (tileY * 4) + tileCenter)); //짝수 그리드 위치

                for (int y = 0; y < setGridTile; y++) // = 이 아닌 ll으로 배치
                {
                    for (int x = 0; x < setGridTile; x++)
                    {
                        Instantiate(gridTile, new Vector3(odd, even, 0), Quaternion.identity); //그리드 배치
                        even += tileY; //짝수 타일
                        odd += tileX; //홀수 타일
                    }
                    odd -= (tileX * (setGridTile - 1)); //그리드 다음 행 위치
                    even -= (tileY * (setGridTile + 1)); // 그리드 다음 행 위치
                }
            }
        }
    }    
}
