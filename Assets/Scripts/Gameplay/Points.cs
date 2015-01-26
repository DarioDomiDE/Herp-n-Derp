using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

    private int PointCounter = 0;

    private static Points _instance = null;
    public static Points Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
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
        GameObject.FindGameObjectWithTag("PointCounter").GetComponent<GUIText>().text = PointCounter.ToString() + " Points";
    }
	
}
