using UnityEngine;
using System.Collections;

public class SwirlyTwirly : MonoBehaviour {

	private float angle=0;
	public float speed = 10;
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update() 
	{
		angle = speed * Time.deltaTime;
		transform.Rotate(new Vector3(0,0,-1),angle,Space.World);
	}
}
