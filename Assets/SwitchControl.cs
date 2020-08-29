using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchControl : MonoBehaviour{

    public void GoToMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void Song_Plus()
    {
        Global.Song = (Global.Song+1) % Global.SongArray.Length;      //0123
    }

    public void Song_Minus()
    {
        Global.Song = (Global.Song + Global.SongArray.Length - 1) % Global.SongArray.Length;
    }

    public void Diff_Plus()
    {
        Global.Difficulty = (Global.Difficulty+1)%3;    //012
    }

    public void Diff_Minus()
    {
        Global.Difficulty = (Global.Difficulty + 2) % 3;
    }

    public void Player_Plus()
    {
        Global.Player = (Global.Player+1) % 2;  //0123
    }

    public void Player_Minus()
    {
        Global.Player = (Global.Player + 1) % 2;
    }

    public void Gogo() {
        SceneManager.LoadScene(2);
    }



}





