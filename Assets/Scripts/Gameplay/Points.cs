using UnityEngine;
using System.Collections;

public class Points : MonoBehaviour {

    public int PointCounter = 0;

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
        ChangeGUI();

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

	public void AddPoints(int points)
	{
		PointCounter = points;
        ChangeGUI();
	}

    private void ChangeGUI()
    {
        GameObject.FindGameObjectWithTag("PointCounter").GetComponent<GUIText>().text = PointCounter.ToString();
    }
	
}
