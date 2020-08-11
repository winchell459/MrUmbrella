using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public AbilityMelee Melee; //ability0 playerpref int 0 or 1
    public AbilityRange Range { get; set; } //ability1 playerpref int 0 or 1
    public AbilityObject Protection { get; set; } //ability2 playerpref int 0 or 1

    public List<AbilityMelee> MeleeAbilities;
    public List<AbilityObject> ProtectionAbilities;
    public List<AbilityRange> RangeAbilities;

    public static PlayerHandler PH;
    public GameObject PlayerPrefab; //health float number

    public float Health { get; set; }

    private static string[] abilityTags = { "ability0", "ability1", "ability2" };
    private string[] meleeTags = { "melee0", "melee1", "melee2" };
    private string[] rangeTags = { "range0", "range1", "range2" };
    private string[] protectionTags = { "protection0", "protection1", "protection2" };
    private string spawnSceneTag = "spawnScene";
    private string healthTag = "Health";

    private bool[] meleeUnlock = { true, true, true };
    private bool[] rangeUnlock = { true, false, false };
    private bool[] protectionUnlock = { true, false, false };

    private void Awake()
    {
        if (PH) Destroy(gameObject);
        else
        {
            PH = this;
            DontDestroyOnLoad(gameObject);

            loadPlayerPrefs();
        }
        
    }
    private void OnDestroy()
    {
        if(PH == this) SavePlayerPrefs();

        Debug.Log("Oh hi mart saving pp");
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
        if (PlayerPrefs.HasKey(healthTag))
        {
            Health = PlayerPrefs.GetFloat(healthTag);
            //Debug.Log("Health: " + Health);
        }
    }

    public void SavePlayerPrefs()
    {
        if (Melee) PlayerPrefs.SetInt(abilityTags[0], MeleeAbilities.IndexOf(Melee));
        if(Protection) PlayerPrefs.SetInt(abilityTags[1], ProtectionAbilities.IndexOf(Protection));
        if (Range) PlayerPrefs.SetInt(abilityTags[2], RangeAbilities.IndexOf(Range));
        Health = FindObjectOfType<PlayerController>().gameObject.GetComponent<Health>().health;
        PlayerPrefs.SetFloat(healthTag, Health);
        Debug.Log("Saving Player Health: " + FindObjectOfType<PlayerController>().gameObject.GetComponent<Health>().health);
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
}
