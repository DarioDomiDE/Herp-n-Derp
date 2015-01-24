using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private float Speed = 3.0f;
    private float SideSpeed = 1.0f;
    private float Angle = 180.0f;
    private float defaultTime = 0.3f;

    private bool isAllowed = true;
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
        if (isAllowed)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isAllowed = false;
                this.currentDirection = direction.right;
                this.TimeLeft = this.defaultTime;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isAllowed = false;
                this.currentDirection = direction.left;
                this.TimeLeft = this.defaultTime;
            }
        }
    }

    private void DoMovement()
    {
        if (isAllowed == false)
        {
            if (this.TimeLeft > 0)
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
            else
            {
                isAllowed = true;
            }
        }

    }



}
