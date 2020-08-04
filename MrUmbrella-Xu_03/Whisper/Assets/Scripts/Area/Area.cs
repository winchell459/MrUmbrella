using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Area : MonoBehaviour
{
    public List<SpawnObjects> spawnObjects = new List<SpawnObjects>();
    public static List<AreaDespawn> ObjectsDestroyed = new List<AreaDespawn>();

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
        despawnObjects();
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
                    Debug.Log("Bridge load healt: " + PlayerHandler.PH.Health);
                    break;
                }
            }
        }
        else
        {
            Player = Instantiate(PlayerHandler.PH.PlayerPrefab, DefaultPlayerSpawnPoint.transform.position, Quaternion.identity).transform;
            //Debug.Log("No Bridge Load health: " + PlayerHandler.PH.Health);
            Player.GetComponent<Health>().health = PlayerHandler.PH.Health;
            //Debug.Log("no bridge load");
            
        }
        FindObjectOfType<Follow>().SetTarget(Player);
    }
    public void UseBridge(AreaBridge bridge)
    {
        PlayerHandler.PH.SavePlayerPrefs();
        LoadingAreaBridge = bridge.BridgeToBridgeName;
        SceneManager.LoadScene(bridge.BridgeToAreaName);
    }
    public void DespawnObject(SpawnObjects so)
    {
        if (spawnObjects.Contains(so))
        {
            int objectsIndex = spawnObjects.IndexOf(so);

            int sceneIndex = SceneManager.GetActiveScene().buildIndex;

            AreaDespawn areaDespawn = new AreaDespawn();
            areaDespawn.SceneIndex = sceneIndex;
            areaDespawn.SpawnObjectIndex = objectsIndex;
            ObjectsDestroyed.Add(areaDespawn);

        }
        
    }

    private void despawnObjects()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        foreach(AreaDespawn ad in ObjectsDestroyed)
        {
            if(ad.SceneIndex == sceneIndex)
            {
                Transform parent = spawnObjects[ad.SpawnObjectIndex].transform;
                
                
                while (parent.parent) parent = parent.parent;
                Destroy(parent.gameObject);

                
            }
        }
    }
}
