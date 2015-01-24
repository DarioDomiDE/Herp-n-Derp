using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    
    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag != "Item")
        {
            SoundManager.Instance.Play("Derp_collision", 1.0f);
        }
    }


}
