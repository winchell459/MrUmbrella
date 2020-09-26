using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class Area : MonoBehaviour
{
    public List<SpawnObjects> spawnObjects = new List<SpawnObjects>();
    public static List<AreaDespawn> ObjectsDestroyed = new List<AreaDespawn>();

    public static bool LoadingAltar;

    public static string LoadingAreaBridge;
    public List<AreaBridge> AreaBridges;
    public Transform DefaultPlayerSpawnPoint;

    public abstract void OnAwake();
    public abstract void OnLoad(); //when the assetsare loaded
    public abstract void OnUpdate();
    public abstract void OnExit();//when the player exit the scene

    public Transform Player { get; set; }

    public AudioClip SceneTrack;


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
        FindObjectOfType<MusicBackgroundHandler>().OnSceneStart(SceneTrack);

    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }

    private void loadPlayer()
    {
        if (LoadingAltar)
        {
            FindObjectOfType<RespawnAltar>().Respawn();
            LoadingAltar = false;
            Debug.Log("LOADING ALTAR YEET");

        }
        else if(LoadingAreaBridge != null)
        {
            foreach(AreaBridge bridge in AreaBridges)
            {
                if(bridge.BridgeName == LoadingAreaBridge)
                {
                    InstantiatePlayer(bridge.transform.position + (Vector3)bridge.LoadingOffset);
                    Debug.Log("Bridge load healt: " + PlayerHandler.PH.Health);
                    break;
                }
            }
        }
        else
        {
            InstantiatePlayer(DefaultPlayerSpawnPoint.transform.position);
            
        }
        FindObjectOfType<Follow>().SetTarget(Player);
    }
    private void InstantiatePlayer(Vector2 spawnPoint)
    {
        Player = Instantiate(PlayerHandler.PH.PlayerPrefab, spawnPoint, Quaternion.identity).transform;
                                                                                                                                                      //if(Player.TryGetComponent(out Health health))
        float health = PlayerHandler.PH.Health;
        Player.GetComponent<Health>().health = health;
    }
    public void UseBridge(AreaBridge bridge)
    {
        if (GameObject.FindGameObjectWithTag("Enemy") == null && FindObjectOfType<PlayerAttack>().isBack)
        {
            MusicBackgroundHandler.StaticMBH.OnSceneEnd();
            
            
            PlayerHandler.PH.SavePlayerPrefs();
            PlayerHandler.PH.Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health;
            LoadingAreaBridge = bridge.BridgeToBridgeName;
            SceneManager.LoadScene(bridge.BridgeToAreaName);
            
        }
        
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
