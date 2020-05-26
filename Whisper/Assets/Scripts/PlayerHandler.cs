using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public static PlayerHandler PH;
    public GameObject PlayerPrefab;
    private void Awake()
    {
        if (PH) Destroy(gameObject);
        PH = this;
        DontDestroyOnLoad(gameObject);
    }
}
