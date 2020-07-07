using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public static PlayerHandler PH;
    public GameObject PlayerPrefab;

    public AbilityObject Melee  {get; set; } //ability0 playerpref int 0 or 1
    public AbilityObject Protection { get; set; } //ability1 playerpref int 0 or 1
    public AbilityObject Range { get; set; } //ability2 playerpref int 0 or 1

    public List<AbilityObject> MeleeAbilities;
    public List<AbilityObject> ProtectionAbilities;
    public List<AbilityObject> RangeAbilities;

    public float Health { get; set; } //health float 

    private void Awake()
    {
        if (PH) Destroy(gameObject);
        PH = this;
        DontDestroyOnLoad(gameObject);

        loadPlayerPrefs();
    }

    private void OnDestroy()
    {
        SavePlayerPrefs();
        Debug.Log("Saving Player Prefs");
    }

    private void loadPlayerPrefs()
    {
        if (PlayerPrefs.HasKey("ability0"))
        {
            int index = PlayerPrefs.GetInt("ability0");
            index = Mathf.Clamp(index, 0, MeleeAbilities.Count - 1);
            Melee = MeleeAbilities[index];
        }
        if (PlayerPrefs.HasKey("ability1"))
        {
            int index = PlayerPrefs.GetInt("ability1");
            Protection = ProtectionAbilities[PlayerPrefs.GetInt("ability1")];
        }
        if (PlayerPrefs.HasKey("ability2"))
        {
            Range = RangeAbilities[PlayerPrefs.GetInt("ability2")];
        }
        if (PlayerPrefs.HasKey("health"))
        {
            Health = PlayerPrefs.GetFloat("health");
        }
    }

    public void SavePlayerPrefs()
    {
        if (Melee) PlayerPrefs.SetInt("ability0", MeleeAbilities.IndexOf(Melee));
        if (Protection) PlayerPrefs.SetInt("ability1", ProtectionAbilities.IndexOf(Protection));
        if (Range) PlayerPrefs.SetInt("ability2", RangeAbilities.IndexOf(Range));
        PlayerPrefs.SetFloat("health", Health);
    }
}
