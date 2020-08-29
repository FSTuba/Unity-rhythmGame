using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PL_Display : MonoBehaviour {
    string[] DisplayArray = { "Single", "Multi"};
    public Text PLText;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PLText.text = DisplayArray[Global.Player];
    }
}
