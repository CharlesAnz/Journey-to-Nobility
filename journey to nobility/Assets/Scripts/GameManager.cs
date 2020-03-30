using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class GameManager : MonoBehaviour
{
    /*
    int Day = 0, Phase = 0, Pack = 1;
    bool GameIsPlaying = false;
    public TextMeshProUGUI Output;
    public TextAsset textfile;
    //public Deck Deck1;
    //public Scenario CurrentScenario;
    

    void Start()
    {
        Day = 0;
        Pack = 1;
        Phase = 3;

        //Create Deck 1
        Deck1 = new Deck();
        Deck1.Pile = new Scenario[5];
        for (int i = 0; i < 5; i++)
        {
            Scenario s = new Scenario();
            s.Id = i + 1;
            s.Description = "A challenge appears";
            Deck1.Pile[i] = s;
        }
        
        string text = textfile.text;
        Debug.Log(text);
        
        /*
        string[] readText = File.ReadAllLines(@"D:\Unity\Journey to Nobility\Assets");
        foreach (string s in readText)
        {
            Debug.Log(s);
        }
        

    void Update()
    {
        if (GameIsPlaying) // is game playing
        {
            if (Phase == 3) //if endturn, start new turn
            {
                Phase = 1; //setup new day
                Day++;
                Output.text = "Day " + Day;
                //Pick Scenario
                if (Day < 5)
                {
                    CurrentScenario = Deck1.Pile[Day];
                }
                //Present cards within Scenario

                //Wait for the player to choose Phase = 2

                //Once chosen, give feedback on results, do a check if need too Phase = 3

                //Change the map/lighting to suit changes
                GetComponent<LightControl>().NewCycle();
            }
        }
    }

    public void StartGame()
    {
        GameIsPlaying = true;
        LightControl l;
        l = GetComponent<LightControl>();
        l.enabled = true;
        }
        */
}
