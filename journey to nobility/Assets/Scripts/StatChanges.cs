using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatChanges : MonoBehaviour
{


    public GameObject nobility, wealth, honor, favor, resources, might;

    public GameObject wealthDisplay, honorDisplay, favorDisplay, resourceDisplay, mightDisplay;
    public int nobilitystat, wealthstat, honorstat, favorstat, resourcestat, mightstat;


    // Start is called before the first frame update
    void Start()
    {
        wealthstat = 50;
        honorstat = 50;
        favorstat = 50;
        resourcestat = 50;
        mightstat = 50;

        nobilitystat = wealthstat + honorstat + favorstat + resourcestat + mightstat;

    }

    // Update is called once per frame
    void Update()
    {
        nobilitystat = wealthstat + honorstat + favorstat + resourcestat + mightstat;

        nobility.GetComponent<Text>().text = "Nobility: " + nobilitystat;

        wealth.GetComponent<Text>().text = "Wealth: " + wealthstat;
        honor.GetComponent<Text>().text = "Honor: " + honorstat;
        favor.GetComponent<Text>().text = "Favor: " + favorstat;
        resources.GetComponent<Text>().text = "Resource: " + resourcestat;
        might.GetComponent<Text>().text = "Might: " + mightstat;

    }

    public void Consequences(int money, int likeness, int approval, int land, int military)
    {
        wealthstat = wealthstat + money;
        honorstat = honorstat + likeness;
        favorstat = favorstat + approval;
        resourcestat = resourcestat + land;
        mightstat = mightstat + military;

        nobilitystat = wealthstat + honorstat + favorstat + resourcestat + mightstat;

        if (money > 0) wealthDisplay.GetComponent<Text>().text = "wealth: +" + money;
        else wealthDisplay.GetComponent<Text>().text = "wealth: " + money;
        if (likeness > 0) honorDisplay.GetComponent<Text>().text = "honor: +" + likeness;
        else honorDisplay.GetComponent<Text>().text = "honor: " + likeness;
        if (approval > 0) favorDisplay.GetComponent<Text>().text = "favor: +" + approval;
        else favorDisplay.GetComponent<Text>().text = "favor: " + approval;
        if (land > 0) resourceDisplay.GetComponent<Text>().text = "resources: +" + land;
        else resourceDisplay.GetComponent<Text>().text = "resources: " + land;
        if (military > 0) mightDisplay.GetComponent<Text>().text = "might: +" + military;
        else mightDisplay.GetComponent<Text>().text = "might: " + military;
    }
}
