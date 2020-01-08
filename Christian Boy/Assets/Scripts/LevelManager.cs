using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    // whatever point we want player to respawn
    public GameObject currentCheckpoint;

    private PlayerController player;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public int pointPenaltyOnDeath;

    public float respawnDelay;

    private CameraController camera;

    private float gravityStore;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        camera = FindObjectOfType<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");

    }

    public IEnumerator RespawnPlayerCo()
    {

        Instantiate(deathParticle, player.transform.position, player.transform.rotation);  // creates a copy of whatever object you're trying to make, (GameObject, position, rotation)
        player.enabled = false; // this disables the player movement
        player.GetComponent<Renderer>().enabled = false; // this makes the player dissapear
        camera.isFollowing = false;
        //gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
        //player.GetComponent<Rigidbody2D>().gravityScale = 0f; // sets the gravity to be zero when the player dies
        //player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; //sets both x velocity and y velocity to be zero 
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        Debug.Log("Doggo Respawn"); // Whatever text is put in will show in the bottom when Respawn Player is done
        yield return new WaitForSeconds(respawnDelay); // this system determines how long you should pause between each line of code  
        //player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        player.transform.position = currentCheckpoint.transform.position; // has the player transform its position to current checkpoint position
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        camera.isFollowing = true;
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
