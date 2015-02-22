using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameEvents {

	private static GameEvents instance = null;
    public static GameEvents GetInstance()
    {
        Debug.Log("GetInstance()");
        Debug.Log(instance);

        if(instance == null)
            instance = new GameEvents();
        return instance;
    }

    /* Key Events */
    public delegate void InputHandler();
    public event InputHandler OnKey;
    public event InputHandler OnKeyDown;
    public delegate void KeyUpHandler(KeyCode key);
    public event KeyUpHandler OnKeyUp;
    private List<KeyCode> keyList = new List<KeyCode>();
    private KeyCode[] specialKeys;

    public GameEvents()
    {
        GameObject.FindGameObjectWithTag("SceneCrossContainer").GetComponent<UpdateManager>().OnUpdate += DoUpdate;

        specialKeys = new KeyCode[] {
                        KeyCode.UpArrow,
                        KeyCode.DownArrow,
                        KeyCode.LeftArrow,
                        KeyCode.RightArrow,
                        KeyCode.LeftControl,
                        KeyCode.LeftShift,
                        KeyCode.LeftAlt
                    };

    }

	void DoUpdate()
    {

        // Check if new Key was pressed, Special Keys are not possible with these check
        string str = Input.inputString;
        if(str != "")
        {
            str = str.ToUpper();
            foreach (char c in str)
            {
                KeyCode key = (KeyCode)System.Enum.Parse(typeof(KeyCode), c.ToString());
                if(!keyList.Contains(key))
                {
                    keyList.Add(key);
                }
            }
        }

        // Check Key still pressed
        if(Input.anyKey)
        {
            if (OnKey != null)
            {
                OnKey();
            }
        }

        // Check Key down
        if (Input.anyKeyDown)
        {
            if (OnKeyDown != null)
            {
                OnKeyDown();
            }
        }

        // Check Key Up
        for (int i = keyList.Count-1; i >= 0; i--)
        {
            KeyCode key = keyList[i];
            if (!Input.GetKey(key))
            {
                if (OnKeyUp != null)
                {
                    OnKeyUp(key);
                }
                keyList.Remove(key);
            }
        }

        // Check Arrow Key and Special Key Up
        foreach (var key in specialKeys)
        {
            if (Input.GetKeyUp(key))
            {
                OnKeyUp(key);
            }
        }

	}

}
