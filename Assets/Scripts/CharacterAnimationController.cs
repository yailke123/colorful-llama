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
    private static readonly int isWalking = Animator.StringToHash("isWalking");
    private static readonly int isJumping = Animator.StringToHash("isAirborne");
    private static readonly int JumpTrigger = Animator.StringToHash("jumpTrigger");

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

    public void SetIsWalking(bool isReallyWalking) {
        animator.SetBool(isWalking, isReallyWalking);
    }

    public void SetIsJumping(bool isReallyJumping) {
        animator.SetBool(isJumping, isReallyJumping);
    }

    public void TriggerJumpAnim() {
        animator.SetTrigger(JumpTrigger);
    }

    public bool IsAirborneAnimPlaying() {
        return animator.GetBool(isJumping);
    }
}
