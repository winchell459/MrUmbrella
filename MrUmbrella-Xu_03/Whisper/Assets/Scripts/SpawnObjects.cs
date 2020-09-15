using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    //public GameObject[]

    protected void DespawnObjects()
    {
        FindObjectOfType<Area>().DespawnObject(this);
    }
}



public class AreaDespawn
{
    public int SceneIndex;
    public int SpawnObjectIndex;
}
