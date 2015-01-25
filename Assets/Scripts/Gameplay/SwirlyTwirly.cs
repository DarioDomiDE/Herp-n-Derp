using UnityEngine;
using System.Collections;

public class SwirlyTwirly : MonoBehaviour {

	private float angle=0;
	public float speed = 10;
	private Vector3 scaler = new Vector3(1,1,1);

	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update() 
	{
		angle = speed * Time.deltaTime;
		transform.GetChild(0).Rotate(new Vector3(0,1,0),angle);
		transform.localScale = scaler;
	}
}
