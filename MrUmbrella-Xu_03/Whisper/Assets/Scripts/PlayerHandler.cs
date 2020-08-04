using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public AbilityObject Melee { get; set; } //ability0 playerpref int 0 or 1
    public AbilityObject Range { get; set; } //ability1 playerpref int 0 or 1
    public AbilityObject Protection { get; set; } //ability2 playerpref int 0 or 1

    public List<AbilityObject> MeleeAbilities;
    public List<AbilityObject> ProtectionAbilities;
    public List<AbilityObject> RangeAbilities;

    public static PlayerHandler PH;
    public GameObject PlayerPrefab; //health float number

    public float Health { get; set; }

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
        if (PlayerPrefs.HasKey("ability0"))
        {
            int index = PlayerPrefs.GetInt("ability0");
            index = (int)Mathf.Clamp(index, 0, MeleeAbilities.Count - 1); //[1,2,3,4,5,6]
            Melee = MeleeAbilities[index];
        }
        if (PlayerPrefs.HasKey("ability1"))
        {
            int index = PlayerPrefs.GetInt("ability1");
            index = Mathf.Clamp(index, 0, ProtectionAbilities.Count - 1);
            Protection = ProtectionAbilities[index];
        } 
        if (PlayerPrefs.HasKey("ability2"))
        {
            int index = PlayerPrefs.GetInt("ability2");
            index = Mathf.Clamp(index, 0, RangeAbilities.Count - 1);
            Range = RangeAbilities[index];
        }
        if (PlayerPrefs.HasKey("Health"))
        {
            Health = PlayerPrefs.GetFloat("Health");
            //Debug.Log("Health: " + Health);
        }
    }

    public void SavePlayerPrefs()
    {
        if (Melee) PlayerPrefs.SetInt("ability0", MeleeAbilities.IndexOf(Melee));
        if(Protection) PlayerPrefs.SetInt("ability1", ProtectionAbilities.IndexOf(Protection));
        if (Range) PlayerPrefs.SetInt("ability2", RangeAbilities.IndexOf(Range));
        Health = FindObjectOfType<PlayerController>().gameObject.GetComponent<Health>().health;
        PlayerPrefs.SetFloat("Health", Health);
        Debug.Log("Saving Player Health: " + FindObjectOfType<PlayerController>().gameObject.GetComponent<Health>().health);
    }
}
