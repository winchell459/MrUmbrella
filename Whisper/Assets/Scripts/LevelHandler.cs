using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public List<Collider2D> Covers;
    public PlayerController Player;// { private set; }

    private ParticleSystem[] rainSystems;

    // Start is called before the first frame update
    void Start()
    {
        if (!Player) Player = FindObjectOfType<PlayerController>();


        rainSystems = FindObjectsOfType<ParticleSystem>();
        foreach(ParticleSystem rainer in rainSystems)
        {
            for(int i = 1; i <= Covers.Count; i += 1)
            {
                rainer.trigger.SetCollider(i, Covers[i-1]);
            }
            
        }
        addUmbrellaToRainEmitters();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Player)
        {
            Player = FindObjectOfType<PlayerController>();
            if (Player) addUmbrellaToRainEmitters();
        }

        
    }

    private void addUmbrellaToRainEmitters()
    {
        foreach(ParticleSystem rainer in rainSystems)
        {
            rainer.trigger.SetCollider(0, Player.Umbrella.GetComponent<Collider2D>());
        }
    }
}
