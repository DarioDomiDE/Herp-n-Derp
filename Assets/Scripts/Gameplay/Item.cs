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

    public void Pickup()
    {
        //this.transform.Find("Bubble").GetComponent<MeshRenderer>().enabled = false;
    }

    public void Drop()
    {
        //this.transform.Find("Bubble").GetComponent<MeshRenderer>().enabled = true;
    }

}
