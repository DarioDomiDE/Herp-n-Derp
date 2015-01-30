using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

    private int PointCounter = 0;

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
        GameObject.FindGameObjectWithTag("PointCounter").GetComponent<GUIText>().text = PointCounter.ToString() + " Points";
    }
	
}
