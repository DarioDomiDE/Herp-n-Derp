using UnityEngine;
using System.Collections;

public class UpdateManager : MonoBehaviour {

    public delegate void InputHandler();
    public event InputHandler OnUpdate;

	void Update ()
    {
        if(Input.anyKey || Input.anyKeyDown)
        {
            if (OnUpdate != null)
            {
                OnUpdate();
            }
        }
	}

}
