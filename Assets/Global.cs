using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Global : MonoBehaviour {
    public static int Song = 0;
    public static int Difficulty = 0;
    public static int Player = 0;

    string Data;
    public static string[] SongArray;
    StreamReader sr;
    
    
    void Start () {
        var path = Application.streamingAssetsPath + "/songlist.txt";
        Data = File.ReadAllText(path);
        SongArray = Data.Replace("\r", "").Replace(" ", "").Replace("\n", " ").Split(' ');

    }
	
	// Update is called once per frame
	void Update () {
        DontDestroyOnLoad(this);
    }
}
