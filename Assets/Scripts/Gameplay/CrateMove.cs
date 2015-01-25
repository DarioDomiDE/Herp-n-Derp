using UnityEngine;
using System.Collections;

public class CrateMove : MonoBehaviour 
{
	private Vector3 lastPosition;

	void Start() 
	{
		lastPosition = this.gameObject.transform.position;
	}
	

	void Update()
	{
		if(this.gameObject.transform.position!=lastPosition)
		{
			GameManager.sound.Play("Derp - Collision",1.0f);
			lastPosition = this.gameObject.transform.position;
		}
	}
}
