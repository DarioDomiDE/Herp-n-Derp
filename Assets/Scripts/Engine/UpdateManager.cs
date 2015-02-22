using UnityEngine;
using System.Collections;

public class UpdateManager : MonoBehaviour {

    public delegate void InputHandler();
    public event InputHandler OnUpdate;

	void Update ()
    {

        if (OnUpdate != null)
        {
            OnUpdate();
        }
	}

}
