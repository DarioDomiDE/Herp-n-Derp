using UnityEngine;
using System.Collections;

public class TriggerHandler : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
	{
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.name=="Player" && transform.root.GetComponent<Item>().ShowBubble != null)
			transform.root.GetComponent<Item>().ShowBubble(true);
	}
	void OnTriggerExit(Collider other )
	{
		if(other.gameObject.name == "Player" && transform.root.GetComponent<Item>().ShowBubble != null)
			transform.root.GetComponent<Item>().ShowBubble(false);
	}
	

	
}
