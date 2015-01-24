using UnityEngine;
using System.Collections;

public class SceneBlender : MonoBehaviour 
{
	private bool _blend = false;
	[SerializeField]
	private bool blend = false;
	public bool Blend
	{
		get { return _blend; }
		set
		{
			if(value != _blend)
			{
				if(value)
					startBlending();
				blend =_blend = value;
			}
			blend = _blend;
		}
	}

	public enum STATE : int
	{
		OUT = -2,
		IN = -1,
		Ready=0,
		Fading_Out=1,
		Fading_In=2,
	}
	public STATE state = STATE.IN;
	public GUITexture spot;
	private Vector2  MAX_SCALE = new Vector3(15, 15);
	private Vector2 MAX_POSITION = new Vector3(0.5f, 0.5f);
	[SerializeField]
	private Vector2 targetPosition,currentPosition,startPosition,targetScale,startScale;
	[SerializeField]
	private float timer = 0;
	[SerializeField]
	private float FadeTime;

	void Start() 
	{
		FadeTime = 2;
		timer = 0;
		transform.localScale = MAX_SCALE;
	}
	
	void startBlending()
	{
		if(state < STATE.Ready)
		{
			
			startPosition = transform.position;
			startScale = transform.localScale;
	//		FadeTime = timer = time;
	//		targetPosition = position;
			targetScale = state == STATE.OUT ? MAX_SCALE : new Vector2(1, 1);
			state = (state == STATE.IN) ? STATE.Fading_Out : STATE.Fading_In;
		}
	}

	private bool animate()
	{
		if(state > STATE.Ready)
		{
			currentPosition = Vector2.Lerp(startPosition, targetPosition, timer / FadeTime);
			this.gameObject.transform.localScale = Vector2.Lerp(startScale, targetScale, timer / FadeTime);


			if(( timer += Time.deltaTime ) >= FadeTime)
			{
				timer = 0;
				state -= 3;
			}

			return true;
		}
		return false;
	}

	void Update() 
	{
		Blend = blend;
		Blend = animate();
	}
}
