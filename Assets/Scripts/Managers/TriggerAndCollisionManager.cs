using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAndCollisionManager : MonoBehaviour
{
    public CharacterController2D controller2D;

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "ColorChanger":
                SoundManager.Instance.PlaySoundWithName("ColorChange");  
                other.gameObject.GetComponent<Collectable>().Collect();
                // GetComponent<SpriteRenderer>().color = other.gameObject.GetComponent<SpriteRenderer>().color;
                // Destroy(other.gameObject);
                break;
            case "Spike":
                SoundManager.Instance.PlaySoundWithName("Spike");  
                controller2D.StopAndGoToLastCheckPoint();
                break;
            case "Checkpoint":
                SoundManager.Instance.PlaySoundWithName("Checkpoint");   
                controller2D.UpdateCheckPoint(other.transform);
                other.enabled = false;
                break;
            case "Throwable":
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Enemy":
                SoundManager.Instance.PlaySoundWithName("Spike");  
                controller2D.StopAndGoToLastCheckPoint();
                break;
        }
    }
    
}
