using UnityEngine;
using System.Collections;

public class Introscreen : MonoBehaviour {

	
	void Update () {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.UpArrow))
        {
            Application.LoadLevel("scenenoody");
        }
	}
}
