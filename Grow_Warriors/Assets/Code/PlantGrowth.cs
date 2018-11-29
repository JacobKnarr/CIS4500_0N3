using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantGrowth : MonoBehaviour {

    public Canvas mainScreen;
    public Button GrowthDialog;

    public float nextChange = 0.0f;
    public float interval = 10f;
    public int level = 1;

    private float growthMod;

    Sprite plantLevel1;
    Sprite plantLevel2;
    Sprite plantLevel3;

    GameObject plant;
	// Use this for initialization
	void Start () {
        plant = GameObject.Find("Plant");
        plantLevel1 = Resources.Load<Sprite>("Plants/Plant_Stage1");
        plantLevel2 = Resources.Load<Sprite>("Plants/Plant_Stage2");
        plantLevel3 = Resources.Load<Sprite>("Plants/Plant_Stage3");
    }
	
	// Update is called once per frame
	void Update () {
        growthMod = GameObject.Find("StartUp").GetComponent<updaterScript>().modifier;

        if (Time.time > nextChange){
            nextChange += (interval * growthMod);
            Debug.Log("Changing Plant", gameObject);
            if (level == 1)
            {
                // change to sprite 2
                plant.GetComponent<Image>().sprite = plantLevel2;
                level++;
                Debug.Log(growthMod, gameObject);
            }
            else if (level == 2)
            {
                // change to sprite 3
                plant.GetComponent<Image>().sprite = plantLevel3;
                level++;
                Debug.Log(growthMod, gameObject);
            }
            else
            {
                if (!GrowthDialog.gameObject.activeSelf)
                    GrowthDialog.gameObject.SetActive(true);
            }
        }
	}

    public void resetPlant()
    {
        GrowthDialog.gameObject.SetActive(false);
        level = 1;
        plant.GetComponent<Image>().sprite = plantLevel1;
        GameObject.Find("StartUp").GetComponent<updaterScript>().currency += 1000;
    }
}
