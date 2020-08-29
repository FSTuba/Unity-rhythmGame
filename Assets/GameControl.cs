using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {
    public static bool IsPause = false;
    public Canvas Canvus_Pause;
    public GameObject background_solo;
    public GameObject background_duo;
    public GameObject mask;
    public GameObject stand_solo;
    public GameObject stand_duo;
    public GameObject text_solo;
    public GameObject text_duo;
    public static int score;
    public Text scoretext;


    void Start () {
        score = 0;

        if (Global.Player == 0) {
            background_solo.SetActive(true);
            background_duo.SetActive(false);
            stand_duo.SetActive(false);
            text_duo.SetActive(false);

        }
        if (Global.Player == 1)
        {
            background_solo.SetActive(false);
            background_duo.SetActive(true);
            stand_duo.SetActive(true);
            text_duo.SetActive(true);
        }

    }
	
	// Update is called once per frame
	void Update () {
        scoretext.text = "SCORE:" + GameControl.score;


        if (Input.GetKeyDown(KeyCode.Escape)) {
            Canvus_Pause.enabled ^= true;
            mask.GetComponent<SpriteRenderer>().enabled ^= true;
            IsPause = !IsPause;
        }
            
        
	}

    public void Resume() {
        Canvus_Pause.enabled = false;
        mask.GetComponent<SpriteRenderer>().enabled  = false;
        IsPause = false;
    }

    public void Restart() {
        SceneManager.LoadScene(2);
    }

    public void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public void Option() {
        //add code here
    }

    public void EndGame() {
        Application.Quit();
    }

}
