using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemCatcher : MonoBehaviour {

    private List<GameObject> catchedList;

    private Item currentItem = null;
    private Item.status itemMode = Item.status.singlePress;

    void Start()
    {
        catchedList = new List<GameObject>();
    }

    void Update()
    {
        if(currentItem != null)
        {
            switch(currentItem.itemStatus)
            {
                case Item.status.singlePress:
                    if(Input.GetKeyDown(KeyCode.E))
                    {
                        currentItem.transform.parent = this.transform.parent;
                        catchedList.Add(currentItem.gameObject);
                    }
                    break;
                case Item.status.longPressed:
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        currentItem.transform.parent = this.transform.parent;
                        catchedList.Add(currentItem.gameObject);
                    }
                    if(Input.GetKeyUp(KeyCode.E))
                    {
                        currentItem.transform.parent = this.transform.parent.parent;
                        catchedList.Remove(currentItem.gameObject);
                    }
                    break;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            currentItem = other.GetComponent<Item>();
            itemMode = currentItem.itemStatus;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (currentItem == other)
        {
            currentItem = null;
        }
    }

    public bool CheckItem(GameObject searchedObject, int searchedCounter)
    {

    }

}
