using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour 
{
	//[SerializeField]
	private float timer = 2000000;
	private bool counting = false;



	void Start() 
	{
	
	}

	public void TransfareToPoints()
	{
		counting = false;
		this.gameObject.GetComponent<Points>().AddPoints((int)timer);
	}

	public void StartTimerCounting()
	{
		counting = true;
	}

	void Update() 
	{
		timer -= Time.deltaTime;
		if(timer < 0)
        {
            GameObject.FindGameObjectWithTag("SceneBlender").GetComponent<SceneBlender>().FadeToScene("gameover");
        }

	}
}
