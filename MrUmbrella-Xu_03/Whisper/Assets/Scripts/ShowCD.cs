using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCD : MonoBehaviour
{
    public Text[] CDtext;
    public Image[] CDImage;
    public float[] differences;
    public GameObject[] CDPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerDeadManager>().isPlayerDied == false)
        {
            if (differences[0] <= 1 && differences[0] >= 0)
            {
                differences[0] = Mathf.Round((Time.time - FindObjectOfType<PlayerAttack>().MeleeNextAttackTime) * 10);
                differences[0] = differences[0] / 10;
            }
            else
            {
                differences[0] = Mathf.Round(Time.time - FindObjectOfType<PlayerAttack>().MeleeNextAttackTime);
                CDPanel[0].SetActive(true);
            }

            if (differences[0] > 0)
            {
                differences[0] = 0;
                CDPanel[0].SetActive(false);
            }

            CDtext[0].text = (-differences[0]).ToString();


            if (differences[1] <= 1 && differences[1] >= 0)
            {
                differences[1] = Mathf.Round((Time.time - FindObjectOfType<PlayerAttack>().RangeNextAttackTime) * 10);
                differences[1] = differences[1] / 10;
            }
            else
            {
                differences[1] = Mathf.Round(Time.time - FindObjectOfType<PlayerAttack>().RangeNextAttackTime);
                CDPanel[1].SetActive(true);
            }


            if (differences[1] > 0)
            {
                differences[1] = 0;
                CDPanel[1].SetActive(false);
            }

            CDtext[1].text = (-differences[1]).ToString();

            //protection

            if (differences[2] <= 1 && differences[2] >= 0)
            {
                differences[2] = Mathf.Round((Time.time - FindObjectOfType<PlayerAttack>().ProtectionNextAttackTime) * 10);
                differences[2] = differences[2] / 10;
                CDPanel[2].SetActive(true);
            }
            else
            {
                differences[2] = Mathf.Round(Time.time - FindObjectOfType<PlayerAttack>().ProtectionNextAttackTime);
            }


            if (differences[2] > 0)
            {
                differences[2] = 0;
                CDPanel[2].SetActive(false);
            }

            CDtext[2].text = (-differences[2]).ToString();

            if (PlayerHandler.PH.Melee) CDImage[0].sprite = PlayerHandler.PH.Melee.AbilitySprite;
            if(PlayerHandler.PH.Range) CDImage[1].sprite = PlayerHandler.PH.Range.AbilitySprite;
            if (PlayerHandler.PH.Protection) CDImage[2].sprite = PlayerHandler.PH.Protection.AbilitySprite;

        }

    }
}
