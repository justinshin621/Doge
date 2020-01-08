using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public LevelManager levelManager;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();  // searches any objects that have <LevelManager> script attached, so now we can use levelManager

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This detects when a player enters a trigger zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Doggo")
        {
            levelManager.currentCheckpoint = gameObject; // When Doggo passes a Checkpoint the currentCheckpoint changes to the next checkpoint

            Debug.Log("Activated Checkpoint" + transform.position);
        }
    }
}
