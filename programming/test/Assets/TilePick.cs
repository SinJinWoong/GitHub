using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TilePick : MonoBehaviour {
    private Image image;
    // Use this for initialization
    void Start () {
        image = gameObject.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void PickSoil()
    {
        TileMouse.Instance.layerMask = LayerMask.NameToLayer("SoilTile");
        GridTile.Instance.selectSprite = image.sprite;
        TileMouse.Instance.sprite = image.sprite;
        TileMouse.Instance.ImageS = image;
        TileMouse.Instance.ImageSt = null;
    }

    public void PickStucture()
    {
        TileMouse.Instance.layerMask = LayerMask.NameToLayer("StuctureTile");
        GridTile.Instance.selectSprite = image.sprite;
        TileMouse.Instance.sprite = image.sprite;
        TileMouse.Instance.ImageSt = image;
        TileMouse.Instance.ImageS = null;
    }
}
