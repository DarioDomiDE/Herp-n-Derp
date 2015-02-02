using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

    private GUIText PointContainerText;

    private int PointCounter
    {
        get { return GameManager.Config.Points; }
        set { GameManager.Config.Points = value; }
    }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("PointCounter");
        if(obj!= null)
        {
            this.PointContainerText = obj.GetComponent<GUIText>();
        }
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
