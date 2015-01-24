using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour 
{
	public GameObject players;
	public GameObject Area;
	public const float MinimumDistance = 1;
	public const float MaximumDistance = 7.5f;

	void Start() 
	{
        players = GameObject.FindGameObjectWithTag("Player");
		Area = GameObject.Find("CamArea");
	}
	
	void Update () 
	{
        /*Vector3 vec  = (players.transform.position - this.transform.position);
        float distance = vec.magnitude;
        this.gameObject.transform.forward = vec;
        if(distance < MinimumDistance)
            this.gameObject.transform.position -= ( vec * ( MinimumDistance - distance ) );
        else if(distance > MaximumDistance)
            this.gameObject.transform.position += ( vec * ( distance - MaximumDistance ) );
        */

    }
}
