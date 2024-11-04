using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleActivator : MonoBehaviour
{
    public ParticleSystem jumpParticles;
    public ParticleSystem fallParticles;
    public ParticleSystem collisionParticles;

    void Start()
    {
        jumpParticles.Stop();
        fallParticles.Stop();
        collisionParticles.Stop();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            jumpParticles.Play();
        }

        if (Input.GetKeyDown(KeyCode.S)) 
        {
            fallParticles.Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("UpperObstacle") || collision.gameObject.CompareTag("LowerObstacle"))
        {
            collisionParticles.Play();
        }
    }
}

