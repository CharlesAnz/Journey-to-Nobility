using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public new string name;
    public string description;
    public string outcome;
    public string outcome2;

    public int wealth;
    public int honor;
    public int favor;
    public int resources;
    public int might;

    public int wealth2;
    public int honor2;
    public int favor2;
    public int resources2;
    public int might2;

    public bool testStat = false;

    public int wealthcheck;
    public int honorcheck;
    public int favorcheck;
    public int resourcescheck;
    public int mightcheck;
}
