using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public CharacterController2D controller2D;

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("TRIGGEEEEER");

        switch (other.gameObject.tag)
        {
            case "ColorChanger":
                GetComponent<SpriteRenderer>().color = other.gameObject.GetComponent<SpriteRenderer>().color;
                Destroy(other.gameObject);
                break;
            case "Spike":
                print("öldün");
                // Take the user back to last checkpoint 
                controller2D.GoToLastCheckPoint();
                break;
            case "Checkpoint":
                print("checkpointe geldin");
                //  Update user checkpoint 
                controller2D.UpdateCheckPoint(other.transform.position);
                break;
        }
    }
    
}
