using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reset_test()
    {
        SceneManager.LoadScene("Test");
    }

    public void Reset_test3()
    {
        SceneManager.LoadScene("Test3");
    }
}
