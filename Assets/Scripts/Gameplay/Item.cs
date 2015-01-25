using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	protected internal delegate void BubbleSwitch(bool show);
	protected internal BubbleSwitch ShowBubble;

    public enum status
    {
        singlePress,
        longPressed
    }
    public status itemStatus = status.singlePress;

	void Start() 
	{
		Pickup();
	}



    public void Pickup()
    {
		if(ShowBubble != null)
			ShowBubble(false);
    }

    public void Drop()
    {
		if(ShowBubble != null)
			ShowBubble(true);
    }

}
