using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public List<Collider2D> Covers;
    public PlayerController Player;

    private ParticleSystem[] rainSystems;

    void Start()
    {
        if (!Player) Player = FindObjectOfType<PlayerController>();
        rainSystems = FindObjectsOfType<ParticleSystem>();

        foreach(ParticleSystem rainer in rainSystems)
        {
            for(int i = 1; i < Covers.Count; i += 1)
            {
                rainer.trigger.SetCollider(i, Covers[i-1]);
            }  
        }
        if(Player) addUmbrellaToRainemitters();
    }


    void Update()
    {
        if (!Player)
        {
            Player = FindObjectOfType<PlayerController>();
            if (Player) addUmbrellaToRainemitters();
        }

        
    }
    private void addUmbrellaToRainemitters()
    {
        foreach(ParticleSystem rainer in rainSystems)
        {
            rainer.trigger.SetCollider(0, Player.Umbrella.GetComponent<Collider2D>());
        }
    }
}
