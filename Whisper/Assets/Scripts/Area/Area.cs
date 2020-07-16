using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Area : MonoBehaviour
{
    public static string LoadingAreaBridge;
    public List<AreaBridge> AreaBridges;
    public Transform DefaultPlayerSpawnPoint;

    public abstract void OnAwake();
    public abstract void OnLoad(); //when the assetsare loaded
    public abstract void OnUpdate();
    public abstract void OnExit();//when the player exit the scene

    public Transform Player { get; set; }

    private void Awake()
    {
        OnAwake();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
        OnLoad();
        loadPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    private void loadPlayer()
    {
        if(LoadingAreaBridge != null)
        {
            foreach(AreaBridge bridge in AreaBridges)
            {
                if(bridge.BridgeName == LoadingAreaBridge)
                {
                    Player = Instantiate(PlayerHandler.PH.PlayerPrefab, bridge.transform.position + (Vector3)bridge.LoadingOffset, Quaternion.identity).transform;//.GetChild(0);
                    //if(Player.TryGetComponent(out Health health))

                    float health = PlayerHandler.PH.Health;
                    Player.GetComponent<Health>().health = health;
                    Debug.Log("BridgeLoad" + PlayerHandler.PH.Health);
                    break;
                }
            }
        }
        else
        {
            Player = Instantiate(PlayerHandler.PH.PlayerPrefab, DefaultPlayerSpawnPoint.transform.position, Quaternion.identity).transform;
            Player.GetComponent<Health>().health = PlayerHandler.PH.Health;

            Debug.Log("NoBridgeLoad" + PlayerHandler.PH.Health);
        }
        FindObjectOfType<Follow>().SetTarget(Player);
    }
    public void UseBridge(AreaBridge bridge)
    {
        LoadingAreaBridge = bridge.BridgeToBridgeName;
        SceneManager.LoadScene(bridge.BridgeToAreaName);

        PlayerHandler.PH.SavePlayerPrefs();
    }
}
