using UnityEngine;
using System.Collections;

public class Screens : MonoBehaviour {

    public GameObject button1;
    public GameObject button2;
    public GameObject GUI;

    void Start()
    {
        if(GUI != null)
        {
            Points pointsComp = GameObject.FindGameObjectWithTag("PointContainer").GetComponent<Points>();
            int points = pointsComp.GetPoints();
            GUI.GetComponent<GUIText>().text = "Points: " + points.ToString();
            pointsComp.ResetPoints();
        }
    }

	void Update () {

        if (Input.GetKeyDown(KeyCode.W))
        {
            button1.GetComponent<MeshRenderer>().enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            button2.GetComponent<MeshRenderer>().enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            button1.GetComponent<MeshRenderer>().enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            button2.GetComponent<MeshRenderer>().enabled = false;
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.UpArrow))
        {
            Application.LoadLevel("Room1_Empty");
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
