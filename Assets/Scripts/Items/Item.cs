using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public enum status
    {
        singlePress,
        longPressed
    }
    public status itemStatus = status.singlePress;
	public Vector2 TextPosition
	{
		get;

		private set;
	
	}

	void Start () 
	{
	
	}
	
	void Update () 
	{
		TextPosition = Camera.main.WorldToScreenPoint(this.transform.position);
	
	}
}
