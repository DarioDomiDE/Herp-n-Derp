using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public bool stayDown = true;
    private float PositionUp = 0.15f;
    private float PositionDown = -0.15f;

	void Start () {
	    
	}
	
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" || other.tag == "Crate")
        {
            this.transform.position = this.transform.position + new Vector3(0, PositionDown, 0);
            //GameMaster.Door.AddPressedButton();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (stayDown == false)
        {
            if (other.tag == "Player" || other.tag == "Crate")
            {
                this.transform.position = this.transform.position + new Vector3(0, PositionUp, 0);
                //GameMaster.Door.RemovePressedButton();
            }
        }
    }

}
