using UnityEngine;
using System.Collections;

public class MushroomButton : Button 
{
	private float move;
	private float max,min;
	private float HEIGHT,scaleX,scaleZ;
	private float UP_DOWN;

	public bool IsAnimated = true;

	override protected void OnButtonStart()
	{
		UP_DOWN = PositionUp = 1;
		PositionDown = 0.1f;
		enable = false;
		HEIGHT = this.transform.localScale.y;
		scaleX = this.transform.localScale.x;
		scaleZ = this.transform.localScale.z;
		move = -0.005f * HEIGHT;
		max = HEIGHT * 1.1f;
		min = HEIGHT * 0.9f;
	}
	
	protected override void Update()
	{
		if(IsAnimated)
			animashrate();
	}

	private void animashrate()
	{
		HEIGHT += HEIGHT < min ? ( move = -move ) : HEIGHT > max ? ( move = -move ) : move;
		this.transform.localScale = new Vector3(scaleX, HEIGHT * UP_DOWN, scaleZ);
	}

	override protected void OnTriggerEnter(Collider other)
	{
		if(enable == false)
		{
			if(other.tag == "Player" || other.tag == "Crate")
			{
				IsAnimated = false;
				this.transform.localScale = new Vector3(scaleX, HEIGHT * (UP_DOWN = PositionDown), scaleZ);
				GameManager.door.AddPressedButton();
				enable = true;
				SoundManager.Instance.Play("Switch Down", 1.0f);
			}
		}
	}

	override protected void OnTriggerExit(Collider other)
	{
		if(stayDown == false)
		{
			if(other.tag == "Player" || other.tag == "Crate")
			{
				IsAnimated = true;
				this.transform.localScale = new Vector3(scaleX, HEIGHT * (UP_DOWN = PositionUp), scaleZ);
				GameManager.door.RemovePressedButton();
				enable = false;
			}
		}
	}
}
