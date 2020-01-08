using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private float moveVelocity;
    public float jumpHeight;

    public Transform groundCheck; // A transform is a point in space 
    public float groundCheckRadius; // What is considered being on the ground
    public LayerMask whatIsGround;

    private bool grounded; // bool is boolean
    private bool doubleJumped;


    public Transform firePoint;
    public GameObject tennisBall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update occurs a certain amount of times every single second (Used for Physics within Unity)
    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grounded)  // You don't need curly brackets if you only have one line of code after if statement

            doubleJumped = false;
        
        if(Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.W) && !doubleJumped && !grounded)
        {
            Jump();
            doubleJumped = true;
        }

        moveVelocity = 0f;

        if(Input.GetKey(KeyCode.A)) // Moves to the left pressing A key, (GetKey different to GetKeyDown)

        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -moveSpeed;
        }

        
        if(Input.GetKey(KeyCode.D)) // Moves to right pressing D key
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = moveSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        // Rotates the characer depending on moving right or left
        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(2.282f, 2.378f, 2.35f);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-2.282f, 2.378f, 2.35f);

        // Fires the tennis ball
        if(Input.GetKeyDown(KeyCode.Return)) // Return is the Enter button
        {
            Instantiate(tennisBall, firePoint.position, firePoint.rotation);
        }

    }

    // Simplify Jump code
    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);

    }
}
