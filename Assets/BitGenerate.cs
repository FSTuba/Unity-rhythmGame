using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitGenerate : MonoBehaviour
{
    public GameObject Bit;
    public GameObject Bit2;
    float time;
    float time2;
    public float speed;
    float[] limitlist = { 58, 27, 3 };
    float tmp;


    void Start()
    {
        speed = 132;
        tmp = limitlist[Global.Difficulty] / speed;

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        time2 += Time.deltaTime;

        if (PlayMusic.trigger)
        {
            PlayMusic.trigger = false;
            if (time >= (tmp))
            {     //limit of generate speed
                time = 0;

                // time += Time.deltaTime;
                //if (SheetArray[SheetPointer] != "E")
                // {
                // BitLenth = float.Parse(SheetArray[SheetPointer]);
                // if (time >= (15f * BitLenth / speed))
                // {
                Vector3 pos = new Vector3(10, 2.5f, 0);
                Instantiate(Bit, pos, transform.rotation);
                // time = 0f;
                //  SheetPointer++;

                // }
                //}
            }
        }
        if (PlayMusic.trigger2 && (Global.Player == 1))
        {
            PlayMusic.trigger2 = false;
            if (time2 >= (tmp))
            {     //limit of generate speed
                time2 = 0;
                Vector3 pos = new Vector3(10, -2.25f, 0);
                Instantiate(Bit2, pos, transform.rotation);
            }
        }
    }
}

