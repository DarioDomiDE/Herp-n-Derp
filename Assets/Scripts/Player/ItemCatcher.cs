using UnityEngine;
using System.Collections;

public class ItemCatcher : MonoBehaviour {

    private Item currentItem = null;
    private Item.status itemMode = Item.status.singlePress;

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
                    }
                    break;
                case Item.status.longPressed:
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        currentItem.transform.parent = this.transform.parent;
                    }
                    if(Input.GetKeyUp(KeyCode.E))
                    {
                        currentItem.transform.parent = this.transform.parent.parent;
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

}
