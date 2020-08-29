using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Song_Display : MonoBehaviour {
    //string[] DisplayArray = {"ASCORE", "MEGALOVANIA", "KEMURIKUSA","BELIEVER"};
    //public TextAsset TextFile;
    //string Data;
    string[] SongArray;

    
    public Text SongText;




    void Start () {
        //Data = TextFile.text;
        //SongArray = Data.Replace("\r", "").Replace(" ", "").Replace("\n", " ").Split(' ');
        SongArray = Global.SongArray;
    
    }
	
	// Update is called once per frame
	void Update () {
        //SongText.text = DisplayArray[Global.Song];
        SongText.text = SongArray[Global.Song];

    }
}
