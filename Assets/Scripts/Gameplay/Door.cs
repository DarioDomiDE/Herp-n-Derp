using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    [SerializeField]
    public GameObject searchedObject;
    public int searchedCounter;
    public int pressedButtons;
	[SerializeField]
    private bool _opened = false;
	private bool opened
	{
		get { return _opened; }
		set
		{
			if(value &&(value != _opened))
			{
				_opened = true;
				GameManager.sound.Play("Door - Open", 1.0f);
			}
		}
	}
    private int alreadyPressedButtons = 0;

    void Start()
    {

    }

	//void Update()
	//{

	//}

    public void AddPressedButton()
    {
        alreadyPressedButtons++;
        CheckAllButtonsPressed();
    }
    public void RemovePressedButton()
    {
        alreadyPressedButtons--;
        CheckAllButtonsPressed();
    }

    private void CheckAllButtonsPressed()
    {
        if (opened == false && alreadyPressedButtons == pressedButtons)
        {
            opened = true;
            // Disable Texture
        }
        else if(opened == true && alreadyPressedButtons != pressedButtons)
        {
            opened = false;
            // Enable Texture
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if ((opened == true && searchedCounter == 0) ||
                (
                pressedButtons == 0 &&
                GameObject.FindGameObjectWithTag("ItemCatcher").GetComponent<ItemCatcher>().CheckItem(this.searchedObject, this.searchedCounter)
                )
                )
            {
				GameManager.SetNextLevel();
            }
        }
    }

}
