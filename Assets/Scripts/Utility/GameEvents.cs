using UnityEngine;
using System.Collections;

public class GameEvents {

    private static GameEvents instance = null;
    public static GameEvents GetInstance()
    {
        if(instance == null)
            instance = new GameEvents();
        return instance;
    }

    public delegate void InputHandler();
    public event InputHandler OnKeyDown;

    public GameEvents()
    {
        UpdateManager manager = GameObject.FindGameObjectWithTag("Container").GetComponent<UpdateManager>();
        manager.OnUpdate += DoUpdate;
    }

	void DoUpdate () {

        if (Input.anyKeyDown)
        {
            if (OnKeyDown != null)
            {
                OnKeyDown();
            }
        }

	}

}
