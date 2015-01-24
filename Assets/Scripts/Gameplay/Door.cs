using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    [SerializeField]
    public GameObject searchedObject;
    public int searchedCounter;
    public int pressedButtons;

    private bool opened = false;
    private int alreadyPressedButtons = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    public void AddPressedButton()
    {
        alreadyPressedButtons++;
    }
    public void RemovePressedButton()
    {
        alreadyPressedButtons--;
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
			if(searchedCounter==0)
			{
				GameManager.SetNextLevel();
			}
            else if (GameObject.FindGameObjectWithTag("ItemCatcher").GetComponent<ItemCatcher>().CheckItem(this.searchedObject, this.searchedCounter))
            {
				GameManager.SetNextLevel();
				//GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().TransfareToPoints();
				//GameObject.FindGameObjectWithTag("SceneBlender").GetComponent<SceneBlender>().FadeNextScene();
				//SoundManager.Instance.Play("Derp_happy", 1.0f);
            }
        }
    }

}
