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

/*
[System.Serializable]
public class SpawnObjectsMarker
{
    public Vector2 Location;
    public SpawnObjects Object;
    public string Area;
    
       
}
*/

public class AreaDespawn
{
    public int SceneIndex;
    public int SpawnObjectIndex;
}
