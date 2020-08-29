using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diff_Display : MonoBehaviour {
    string[] DisplayArray = { "Easy", "Nornal", "Hard"};
    public Text DiffText;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DiffText.text = DisplayArray[Global.Difficulty];
    }
}
