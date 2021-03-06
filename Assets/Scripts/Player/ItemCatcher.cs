﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemCatcher : MonoBehaviour {

    private GameObject catchedObject;
    private int catchedCounter = 0;

    private Item currentItem = null;
    private Item.status itemMode = Item.status.singlePress;

    void Start()
    {
    }

    void Update()
    {
        if(currentItem != null)
        {
            switch(currentItem.itemStatus)
            {
                case Item.status.singlePress:
                    if(Input.GetKeyDown(KeyCode.U))
                    {
                        catchedCounter++;
                        GameObject.Destroy(currentItem.gameObject);
                        currentItem.Eating();
                        currentItem = null;
                        SoundManager.Instance.Play("Derp_eating", 1.0f);
                    }
                    break;
                case Item.status.longPressed:
                    if (Input.GetKeyDown(KeyCode.U))
                    {
                        currentItem.transform.parent = this.transform.parent;
                        catchedObject = currentItem.gameObject;
                        currentItem.Pickup();
                        SoundManager.Instance.Play("Derp_pickup", 1.0f);
                    }
                    if(Input.GetKeyUp(KeyCode.U))
                    {
                        currentItem.transform.parent = this.transform.parent.parent;
                        catchedObject = null;
                        currentItem.Drop();
                        SoundManager.Instance.Play("Derp_drop", 1.0f);
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
        int catched = 0;
        if(catchedObject != null)
            catched++;
        if (searchedCounter == catchedCounter + catched)
        {
            if(searchedObject == null)
                return true;
            else if(searchedObject.name == catchedObject.name)
                return true;
        }
        return false;
    }

}
