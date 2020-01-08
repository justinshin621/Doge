using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public PlayerController player; // this is what the player is

    public bool isFollowing; // determine if camera is following player or not

    public float xOffset;
    public float yOffset;


    public

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        isFollowing = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
            transform.position = new Vector3(player.transform.position.x + xOffset, player.transform.position.y + yOffset, transform.position.z);
    }
}
