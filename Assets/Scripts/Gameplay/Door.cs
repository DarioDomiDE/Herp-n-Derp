using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    [SerializeField]
    public GameObject searchedObject;
    public int searchedCounter;

	void Start () {
	
	}
	
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("ItemCatcher").GetComponent<ItemCatcher>().CheckItem(this.searchedObject, this.searchedCounter))
            {
                // Do Door
                GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().TransfareToPoints();
                GameObject.FindGameObjectWithTag("SceneBlender").GetComponent<SceneBlender>().FadeNextScene();
                SoundManager.Instance.Play("Derp_happy", 1.0f);
            }
        }

    }

}
