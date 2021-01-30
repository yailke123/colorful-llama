using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    public CharacterController2D controller2D;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "ColorChanger":
                GetComponent<SpriteRenderer>().color = other.gameObject.GetComponent<SpriteRenderer>().color;
                Destroy(other.gameObject);
                break;
            case "Spike":
                controller2D.StopAndGoToLastCheckPoint();
                break;
            case "Checkpoint":
                controller2D.UpdateCheckPoint(other.transform);
                other.enabled = false;
                break;
        }
    }
    
}
