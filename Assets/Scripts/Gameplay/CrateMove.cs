using UnityEngine;
using System.Collections;

public class CrateMove : MonoBehaviour 
{
	private Vector3 lastPosition;
	private float timer = 0;
	void Start() 
	{
		lastPosition = this.gameObject.transform.position;
	}
	

	void Update()
	{
		bool timerDown;
		timer = (timerDown = timer > 0 )? timer - Time.deltaTime : 0;
		if(this.gameObject.transform.position!=lastPosition)
		{
			timer = timerDown? GameManager.sound.Play("Derp_collision", 0.3f):0;
			lastPosition = this.gameObject.transform.position;
		}
	}
}
