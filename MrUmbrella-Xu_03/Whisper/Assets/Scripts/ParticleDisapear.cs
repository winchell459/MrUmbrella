using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParticleDisapear : MonoBehaviour
{
    public float norm_ParticleDecayTime = 5f;
    public float p_ParticleDecayTime = 2f;

    public GameObject[] particles;
    public GameObject[] PlayerParticles;

    private void Update()
    {
        particles = GameObject.FindGameObjectsWithTag("particle");
        PlayerParticles = GameObject.FindGameObjectsWithTag("PlayerParticle");

        if (GameObject.FindGameObjectWithTag("PlayerParticle") || GameObject.FindGameObjectWithTag("particle"))
        {
            DestroyPartices();
        }

    }
    public void DestroyPartices()
    {
        for (int i = 0; i < particles.Length; i = i + 1)
        {
            Destroy(particles[i], norm_ParticleDecayTime);
        }
        for (int i = 0; i < PlayerParticles.Length; i = i + 1)
        {
            Destroy(PlayerParticles[i], p_ParticleDecayTime);
        }
    }
    
}