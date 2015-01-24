using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    public bool stayDown = true;
    private float PositionUp = 0.15f;
    private float PositionDown = -0.15f;
    private bool enable = false;

	void Start () {
	    
	}
	
	void Update () {
	    
	}

    void OnTriggerEnter(Collider other)
    {
        if (enable == false)
        {
            if (other.tag == "Player" || other.tag == "Crate")
            {
                this.transform.position = this.transform.position + new Vector3(0, PositionDown, 0);
                GameManager.door.AddPressedButton();
                enable = true;
                SoundManager.Instance.Play("Switch Down", 1.0f);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (stayDown == false)
        {
            if (other.tag == "Player" || other.tag == "Crate")
            {
                this.transform.position = this.transform.position + new Vector3(0, PositionUp, 0);
                GameManager.door.RemovePressedButton();
                enable = false;
            }
        }
    }

}
