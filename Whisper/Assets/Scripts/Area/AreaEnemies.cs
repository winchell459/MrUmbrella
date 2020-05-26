using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnemies : Area
{
    public List<SpawnPoint> enemies;
    public override void OnAwake()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnExit()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnLoad()
    {
        //throw new System.NotImplementedException();
        foreach(SpawnPoint enemy in enemies)
        {
            enemy.LoadEntity();
        }
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }
}

[System.Serializable]
public class SpawnPoint
{
    public Transform SpawnPointLocation;
    public Vector2 Offset;
    public Vector2 Direction;
    public GameObject Prefab;

    public GameObject LoadEntity()
    {
        GameObject entity = GameObject.Instantiate(Prefab, SpawnPointLocation.position + (Vector3)Offset, Quaternion.identity);
        entity.transform.position = SpawnPointLocation.position;
        return entity;
    }
}
