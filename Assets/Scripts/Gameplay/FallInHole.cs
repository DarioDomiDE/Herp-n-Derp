using UnityEngine;
using System.Collections;

public class FallInHole : MonoBehaviour 
{
	
	// Use this for initialization
	void Start() 
	{
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			GameManager.SetGameOver();
		}
	}


}
