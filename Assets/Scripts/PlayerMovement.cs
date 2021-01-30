using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller2D;
    public float runSpeed = 40f;
    public float jumpMultiplier = 10f; //TODO tweak
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * jumpMultiplier;
    }

    private void FixedUpdate()
    {
        controller2D.Move(horizontalMove * Time.fixedDeltaTime, false, false);
        controller2D.Move(verticalMove * Time.fixedDeltaTime, false, true);
    }
}
