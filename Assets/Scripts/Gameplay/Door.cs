using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    [SerializeField]
    public GameObject searchedObject;
    public int searchedCounter;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("enter " + other.name);

        if(other.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("ItemCatcher").GetComponent<ItemCatcher>().CheckItem(this.searchedObject, this.searchedCounter))
            {
                // Do Door
                GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().TransfareToPoints();
                GameObject.FindGameObjectWithTag("SceneBlender").GetComponent<SceneBlender>().FadeNextScene();
            }
        }

    }

}
