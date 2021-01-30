using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    // [SerializeField] private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        print("TRIGGEEEEER");
        if(other.gameObject.CompareTag("ColorChanger"))
        {
            GetComponent<SpriteRenderer>().color = other.gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(other.gameObject);
        }    
    }
    
}
