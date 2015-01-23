using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float Speed = 2.0f;
    public float SideSpeed = 1.0f;
    public float Angle = 90.0f;
    public float defaultTime = 0.5f;

    private float TimeLeft = 0;
    private enum direction
    {
        none = 0,
        left = -1,
        right = 1
    }
    private direction currentDirection = direction.none;

	void Start ()
    {
        GameEvents.GetInstance().OnKeyDown += this.DoInput;
	}
	
	void Update () {
        DoMovement();
	}

    void DoInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.currentDirection = direction.left;
            this.TimeLeft = this.defaultTime;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.currentDirection = direction.right;
            this.TimeLeft = this.defaultTime;
        }
    }

    private void DoMovement()
    {
        if(this.TimeLeft > 0)
        {
            this.TimeLeft -= Time.deltaTime;

            Vector3 pos = Vector3.zero;
            pos += this.transform.forward * this.Speed;
            pos += this.transform.right * this.SideSpeed * (int)this.currentDirection;
            pos *= Time.deltaTime;
            pos += this.transform.position;
            this.transform.position = pos;

            this.transform.Rotate(new Vector3(0, 1.0f * (int)this.currentDirection, 0), Angle * Time.deltaTime);
        }

    }

    private void GoLeftForward()
    {
    }

    private void GoLeftBackward()
    {
    }



}
