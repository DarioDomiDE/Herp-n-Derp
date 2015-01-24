using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	private float timer = 0;
	private bool counting = false;
    [SerializeField]
    private int startValue = 20;
    private int currentGUIValue = 0;

	void Start() 
	{
        //GameObject.FindGameObjectWithTag("Container").GetComponent<UpdateManager>().OnUpdate += DoUpdate;
        StartTimerCounting();
	}

	public void TransfareToPoints()
	{
        counting = false;
        GameObject.FindGameObjectWithTag("Container").GetComponent<Points>().AddPoints((int)timer);
	}

	public void StartTimerCounting()
	{
        ChangeGUI(startValue);
        timer = startValue;
        counting = true;
	}

	void Update() 
	{
		timer -= Time.deltaTime;
        int timerSec = (int)timer;
        if (timerSec != currentGUIValue)
        {
            ChangeGUI(timerSec);
        }
		if(timer < 0)
        {
            TransfareToPoints();
            GameObject.FindGameObjectWithTag("SceneBlender").GetComponent<SceneBlender>().FadeToScene("gameover");
            SoundManager.Instance.Play("Derp_sad", 1.0f);
        }

	}

    private void ChangeGUI(int sec)
    {
        if (sec < 0)
            sec = 0;
        currentGUIValue = sec;
        this.GetComponent<GUIText>().text = sec.ToString();
    }

}
