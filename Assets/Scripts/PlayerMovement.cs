using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    public float runSpeed = 40f;
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        jump = Input.GetAxisRaw("Vertical") > 0; 

        if (Input.GetButtonDown("Crouch")){
            crouch = true;
        }else if (Input.GetButtonUp("Crouch")){
            crouch = false; 
        }
    }

    private void FixedUpdate()
    {
        controller2D.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
    }
}
