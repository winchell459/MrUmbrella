using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Area : MonoBehaviour
{
    public static string LoadingAreaBridge;
    public GameObject Player;

    public List<AreaBridge> AreaBridges;
    public Transform DefaultPlayerSpawnPoint;

    public abstract void OnAwake();
    public abstract void OnLoad();
    public abstract void OnUpdate();
    public abstract void OnExit();

    private void Awake()
    {
        OnAwake();
    }

    private void Start()
    {
        loadPlayer();
        OnLoad();
    }

    private void Update()
    {
        OnUpdate();   
    }

    private void loadPlayer()
    {
        Debug.Log(LoadingAreaBridge);
        if (!Player && LoadingAreaBridge != null)
        {
            Debug.Log("Loading Player");
            //AreaBridge bridge;
            foreach(AreaBridge bridge in AreaBridges)
            {
                if (bridge.BridgeName == LoadingAreaBridge)
                {

                    // bridge = ab;
                    Player = Instantiate(PlayerHandler.PH.PlayerPrefab, bridge.transform.position + (Vector3)bridge.LoadingOffset, Quaternion.identity);

                    break;
                }
            }

            
        }else if (!Player)
        {
            Player = Instantiate(PlayerHandler.PH.PlayerPrefab, DefaultPlayerSpawnPoint.transform.position, Quaternion.identity);
        }

        FindObjectOfType<CameraFollow>().SetTarget(Player.transform.GetChild(0));
    }

    public void UseBridge(AreaBridge bridge)
    {
        LoadingAreaBridge = bridge.BridgeToBridgeName;
        SceneManager.LoadScene(bridge.BridgeToAreaName);
    }
}



