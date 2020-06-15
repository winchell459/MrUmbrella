using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainEmitter : MonoBehaviour
{
    private ParticleSystem emitter;
    private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        emitter = GetComponent<ParticleSystem>();
        player = FindObjectOfType<PlayerController>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            player = FindObjectOfType<PlayerController>();
            emitter.trigger.SetCollider(0, player.Umbrella.GetComponent<Collider2D>());
        }
        else
        {

        }
    }
}
