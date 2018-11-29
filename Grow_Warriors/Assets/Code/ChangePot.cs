using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePot : MonoBehaviour
{
    GameObject img;

    void Start()
    {
        img = GameObject.Find("Pot");
    }

    public void change(Sprite differentSprite)
    {
        img.GetComponent<Image>().sprite = differentSprite;
    }

}
