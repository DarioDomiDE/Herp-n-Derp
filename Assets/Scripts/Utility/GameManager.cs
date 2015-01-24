using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	public static Timer timer;
	public static SceneBlender blender;
	public static SoundManager sound;
	public static Door door;
	public static List<Item> items;

	// Use this for initialization
	void Start() 
	{
		timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
		blender = SceneBlender.Instance;
		sound = SoundManager.Instance;
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();
		items = new List<Item>();
		foreach(Item item in Component.FindObjectsOfType<Item>())
			items.Add(item);

		if(Points.Instance != null)
			Points.Instance.ChangeGUI();

	}
	
	public static void SetGameOver()
	{
		sound.Play("Derp_sad", 1.0f);
		blender.FadeToScene("gameover");
	}

	public static void SetGameWin()
	{
		sound.Play("Derp_happy", 1.0f);
		timer.TransfareToPoints();
		blender.FadeToScene("winscreen");
	}

	public static void SetNextLevel()
	{
		sound.Play("Derp_happy", 1.0f);
		timer.TransfareToPoints();
		blender.FadeNextScene();
	}



}
