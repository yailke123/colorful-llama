using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private bool idle = true;
    [SerializeField] private float idleTime = 0f;
    
    private static readonly int IdleTime = Animator.StringToHash("IdleTime");

    // Update is called once per frame
    void Update()
    {
        if (rigidbody.velocity == Vector2.zero)
        {
            if (idle)
            {
                idleTime += Time.deltaTime;
                animator.SetFloat(IdleTime, idleTime);
            }
            else
            {
                idle = true;
            }
        }
        else if (idle)
        {
            idle = false;
            idleTime = 0f;
            animator.SetFloat(IdleTime, idleTime);
        }
    }
}
