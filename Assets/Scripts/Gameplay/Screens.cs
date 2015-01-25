using UnityEngine;
using System.Collections;

public class Screens : MonoBehaviour {

    public GameObject button1;
    public GameObject button2;

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
	}
}
