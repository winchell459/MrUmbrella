
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public AbilityMelee Melee; //ability0 playerpref int 0 or 1
    public AbilityRange Range { get; set; } //ability1 playerpref int 0 or 1
    public AbilityProtection Protection { get; set; } //ability2 playerpref int 0 or 1

    public List<AbilityMelee> MeleeAbilities;
    public List<AbilityProtection> ProtectionAbilities;
    public List<AbilityRange> RangeAbilities;

    public static PlayerHandler PH;
    public GameObject PlayerPrefab; //health float number

    public float Health { get; set; }

    private static string[] abilityTags = { "ability0", "ability1", "ability2" };
   
    private static string[] meleelockTags = { "meleeLock0", "meleeLock1", "meleeLock2" };
    private static string[] rangelockTags = { "rangeLock0", "rangeLock1", "rangeLock2" };
    private static string[] protectionlockTags = { "protectionLock0", "protectionLock1", "protectionLock2" };
    private static string spawnSceneTag = "spawnScene";
    private static string healthTag = "Health";

    private bool[] meleeUnlock = { true, true, true };
    private bool[] rangeUnlock = { true, true, true };
    private bool[] protectionUnlock = { true, true, true };

    public static int DefaultSpawnSceneIndex = 2;
    public static float DefaultPlayerHealth = 20;
    public bool isDebug;
    public static bool ResetSave = false;

    private void Awake()
    {
        //PlayerPrefs.SetInt(rangelockTags[1], 0);
        if (PH) Destroy(gameObject);
        else
        {
            PH = this;
            DontDestroyOnLoad(gameObject);


            if (!ResetSave)
            {

                loadPlayerPrefs();
                //if(DefaultSpawnSceneIndex > 1) PlayerPrefs.SetInt(spawnSceneTag, DefaultSpawnSceneIndex + 1);


                if (!isDebug)
                {
                    loadPlayerSavePoint();
                }
                
            }
            else
            {
                ResetSave = false;
                PH.Health = DefaultPlayerHealth;
                resetPlayerSaveRespawn();
            }
            
            
        }
        
        
    }
    private void OnDestroy()
    {
        if(PH == this) SavePlayerPrefs();

        Debug.Log("Oh hi mart saving pp");
    }
    public static void resetPlayerSaveRespawn()
    {
        PlayerPrefs.SetInt(spawnSceneTag, DefaultSpawnSceneIndex);
    }
    public void loadPlayerSaveRespawn()
    {

        Health = DefaultPlayerHealth;
        int sceneId = PlayerPrefs.GetInt(spawnSceneTag, DefaultSpawnSceneIndex);
        Area.LoadingAltar = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);
    }

    public void loadPlayerSavePoint()
    {
        Health = PlayerPrefs.GetFloat(healthTag, DefaultPlayerHealth);
        int sceneId = PlayerPrefs.GetInt(spawnSceneTag, DefaultSpawnSceneIndex);
        Area.LoadingAltar = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);
        

    }

    public void savePlayerSavePoint()
    {
        PlayerPrefs.SetInt(spawnSceneTag, UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetFloat(healthTag, GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health);
        Health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().health;
    }
    public void loadPlayerPrefs()
    {

        //Debug.Log("Ability 0 value " + PlayerPrefs.GetInt("ability0"));
        if (PlayerPrefs.HasKey(abilityTags[0]))
        {
            int index = PlayerPrefs.GetInt(abilityTags[0]);
            index = (int)Mathf.Clamp(index, 0, MeleeAbilities.Count - 1); //[1,2,3,4,5,6]
            Melee = MeleeAbilities[index];
        }
        if (PlayerPrefs.HasKey(abilityTags[1]))
        {
            int index = PlayerPrefs.GetInt(abilityTags[1]);
            index = Mathf.Clamp(index, 0, ProtectionAbilities.Count - 1);
            Protection = ProtectionAbilities[index];
        } 
        if (PlayerPrefs.HasKey(abilityTags[2]))
        {
            int index = PlayerPrefs.GetInt(abilityTags[2]);
            index = Mathf.Clamp(index, 0, RangeAbilities.Count - 1);
            Range = RangeAbilities[index];
        }
        /*
        if (PlayerPrefs.HasKey(healthTag))
        {
            Health = PlayerPrefs.GetFloat(healthTag);
            //Debug.Log("Health: " + Health);
        }
        */
        for(int i = 0; i < 3; i += 1)
        {
            if (PlayerPrefs.HasKey(meleelockTags[i]))
            {
                meleeUnlock[i] = PlayerPrefs.GetInt(meleelockTags[i]) == 0 ? false : true;
            }
        }
        for (int i = 0; i < 3; i += 1)
        {
            if (PlayerPrefs.HasKey(rangelockTags[i]))
            {
                rangeUnlock[i] = PlayerPrefs.GetInt(rangelockTags[i]) == 0 ? false : true;
            }
        }
        for (int i = 0; i < 3; i += 1)
        {
            if (PlayerPrefs.HasKey(protectionlockTags[i]))
            {
                protectionUnlock[i] = PlayerPrefs.GetInt(protectionlockTags[i]) == 0 ? false : true;
            }
        }
    }

    public void SavePlayerPrefs()
    {
        if (Melee) PlayerPrefs.SetInt(abilityTags[0], MeleeAbilities.IndexOf(Melee));
        if(Protection) PlayerPrefs.SetInt(abilityTags[1], ProtectionAbilities.IndexOf(Protection));
        if (Range) PlayerPrefs.SetInt(abilityTags[2], RangeAbilities.IndexOf(Range));
        //Health = FindObjectOfType<PlayerController>().gameObject.GetComponent<Health>().health;
        PlayerPrefs.SetFloat(healthTag, Health);
        
        

        for (int i = 0; i < 3; i += 1)
        {
            PlayerPrefs.SetInt(meleelockTags[i], meleeUnlock[i] ? 1 : 0);
        }
        for (int i = 0; i < 3; i += 1)
        {
            PlayerPrefs.SetInt(rangelockTags[i], rangeUnlock[i] ? 1 : 0);
        }
        for (int i = 0; i < 3; i += 1)
        {
            PlayerPrefs.SetInt(protectionlockTags[i], protectionUnlock[i] ? 1 : 0);
        }
    }
    public bool AbilityUnlocked(AbilityObject ao)
    {
        if(ao.AbilityType == AbilityObject.AbilityTypes.Melee)
        {
            for(int i = 0; i<MeleeAbilities.Count; i += 1)
            {
                if ((AbilityMelee)ao == MeleeAbilities[i]) return meleeUnlock[i];
            }
        }
        else if (ao.AbilityType == AbilityObject.AbilityTypes.Range)
        {
            for (int i = 0; i < RangeAbilities.Count; i += 1)
            {
                if ((AbilityRange)ao == RangeAbilities[i]) return rangeUnlock[i];
            }
        }
        else if (ao.AbilityType == AbilityObject.AbilityTypes.Protection)
        {
            for (int i = 0; i < ProtectionAbilities.Count; i += 1)
            {
                if (/*cast protection*/ao == ProtectionAbilities[i]) return protectionUnlock[i];
            }
        }


        return false;
        
    }
    public void AbilityUnlock(AbilityObject ao)
    {
        bool done = false;
        AbilityUI aui = FindObjectOfType<AbPanelActive>().AbPanel.transform.GetChild(0).GetComponent<AbilityUI>();//FindObjectOfType<AbilityUI>();
        for(int i= 0; i < aui.MeleeAbilityButtons.Length && !done; i += 1)
        {
            if(aui.MeleeAbilityButtons[i].Ability == ao)
            {
                done = true;
                meleeUnlock[i] = true;
                aui.MeleeAbilityButtons[i].Unlock();
            }
        }
        for (int i = 0; i < aui.RangeAbilityButtons.Length && !done; i += 1)
        {
            if (aui.RangeAbilityButtons[i].Ability == ao)
            {
                done = true;
                rangeUnlock[i] = true;
                aui.RangeAbilityButtons[i].Unlock();
            }
        }
        for (int i = 0; i < aui.ProtectionAbilityButtons.Length && !done; i += 1)
        {
            if (aui.ProtectionAbilityButtons[i].Ability == ao)
            {
                done = true;
                protectionUnlock[i] = true;
                aui.ProtectionAbilityButtons[i].Unlock();
            }
        }


    }
    private void Update()
    {
        Debug.Log(ResetSave);
    }

}
