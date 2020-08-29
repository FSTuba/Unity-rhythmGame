using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;



public class PlayMusic : MonoBehaviour {
    ChuckSubInstance myChuck;
    Chuck.VoidCallback noteonEventCallback;
    Chuck.VoidCallback noteon2EventCallback;
    public static bool trigger = false;
    public static bool trigger2 = false;

    //public TextAsset TextFile;
    //string Data;
    string[] SongArray;
    int Song_num;


    bool tmp;

    void Start () {
        //Data = TextFile.text;
        //SongArray = Data.Replace("\r","").Replace(" ", "").Replace("\n", " ").Split(' ');
        SongArray = Global.SongArray;

        tmp = GameControl.IsPause;
        myChuck = GetComponent<ChuckSubInstance>();
        myChuck.RunCode(@"
            global Event noteon;
            global Event noteon2;
            global Event PauseEvent;
            MidiFileIn min;
            int IsPause;
            0 => IsPause;
            min.open(me.dir() + """ + SongArray[Global.Song] +  @""" +"".mid"");      //read midi file
            
            2::second => now;
            int done;
            for (int i; i < min.numTracks(); i++){       //spork track
                spork ~track(i);
            }
            spork ~PauseControl();

            while (done < min.numTracks()){
                1::second => now;
            }
            min.close();

            fun void track(int t){
                MidiMsg midimsg;
                Rhodey Rhod[10];
                DelayL delay[10];
                for (int i; i < 10; i++){
                    Rhod[i] => delay[i] => dac;
                    1.887::second => delay[i].max => delay[i].delay; 
                    //0.5 => Rhod[i].gain;
                }
                int v;
                while (min.read(midimsg, t)){
                    if (midimsg.when > 0::second){
                        midimsg.when => now;
                    }
                    if ((midimsg.data1 & 0xF0) == 0x90 && midimsg.data2 > 0 && midimsg.data3 > 0){
                        midimsg.data2 => Std.mtof => Rhod[v].freq;
                        midimsg.data3 / 127.0 => Rhod[v].noteOn;
                        if(t==0){
                            noteon.broadcast();
                        }
                        if(t==1){
                            noteon2.broadcast();
                        }
                        
                        
                    }
                    v++;
                    10 %=> v;
                }  
                2::second => now;
                done++;
            }
                fun void PauseControl(){
                    while(PauseEvent => now){
                        !IsPause => IsPause;
                    }
                }
        ");
        /*
        GetComponent<ChuckSubInstance>().RunCode(@"
            SndBuf buf => Gain g => dac;
            global Event press;
            me.dir() + ""data/hihat.wav"" => buf.read;
            1 => g.gain;
            while(press => now){
                0 => buf.pos;
                100::ms => now;
            }
        ");
        */
        noteonEventCallback = myChuck.CreateVoidCallback(React);
        myChuck.StartListeningForChuckEvent("noteon", noteonEventCallback);
        noteon2EventCallback = myChuck.CreateVoidCallback(React2);
        myChuck.StartListeningForChuckEvent("noteon2", noteon2EventCallback);
    }

    void React() {
        trigger = true;
    }
    void React2()
    {
        trigger2 = true;
    }


    // Update is called once per frame
    void Update () {
        if (tmp != GameControl.IsPause) {
            tmp = GameControl.IsPause;
            GetComponent<ChuckSubInstance>().BroadcastEvent("PauseEvent");
        }
        
    }
}
