﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour {
    public Image image;
    // Use this for initialization
    void Start () {
        image = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void SeletMe()
    {
        GridTile.Instance.selectSprite = image.sprite;
    }
}
