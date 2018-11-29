using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class ChangeLight : MonoBehaviour
{
    GameObject img;

    void Start()
    {
        img = GameObject.Find("Light"); 
    }

    public void change(Sprite differentSprite)
    {
        img.GetComponent<Image>().sprite = differentSprite; //sets sprite renderers sprite
    }

}
