using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisBallController : MonoBehaviour
{

    public float speed;

    public PlayerController player;

    public GameObject chocolateDepartEffect;

    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (player.transform.localScale.x < 0)
            speed = -speed; 
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Instantiate(chocolateDepartEffect, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
        }

        if(collision.tag == "Ground")
        {
            Instantiate(impactEffect, collision.transform.position, collision.transform.rotation);

        }
        Destroy(gameObject);
    }
}
