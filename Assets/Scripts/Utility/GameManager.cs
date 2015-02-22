using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
    private static bool IsLevelOver = false;
	public static Timer timer;
	public static SceneBlender blender;
	public static SoundManager sound;
	public static Door door;
	public static List<Item> items;
    public static Points points;
    public static Config Config;
    public static SceneConfig SceneConfig;

    void Awake()
    {
		timer = GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>();
        door = GameObject.FindGameObjectWithTag("Door").GetComponent<Door>();
		items = new List<Item>();
		foreach(Item item in Component.FindObjectsOfType<Item>())
			items.Add(item);
        points = GameObject.FindGameObjectWithTag("SceneCrossContainer").GetComponent<Points>();
        Config = GameObject.FindGameObjectWithTag("SceneCrossContainer").GetComponent<Config>();
        SceneConfig = GameObject.FindGameObjectWithTag("Container").GetComponent<SceneConfig>();
    }

    // Use this for initialization
    void Start()
    {
        blender = SceneBlender.Instance;
        sound = SoundManager.Instance;
        IsLevelOver = false;
        if (points != null)
        {
            points.Initialize();
            points.ChangeGUI();
        }
	}
	
	public static void SetGameOver()
	{
		if(!IsLevelOver)
		{
            IsLevelOver = true;
            sound.Play("Derp_sad", 1.0f);

            DoEndLevel("gameover");

		}
	}

	public static void SetGameWin()
	{
        if (!IsLevelOver)
        {
            IsLevelOver = true;
            sound.Play("Derp_happy", 1.0f);

            DoEndLevel("winscreen");

        }
	}

	public static void SetNextLevel()
	{
        GameManager.Config.CurrentLevelToNext();
        sound.Play("Derp_happy", 1.0f);

        DoEndLevel(GetNextLevelName());
	}

    private static void DoEndLevel(string level)
    {
        // tmp -> disable movement
        GameObject.FindGameObjectWithTag("SceneCrossContainer").GetComponent<Movement>().Destruct();


        timer.StopTimerCounting();
        timer.TransfareToPoints();
        blender.FadeToScene(level);
    }

    private static string GetNextLevelName()
    {
        string level = GameManager.Config.Level[GameManager.Config.GetCurrentLevel()];
        if (level != null)
        {
            return level;
        }
        return "winscreen";
    }



}
