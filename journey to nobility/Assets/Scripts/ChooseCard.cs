using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class ChooseCard : MonoBehaviour
{
    // Normal raycasts do not work on UI elements, they require a special kind
    GraphicRaycaster raycaster;
    public Text descriptionBoxWar;
    public Text descriptionBoxMoney;
    public Text descriptionBoxPeace;

    public Text OutcomeWar;
    public Text OutcomeMoney;
    public Text OutcomePeace;

    public GameObject LeftCard;
    public GameObject CenterCard;
    public GameObject RightCard;

    public bool choiceMade;

    public int Phase;
    public bool DisplayCards;

    //public StatChanges StatScript;

    //public TextMeshProUGUI EventText;
   // public Events[] MyEvents;
    void Awake()
    {
        // Get both of the components we need to do this
        this.raycaster = GetComponent<GraphicRaycaster>();
        OutcomeWar.enabled = false;
        OutcomeMoney.enabled = false;
        OutcomePeace.enabled = false;

        choiceMade = false;
        Phase = 3;
    }

    void Update()   
    {
        choiceMade = false;
        //EventText.text = MyEvents[0].Text;
        //Check if the left Mouse button is clicked
        if (Input.GetKeyDown(KeyCode.Mouse0) && Phase < 3)
        {
            //Set up the new Pointer Event
            PointerEventData pointerData = new PointerEventData(EventSystem.current);
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mo   use click position
            pointerData.position = Input.mousePosition;
            this.raycaster.Raycast(pointerData, results);

            Debug.Log("Clicked");

            if (Phase == 1)
            {
                //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
                foreach (RaycastResult result in results)
                {
                    Debug.Log("Hit " + result.gameObject.name);
                    if (result.gameObject.name == "Card Right")
                    {
                        descriptionBoxPeace.enabled = false;
                        OutcomePeace.enabled = true;
                        CenterCard.SetActive(false);
                        LeftCard.SetActive(false);
                        //StatScript.wealth = StatScript.wealth + WarCard.GetComponent<CardDisplay>().card.wealth;
                        //GetComponent<StatChanges>().wealthstat = GetComponent<StatChanges>().wealthstat + WarCard.GetComponent<CardDisplay>().card.wealth;
                        CardDisplay c = RightCard.GetComponent<CardDisplay>();
                        if (c.card.testStat == true)
                        {
                            CardCheck(c);
                        }
                        else
                        {
                            GetComponent<StatChanges>().Consequences(c.card.wealth, c.card.honor, c.card.favor, c.card.resources, c.card.might);
                        }
                        Phase++;
                    }
                    else if (result.gameObject.name == "Card Center")
                    {
                        descriptionBoxMoney.enabled = false;
                        OutcomeMoney.enabled = true;
                        LeftCard.SetActive(false);
                        RightCard.SetActive(false);
                        CardDisplay c = CenterCard.GetComponent<CardDisplay>();
                        if (c.card.testStat == true)
                        {
                            CardCheck(c);
                        }
                        else
                        {
                            GetComponent<StatChanges>().Consequences(c.card.wealth, c.card.honor, c.card.favor, c.card.resources, c.card.might);
                        }
                        Phase++;
                    }
                    else if (result.gameObject.name == "Card Left")
                    {
                        descriptionBoxWar.enabled = false;
                        OutcomeWar.enabled = true;
                        CenterCard.SetActive(false);
                        RightCard.SetActive(false);
                        CardDisplay c = LeftCard.GetComponent<CardDisplay>();
                        if (c.card.testStat == true)
                        {
                            CardCheck(c);
                        }
                        else
                        {
                            GetComponent<StatChanges>().Consequences(c.card.wealth, c.card.honor, c.card.favor, c.card.resources, c.card.might);
                        }

                        Phase++;
                    }
                }
            }

            else if (Phase == 2)
            {
                Phase++;
                choiceMade = true;
                CardsHide();

                Debug.Log("We are in Phase 2 god damn it");
            }
        }

        if (Phase == 3 && DisplayCards == true)
        {
            CardsReset();
        }

    }


    public void CardsReset()
    {
        LeftCard.SetActive(true);
        CenterCard.SetActive(true);
        RightCard.SetActive(true);

        LeftCard.GetComponent<CardDisplay>().bad = false;
        CenterCard.GetComponent<CardDisplay>().bad = false;
        RightCard.GetComponent<CardDisplay>().bad = false;

        OutcomeWar.enabled = false;
        OutcomeMoney.enabled = false;
        OutcomePeace.enabled = false;
        
        descriptionBoxMoney.enabled = true;
        descriptionBoxWar.enabled = true;
        descriptionBoxPeace.enabled = true;

        Phase = 1;
        DisplayCards = false;


    }

    public void CardsHide()
    {
        LeftCard.SetActive(false);
        CenterCard.SetActive(false);
        RightCard.SetActive(false);
    }

    public void CardCheck(CardDisplay c)
    {

        if (c.card.mightcheck > GetComponent<StatChanges>().mightstat || c.card.wealthcheck > GetComponent<StatChanges>().wealthstat
            || c.card.honorcheck > GetComponent<StatChanges>().honorstat || c.card.favorcheck > GetComponent<StatChanges>().favorstat
            || c.card.resourcescheck > GetComponent<StatChanges>().resourcestat)
        {
            c.bad = true;
            GetComponent<StatChanges>().Consequences(c.card.wealth2, c.card.honor2, c.card.favor2, c.card.resources2, c.card.might2);

        }
        else
        {
            GetComponent<StatChanges>().Consequences(c.card.wealth, c.card.honor, c.card.favor, c.card.resources, c.card.might);
        }

    }
}
