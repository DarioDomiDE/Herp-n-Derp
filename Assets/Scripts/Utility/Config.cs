using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Config : MonoBehaviour {

    // public 
    public const string ProjectId = "9e2cd999-3d3b-43d5-af05-994064767ead";

    // private
    private int points = 0;
    private int CurrentLevel = 0;
    private List<string> level = new List<string>();

    // Properties
    public int Points
    {
        get
        {
            return this.points;
        }
        set
        {
            this.points = value;
        }
    }

    public List<string> Level
    {
        get { return level; }
    }

    void Start()
    {
        // Config -> Level
        level.Add("Room1_Empty");
        level.Add("Room2a_Blocked");
        level.Add("Room2b_BlockedMore");
        level.Add("Room3_SmallerPath");
        level.Add("Room4_TheKey");
        level.Add("Room5a_Btn");
        level.Add("Room5b_Btn");
        level.Add("Room6_ButtonBlock");
        level.Add("Room7_Buttons_NEW");
        level.Add("Room8_Meal");
        level.Add("Room9_MealLava");
        level.Add("Room10_Buttons");
        level.Add("Room11_BtnsMealLava");
        level.Add("Room12_DoubleBtn");
        level.Add("Room13_CurveWay");
        level.Add("Room14_MealKeyBtn");
        level.Add("Room15_Ultimate");
        level.Add("endscreen");
    }


    // Getter / Setter
    public int GetCurrentLevel()
    {
        return this.CurrentLevel;
    }

    // Methods
    public void CurrentLevelToNext()
    {
        this.CurrentLevel++;
    }



}
