using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.IO;

public class GameManager1 : MonoBehaviour
{
    int Day = 0, Phase = 0, Pack = 1;
    bool GameIsPlaying = true;
    public bool LightReply = false;
    public TextMeshProUGUI Output;
    //public TextAsset textfile;

    public Card[] LeftDeck;
    public Card[] MiddleDeck;
    public Card[] RightDeck;
    public Events[] events;

    public ChooseCard chooseScript;

    void Start()
    {
        Day = 0;
        Pack = 1;
        Phase = 3;
        LightReply = true;
        
        //string text = textfile.text;
        //Debug.Log(text);
        
        /*
        string[] readText = File.ReadAllLines(@"D:\Unity\Journey to Nobility\Assets");
        foreach (string s in readText)
        {
            Debug.Log(s);
        }
        */
}

    void Update()
    {
        if (GameIsPlaying) // is game playing
        {
            if (Phase == 3 && LightReply) //if endturn, start new turn
            {
                LightReply = false;
                Phase = 1; //setup new day
                Day++;
                Output.text = "Day " + Day;
                //Pick Scenario



                //Present cards within Scenario
                chooseScript.LeftCard.GetComponent<CardDisplay>().card = LeftDeck[Day - 1];
                chooseScript.CenterCard.GetComponent<CardDisplay>().card = MiddleDeck[Day - 1];
                chooseScript.RightCard.GetComponent<CardDisplay>().card = RightDeck[Day - 1];
                Output.text = events[Day - 1].Text;
                Output.enabled = true;
                chooseScript.DisplayCards = true;
               
            }
            else if (Phase == 1)
            {
                Phase = 2;
                //Wait for player choice = true

            }
            else if (Phase == 2 && chooseScript.choiceMade == true)
            {
                Phase = 3;

                //Change the map/lighting to suit changes
                GetComponent<LightControl>().NewCycle();
                Output.enabled = false;
            }

        }
    }

    public void StartGame()
    {
        GameIsPlaying = true;
        /*
        LightControl l;
        l = GetComponent<LightControl>();
        l.enabled = true;
        */
    }


}
