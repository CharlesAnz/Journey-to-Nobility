using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CardDisplay : MonoBehaviour
{

    public Text nameText;
    public Text descriptionText;
    public Text outcome;
    public bool bad = false;
    public Card card;
    // Start is called before the first frame update
    void Update()
    {
    
        descriptionText.text = card.description;
        if (bad) outcome.text = card.outcome2;
        else outcome.text = card.outcome;
    }
}
