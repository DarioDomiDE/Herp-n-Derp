using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public enum status
    {
        singlePress,
        longPressed
    }
    public status itemStatus = status.singlePress;

	void Start () 
	{
	}
	
	void Update () 
	{
	}

}
