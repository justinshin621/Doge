using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * For the computer not to clog up memory in creating excess amount of unecessary 
 * particle objects.
 */

public class DestroyFinishedParticle : MonoBehaviour
{

    private ParticleSystem thisParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        thisParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!thisParticleSystem.isPlaying)
            Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
