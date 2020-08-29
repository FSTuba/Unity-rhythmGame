using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandTrigger2 : MonoBehaviour {
    public GameObject BitToDestroy;
    public GameObject bitaudio;
    public Text HitCheckText;

    bool WaitForDestroy = false;
    bool Perfect = false;

    void Start () {
        //Debug.Log("Start!");
    }
	
	void Update () {


        if ((Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L)) && WaitForDestroy)
        {
            Destroy(BitToDestroy);
            Beep();
            if (Perfect){
                HitCheckText.text = "GREAT!";
                HitCheckText.color = Color.green;
                GameControl.score += 100;
            }
            else {
                HitCheckText.text = "GOOD";
                HitCheckText.color = Color.blue;
                GameControl.score += 80;
            }
            WaitForDestroy = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D col) {
        var collider1 = GetComponents<BoxCollider2D>()[0];
        var collider2 = GetComponents<BoxCollider2D>()[1];
        var collider3 = GetComponents<BoxCollider2D>()[2];
        var collider4 = GetComponents<BoxCollider2D>()[3];


        if (collider4.IsTouching(col)){
            WaitForDestroy = false;
            HitCheckText.text = "MISS";
            HitCheckText.color = Color.gray;
        }
        else if (collider3.IsTouching(col)){
            Perfect = false;
            //Beep();
        }
        else if (collider2.IsTouching(col)) {
            Perfect = true;
            //Beep();
        }
        else if (collider1.IsTouching(col)) {
            Perfect = false;
            BitToDestroy = col.gameObject;
            WaitForDestroy = true;
            //Beep();
        }
    }
    
        
    /*
    void OnCollisionEnter(Collision collision){
        foreach (ContactPoint contact in collision.contacts){
            var colName = contact.thisCollider.name;
            switch (colName){
                case "collider1":
                    Beep();
                    break;
                case "collider2":
                    //Do something
                    break;
                case "collider3":
                    //Do something
                    break;
                case "collider4":
                    //Do something
                    break;
            }
        }
    }
    */

    
    /*
    void OnTriggerExit2D(Collider2D col)        //will trigger when object destroyed, note that.
    {
        //var collider1 = GetComponents<BoxCollider2D>()[0];
        var collider2 = GetComponents<BoxCollider2D>()[1];
        WaitForDestroy = false;
        HitCheckText.text = "MISS!";
        HitCheckText.color = Color.gray;
        //if (col.gameObject == BitToDestroy)
       // {
            Beep();
            Perfect = false;
        //}
    }
    */

    void Beep() {
        /*GetComponent<ChuckSubInstance>().BroadcastEvent("press");*/
        Instantiate(bitaudio, Vector2.zero, Quaternion.identity);
    }

}
