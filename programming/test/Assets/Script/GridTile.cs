using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridTile : MonoBehaviour {
    private static GridTile instance = null;

    public static GridTile Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(GridTile)) as GridTile;
                if (instance == null)
                {
                    Debug.LogError("no active ManagerCenter object");
                }
            }
            return instance;
        }
    }

    public Sprite _GridTile;
    public Sprite _SoilTile;
    public Sprite _StuctureTile;
    public GameObject GTile;//그리드 타일 지정
    public GameObject STile;
    public GameObject StTile;
    
    public Sprite selectSprite;
    public SpriteRenderer SelectSpriteRenderer;
    public Image SelectviweImage;

    public int setGridTile = 5;

    public List<Sprite> TileSprite = new List<Sprite>();//스프라이트 이미지 저장
    public List<SpriteRenderer> TileObjectRenderer = new List<SpriteRenderer>();//타일 오브젝트 렌더러 저장
    public List<string> TileName = new List<string>(); //이미지 이름 저장
    public List<int> SpritCode = new List<int>(); //이미지 번호저장
    public List<int> TileCode = new List<int>(); //타일 이미지 번호저장
    public List<float> TilePositionX = new List<float>(); //이미지 좌표 X저장
    public List<float> TilePositionY = new List<float>(); //이미지 좌표 Y저장
    public List<GameObject> TileObject = new List<GameObject>();//타일 오브젝트 저장
    void Start () {
        GridTileCreate();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void ViewTile()
    {
        
    }

    public void GridTileCreate()
    {
        float tileX = 0.64f;
        float tileY = 0.39f;
        float tileCenter = 0f;
        float odd = 0;
        float even = 0;
        
        if (setGridTile > 0 && setGridTile < 50)
        {
            if (setGridTile % 2 != 0)
            {
                odd = ((tileX * (setGridTile - 1) * (-1)));
                even = ((tileY * (setGridTile - 1) * (-1) + (tileY * 4) + tileCenter));

                for (int y = 0; y < setGridTile; y++)
                {
                    for (int x = 0; x < setGridTile; x++)
                    {
                        GameObject G = Instantiate(GTile, new Vector3(odd, even, 0), Quaternion.identity);
                        G.name = ("Grid" + x.ToString() + y.ToString());
                        G.transform.SetParent(transform);
                        TileObject.Add(G);
                        TileObjectRenderer.Add(G.GetComponent<SpriteRenderer>());

                        GameObject S = Instantiate(STile, new Vector3(odd, even, 0), Quaternion.identity);
                        S.name = ("Soil" + x.ToString() + y.ToString());
                        S.transform.SetParent(transform);
                        TileObject.Add(S);
                        TileObjectRenderer.Add(S.GetComponent<SpriteRenderer>());

                        GameObject St = Instantiate(StTile, new Vector3(odd, even, 0), Quaternion.identity);
                        St.name = ("St" + x.ToString() + y.ToString());
                        St.transform.SetParent(transform);
                        TileObject.Add(St);
                        TileObjectRenderer.Add(St.GetComponent<SpriteRenderer>());

                        even += tileY; //짝수 타일
                        odd += tileX; //홀수 타일
                    }
                    odd -= (tileX * (setGridTile - 1));
                    even -= (tileY * (setGridTile +1));
                }
            }
            else
            {
                Debug.Log("홀수만 입력 가능합니다.");
            }
        }
        else
        {
            Debug.Log("100 미만의 숫자만 입력 가능합니다.");
        }
    }    
}
