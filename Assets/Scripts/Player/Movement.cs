using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private float Speed = 3.0f;
    private float SideSpeed = 1.0f;
    private float Angle = 200.0f;
    private float defaultTime = 0.3f;
	private float groundHeight = 0;
	private bool falling = false;
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
        //GameEvents.GetInstance().OnKeyDown += this.DoInput;
		groundHeight = GameObject.Find("Ground").transform.position.y;

        // Animation Speed
        Animation ani = this.GetComponent<Animation>();
        foreach (AnimationState state in ani)
        {
            if (state.name == "Walk_Left" || state.name == "Walk_Right")
            {
                state.speed = 2.0f;
            }
        }
	}
	
	void Update () {
        DoMovement();
        DoInput();
		CheckFalling();
	}

    private void DoInput()
    {
        if (isAllowed)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isAllowed = false;
                this.currentDirection = direction.right;
                this.TimeLeft = this.defaultTime;
                SoundManager.Instance.Play("footsteps.L", 0.7f);
                this.GetComponent<Animation>().Play("Walk_Left");


            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                isAllowed = false;
                this.currentDirection = direction.left;
                this.TimeLeft = this.defaultTime;
                SoundManager.Instance.Play("footsteps.R", 0.7f);
                this.GetComponent<Animation>().Play("Walk_Right");

            }

            if (Input.GetKeyUp(KeyCode.W)
                || Input.GetKeyUp(KeyCode.UpArrow))
            {
                this.GetComponent<Animation>().Stop("Walk_Left");
                this.GetComponent<Animation>().Stop("Walk_Right");
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
                this.GetComponent<Animation>().Play("Idle");
            }
        }

    }

	private void CheckFalling()
	{
		if(gameObject.transform.position.y < ( groundHeight - 0.5f ))
		{
			if(!falling)
			{
				GameManager.sound.Play("Derp_fall", 1.0f);
				falling = true;
			}
		}

	}

}
