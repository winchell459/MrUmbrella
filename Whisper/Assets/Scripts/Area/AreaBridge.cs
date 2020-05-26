using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "New Bridge")]
public class AreaBridge : MonoBehaviour
{
    public string BridgeName;
    public string BridgeToAreaName;
    public string BridgeToBridgeName;

    public Vector2 LoadingOffset;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<Area>().UseBridge(this);
        }
    }
}
