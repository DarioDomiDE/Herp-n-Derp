using UnityEngine;
using System.Collections;

public class Bubble : MonoBehaviour 
{

	// Use this for initialization
	void Awake() 
	{
		transform.root.gameObject.GetComponent<Item>().ShowBubble = SetVisible;
		//if(renderer.enabled)
		//	this.transform.right = ( Camera.main.transform.position - this.transform.position );
	}

	void SetVisible(bool visible)
	{
		this.renderer.enabled = visible;
	}
}
