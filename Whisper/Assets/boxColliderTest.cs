using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxColliderTest : MonoBehaviour
{
    BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(bc.bounds.min + " | " + bc.bounds.max);
    }
}
