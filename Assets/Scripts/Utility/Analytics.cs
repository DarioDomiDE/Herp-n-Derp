using UnityEngine;
using System.Collections;
using UnityEngine.Cloud.Analytics;
using System.Collections.Generic;

public class Analytics : MonoBehaviour {

	// Use this for initialization
	void Start () {
        UnityAnalytics.StartSDK(Config.ProjectId);

        //UnityAnalytics.SetLogLevel(LogLevel.Info);

        int totalPotions = 5;
        int totalCoins = 100;
        UnityAnalytics.CustomEvent("gameOver", new Dictionary<string, object>
        {
            { "potions", totalPotions },
            { "coins", totalCoins }
        });


        SexEnum gender = SexEnum.M;
        UnityAnalytics.SetUserGender(gender);

        int birthYear = 2014;
        UnityAnalytics.SetUserBirthYear(birthYear);

        UnityAnalytics.Transaction("12345abcde", 0.99m, "USD", null, null);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
