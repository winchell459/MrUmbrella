using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEnlarge : MonoBehaviour
{
    public void Enlarge(int enlarge)
    {
        transform.GetChild(0).GetComponent<Text>().fontSize = enlarge;
        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.25f);
    }
    public void DeFill()
    {
        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);
    }
    public void EnlargeButton (float size)
    {
        GetComponent<RectTransform>().localScale = new Vector3(size, size, size);
    }
}
