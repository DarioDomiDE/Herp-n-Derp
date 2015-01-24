using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour 
{
	public GameObject players;
	public GameObject Area;
	public const float MinimumDistance = 1;
	public const float MaximumDistance = 7.5f;

	// Use this for initialization
	void Start() 
	{
		players = GameObject.Find("Herb_n_Derb");
		Area = GameObject.Find("CamArea");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 vec  = (players.transform.position - this.transform.position);
		float distance = vec.magnitude;
		this.gameObject.transform.forward = vec;
		if(distance < MinimumDistance)
			this.gameObject.transform.position -= ( vec * ( MinimumDistance - distance ) );
		else if(distance > MaximumDistance)
			this.gameObject.transform.position += ( vec * ( distance - MaximumDistance ) );

		
	}
}
