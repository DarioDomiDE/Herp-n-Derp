using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    private float Speed = 3.0f;
    private float SideSpeed = 1.0f;
    private float Angle = 200.0f;
    private float defaultTime = 0.3f;
	private float groundHeight = 0;
	private bool falling = false;
    private bool movingAllowed = true;
    private float TimeLeft = 0;
    private enum direction
    {
        none = 0,
        left = -1,
        right = 1
    }
    private direction currentDirection = direction.none;
    private GameObject player;

    void Awake()
    {
        // Awake fired if a scene loaded
        Debug.Log("awake");
        GameObject.FindGameObjectWithTag("SceneCrossContainer").GetComponent<UpdateManager>().OnUpdate += DoUpdate;
        player = GameObject.FindGameObjectWithTag("Player");

        falling = false;
        movingAllowed = true;
        TimeLeft = 0;


    }

	void Start ()
    {
        // Start fired if a scene loaded and the script is used for the 1st time. like a normal initialition Constructor
        Debug.Log("start");

        GameEvents.GetInstance().OnKeyDown += this.DoInputDown;
        GameEvents.GetInstance().OnKeyUp += this.DoInputUp;

		groundHeight = GameObject.Find("Ground").transform.position.y;

        // Animation Speed
        Animation ani = player.GetComponent<Animation>();
        foreach (AnimationState state in ani)
        {
            if (state.name == "Walk_Left" || state.name == "Walk_Right")
            {
                state.speed = 2.0f;
            }
        }
	}

    public void Destruct()
    {
        GameObject.FindGameObjectWithTag("SceneCrossContainer").GetComponent<UpdateManager>().OnUpdate -= DoUpdate;
    }

	void DoUpdate () {

        if (movingAllowed == false)
            DoMovement();
        
		CheckFalling();
	}

    private void DoInputDown()
    {
        if (!movingAllowed)
            return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            movingAllowed = false;
            this.currentDirection = direction.right;
            this.TimeLeft = this.defaultTime;
            SoundManager.Instance.Play("footsteps.L", 0.7f);
            player.GetComponent<Animation>().Play("Walk_Left");


        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            movingAllowed = false;
            this.currentDirection = direction.left;
            this.TimeLeft = this.defaultTime;
            SoundManager.Instance.Play("footsteps.R", 0.7f);
            player.GetComponent<Animation>().Play("Walk_Right");

        }
    }

    private void DoInputUp(KeyCode key)
    {
        /*Debug.Log(key);

        if (!isAllowed)
            return;

        if (key == KeyCode.W || key == KeyCode.UpArrow)
        {
            this.GetComponent<Animation>().Stop("Walk_Left");
            this.GetComponent<Animation>().Stop("Walk_Right");
        }*/
    }

    private void DoMovement()
    {
        if (this.TimeLeft > 0)
        {
            this.TimeLeft -= Time.deltaTime;

            Vector3 pos = Vector3.zero;
            pos += player.transform.forward * this.Speed;
            pos += player.transform.right * this.SideSpeed * (int)this.currentDirection;
            pos *= Time.deltaTime;
            pos += player.transform.position;
            player.transform.position = pos;

            player.transform.Rotate(new Vector3(0, 1.0f * (int)this.currentDirection, 0), Angle * Time.deltaTime);
        }
        else
        {
            movingAllowed = true;
            player.GetComponent<Animation>().Play("Idle");
        }

    }

	private void CheckFalling()
	{
        if (player.transform.position.y < (groundHeight - 0.5f))
		{
			if(!falling)
			{
				GameManager.sound.Play("Derp_fall", 1.0f);
				falling = true;
			}
		}

	}

}
