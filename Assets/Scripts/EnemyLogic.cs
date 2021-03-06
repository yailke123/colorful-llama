﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    // Keeps track of distance travelled in a single direction
    private float distanceTravelled = 0f; 
    // Keeps track of the current direction
    private Vector3 currentDirection = Vector3.right;
    // Max distance that an enemy can go in a single direction
    private const float distanceLimitInSingleDirection = 3f;
    private const float speedMultiplier = 2;

    public bool doesThrowSpike = false;
    public GameObject spikeObject;

    // Update is called once per frame
    void Update()
    {
        Vector3 distanceToTravel = currentDirection * Time.deltaTime * speedMultiplier;

        // If it is time to turn around 
        if(distanceToTravel.magnitude + distanceTravelled > distanceLimitInSingleDirection){
            currentDirection = -1 * currentDirection; 
            distanceToTravel = -1 * distanceToTravel; 
            distanceTravelled = distanceLimitInSingleDirection - distanceTravelled;

            // Turn around physically
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

            if(doesThrowSpike)
                throwSpike();
        }

        transform.Translate(distanceToTravel);
        distanceTravelled += distanceToTravel.magnitude;
    }

    public void Die(){
        Destroy (gameObject);
    }

    private void throwSpike(){  
        // TODO add sound effect?      
        GameObject spikeInstance = Instantiate(spikeObject, transform.position, Quaternion.identity);
        Rigidbody2D spikeRigidBody = spikeInstance.GetComponent<Rigidbody2D>();
        spikeRigidBody.AddForce(gameObject.transform.forward * 10f);
        Destroy(spikeInstance, 2f);
    }
}
