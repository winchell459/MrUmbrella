using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public static PlayerHandler PH;
    public GameObject PlayerPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        if (PH) Destroy(gameObject);
        PH = this;
        DontDestroyOnLoad(gameObject);
    }

    
}
