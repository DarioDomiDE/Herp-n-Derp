﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneBlender : MonoBehaviour 
{

    public int currentLevel = 0;
    private bool enable = true;

	public enum STATE : int
	{
		OUT = -2,
		IN = -1,
		Ready=0,
		Fading_Out=1,
		Fading_In=2,
	}

	private string LoadNextScene = "";
	private static SceneBlender _instance = null;
	public static SceneBlender Instance
	{
		get { return _instance; }
	}
	public bool FadeInAtStart;
	public bool IsActive
	{
		get
		{
			return ( Spot.gameObject.guiTexture.enabled && Black.gameObject.guiTexture.enabled );
		}
		set
		{
			Spot.gameObject.guiTexture.enabled = value;
			Black.gameObject.guiTexture.enabled = value;
		}
	}
	[SerializeField]
	private STATE _state = STATE.IN;
	public STATE state
	{
		get { return _state; }
		private set { _state = value; }
	}
	private GUITexture Spot;
	private GUITexture Black;
	[SerializeField]
	private Vector2  MAX_SCALE;
	private Vector2 targetPosition,startPosition,targetScale,startScale;
	private float targetAlpha,startAlpha,timer;
	public float FadeTime;
	private float alpha
	{
		get 
		{ 
			return Black.color.a; 
		}
		set 
		{ 
			Color col = Black.color;
			col.a = value;
			Black.color = col;
		}
	}
	[SerializeField]
	private GameObject targetObject;

	void Awake()
	{
		if(_instance == null)
			_instance = this;
	}

	void Start()
	{
		LoadNextScene = "";
		if(targetObject == null)
			SetTarget(GameObject.FindGameObjectWithTag("Player"));
		timer = 0;
		for(int i=0; i < 2; i++)
		{
			if(this.gameObject.transform.GetChild(i).name == "Spot")
				Spot  = this.gameObject.transform.GetChild(i).gameObject.GetComponent<GUITexture>();
			if(this.gameObject.transform.GetChild(i).name == "Black")
				Black = this.gameObject.transform.GetChild(i).gameObject.GetComponent<GUITexture>();
		}
		Spot.transform.position = new Vector3(0.5f,0.5f,0);
		Spot.transform.localScale = MAX_SCALE;
		IsActive = true;
		if(FadeInAtStart)
		{
			alpha = 0.6f;
			state = STATE.OUT;
			FadeIn();
		}




	}

	public void SetTarget(GameObject TargetObject)
	{
		targetObject = TargetObject;
	}

	public void FadeOut()
	{
		if(state == STATE.IN)
			startBlending();
	}
	public void FadeOut(float fadingTime)
	{
		FadeTime = fadingTime;
		FadeOut();
	}

    /*public void FadeToScene(string Scene)
    {
        Fade(Scene);
    }

	public void FadeNextScene()
    {
        Fade(GetNextScene());
	}*/

    public void FadeToScene(string Scene)
    {
        if (enable)
        {
            enable = false;
            Instance.FadeInAtStart = true;
            Instance.LoadNextScene = Scene;
            Instance.FadeOut();
        }
    }

	public void FadeIn()
	{
		if(state == STATE.OUT)
			startBlending();
	}
	public void FadeIn(float fadingTime)
	{
		FadeTime = fadingTime;
		FadeIn();
	}

	private void startBlending()
	{
		if(state < STATE.Ready)
		{
			targetPosition = Camera.main.WorldToScreenPoint(targetObject.transform.position);
			targetPosition.x = targetPosition.x / Screen.width;
			targetPosition.y = targetPosition.y / Screen.height;
			startScale = Spot.transform.localScale;

			if(state == STATE.OUT)
			{
				startPosition = (Vector2)Spot.transform.position;
				targetScale = MAX_SCALE;
				targetAlpha = 0;
				state = STATE.Fading_In;
			}
			else if(state == STATE.IN)
			{
				startPosition = new Vector2(0.5f,0.5f);
				targetScale = new Vector2(1, 1);
				targetAlpha = 0.6f;
				state = STATE.Fading_Out;
			}

			startAlpha = 0.5f - targetAlpha;
		}
	}

	private bool animate()
	{
		if(state > STATE.Ready)
		{
			float lerp;
			if(( timer += Time.deltaTime ) < FadeTime)
			{
				lerp = timer / FadeTime;
				if(lerp < 0.8f)
				{
					Spot.transform.position = Vector2.Lerp(startPosition, targetPosition, lerp * 1.25f);
					Spot.transform.localScale = Vector2.Lerp(startScale, targetScale, lerp * 1.25f);
				}

				alpha = Mathf.Lerp(startAlpha, targetAlpha,  lerp  );
			}
			else
			{
				timer = 0;
				state -= 3;
			}
			return true;
		}
		else if (LoadNextScene != "")
        {
            Application.LoadLevel(LoadNextScene);
        }

		return false;
	}

	void Update() 
	{
		animate();
	}
}
