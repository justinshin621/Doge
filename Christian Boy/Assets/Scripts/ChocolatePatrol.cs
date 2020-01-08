using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChocolatePatrol : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck; // A transform is a point in space 
    public float wallCheckRadius; // What is considered being on the ground
    public LayerMask whatIsWall;
    private bool hittingWall; // bool is boolean
    private bool notAtEdge;
    public Transform edgeCheck; 

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall || !notAtEdge)
            moveRight = !moveRight;

        if (moveRight)
        {
            transform.localScale = new Vector3(-0.2217127f, 0.2163485f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(0.2217127f, 0.2163485f, 1f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        }
    }
}
