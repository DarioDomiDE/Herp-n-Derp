using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

    private GUIText PointContainerText;

    private int PointCounter
    {
        get { return GameManager.config.Points; }
        set { GameManager.config.Points = value; }
    }

    void Start()
    {
        this.PointContainerText = GameObject.FindGameObjectWithTag("PointCounter").GetComponent<GUIText>();
    }

	public void AddPoints(int points)
	{
		PointCounter += points;
        ChangeGUI();
	}

    public int GetPoints()
    {
        return this.PointCounter;
    }

    public void ResetPoints()
    {
        this.PointCounter = 0;
    }

    public void ChangeGUI()
    {
        PointContainerText.text = PointCounter.ToString() + " Points";
    }
	
}
