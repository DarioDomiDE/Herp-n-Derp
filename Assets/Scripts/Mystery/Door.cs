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
			if(value != _opened)
			{
                _opened = value;
				GameManager.sound.Play("Door - Open", 1.0f);
			}
		}
	}
    private int alreadyPressedButtons = 0;
    private int alreadyEatings = 0;

    void Start()
    {

    }

	//void Update()
	//{

	//}

    public void AddPressedButton()
    {
        alreadyPressedButtons++;
        CheckAllButtonsPressedAndItems();
    }

    public void RemovePressedButton()
    {
        alreadyPressedButtons--;
        CheckAllButtonsPressedAndItems();
    }

    public void AddEating()
    {
        alreadyEatings++;
        CheckAllButtonsPressedAndItems();
    }

    private void CheckAllButtonsPressedAndItems()
    {
        if (opened == false && alreadyPressedButtons == pressedButtons && alreadyEatings == searchedCounter)
        {
            opened = true;
            // Disable Texture
            GameManager.door.transform.FindChild("Key").GetComponent<MeshRenderer>().enabled = false;
        }
        else if (opened == true && (alreadyPressedButtons != pressedButtons || alreadyEatings != searchedCounter))
        {
            opened = false;
            // Enable Texture
            GameManager.door.transform.FindChild("Key").GetComponent<MeshRenderer>().enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if ((opened == true) ||
                (
                pressedButtons == 0 &&
                GameObject.FindGameObjectWithTag("ItemCatcher").GetComponent<ItemCatcher>().CheckItem(this.searchedObject, this.searchedCounter)
                )
                )
            {
                SoundManager.Instance.Play("Key - Interact with door", 1.0f);
                GameManager.door.transform.FindChild("Key").GetComponent<MeshRenderer>().enabled = false;
                GameManager.SetNextLevel();
            }
        }
    }

}
