using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButtonClick : MonoBehaviour {
    
    public Button btnLightStand;
    public Button btnLightEffic;
    public Button btnLightLamp;
    public Button btnLightIndus;
           
    public Button btnFertStand;
    public Button btnFertPlus;
    public Button btnFertGold;
    public Button btnFertGoldPlus;
           
    public Button btnPotStand;
    public Button btnPotChrome;
    public Button btnPotGold;

    public Button btnInsuff;

    public void click(Button btnPressed) {
        if (Button.ReferenceEquals(btnPressed, btnLightStand))
        {
            Debug.Log("Standard Light Clicked", gameObject);
            if (GameObject.Find("StartUp").GetComponent<updaterScript>().lightStandBought)
            {
                GameObject.Find("StartUp").GetComponent<updaterScript>().currentLight = 1;
                btnLightStand.interactable = false;
                btnLightEffic.interactable = true;
                btnLightLamp.interactable = true;
                btnLightIndus.interactable = true;
            }
            else
            {
                if (GameObject.Find("StartUp").GetComponent<updaterScript>().currency >= 50)
                {
                    GameObject.Find("StartUp").GetComponent<updaterScript>().lightStandBought = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currency -= 50;
                    btnLightStand.interactable = false;
                    btnLightEffic.interactable = true;
                    btnLightLamp.interactable = true;
                    btnLightIndus.interactable = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currentLight = 1;
                }
                else
                {
                    btnInsuff.gameObject.SetActive(true);
                }
            }
        }
        else if (Button.ReferenceEquals(btnPressed, btnLightEffic))
        {
            Debug.Log("Efficient Light Clicked", gameObject);
            if (GameObject.Find("StartUp").GetComponent<updaterScript>().lightEfficBought)
            {
                GameObject.Find("StartUp").GetComponent<updaterScript>().currentLight = 2;
                btnLightStand.interactable = true;
                btnLightEffic.interactable = false;
                btnLightLamp.interactable = true;
                btnLightIndus.interactable = true;
            }
            else
            {
                if (GameObject.Find("StartUp").GetComponent<updaterScript>().currency >= 150)
                {
                    GameObject.Find("StartUp").GetComponent<updaterScript>().lightEfficBought = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currency -= 150;
                    btnLightStand.interactable = true;
                    btnLightEffic.interactable = false;
                    btnLightLamp.interactable = true;
                    btnLightIndus.interactable = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currentLight = 2;
                }
                else
                {
                    btnInsuff.gameObject.SetActive(true);
                }
            }
        }
        else if (Button.ReferenceEquals(btnPressed, btnLightLamp))
        {
            Debug.Log("Lamp Clicked", gameObject);
            if (GameObject.Find("StartUp").GetComponent<updaterScript>().lightLampBought)
            {
                GameObject.Find("StartUp").GetComponent<updaterScript>().currentLight = 3;
                btnLightStand.interactable = true;
                btnLightEffic.interactable = true;
                btnLightLamp.interactable = false;
                btnLightIndus.interactable = true;
            }
            else
            {
                if (GameObject.Find("StartUp").GetComponent<updaterScript>().currency >= 300)
                {
                    GameObject.Find("StartUp").GetComponent<updaterScript>().lightLampBought = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currency -= 300;
                    btnLightStand.interactable = true;
                    btnLightEffic.interactable = true;
                    btnLightLamp.interactable = false;
                    btnLightIndus.interactable = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currentLight = 3;
                }
                else
                {
                    btnInsuff.gameObject.SetActive(true);
                }
            }
        }
        else if (Button.ReferenceEquals(btnPressed, btnLightIndus))
        {
            Debug.Log("Industrial Light Clicked", gameObject);
            if (GameObject.Find("StartUp").GetComponent<updaterScript>().lightIndusBought)
            {
                GameObject.Find("StartUp").GetComponent<updaterScript>().currentLight = 4;
                btnLightStand.interactable = true;
                btnLightEffic.interactable = true;
                btnLightLamp.interactable = true;
                btnLightIndus.interactable = false;
            }
            else
            {
                if (GameObject.Find("StartUp").GetComponent<updaterScript>().currency >= 600)
                {
                    GameObject.Find("StartUp").GetComponent<updaterScript>().lightIndusBought = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currency -= 600;
                    btnLightStand.interactable = true;
                    btnLightEffic.interactable = true;
                    btnLightLamp.interactable = true;
                    btnLightIndus.interactable = false;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currentLight = 4;
                }
                else
                {
                    btnInsuff.gameObject.SetActive(true);
                }
            }
        }
        else if (Button.ReferenceEquals(btnPressed, btnFertStand))
        {
            Debug.Log("Standard Fertilizer Clicked", gameObject);
            if (GameObject.Find("StartUp").GetComponent<updaterScript>().fertStandBought)
            {
                GameObject.Find("StartUp").GetComponent<updaterScript>().currentFert = 1;
                btnFertStand.interactable = false;
                btnFertPlus.interactable = true;
                btnFertGold.interactable = true;
                btnFertGoldPlus.interactable = true;
            }
            else
            {
                if (GameObject.Find("StartUp").GetComponent<updaterScript>().currency >= 50)
                {
                    GameObject.Find("StartUp").GetComponent<updaterScript>().fertStandBought = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currency -= 50;
                    btnFertStand.interactable = false;
                    btnFertPlus.interactable = true;
                    btnFertGold.interactable = true;
                    btnFertGoldPlus.interactable = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currentFert = 1;
                }
                else
                {
                    btnInsuff.gameObject.SetActive(true);
                }
            }
        }
        else if (Button.ReferenceEquals(btnPressed, btnFertPlus))
        {
            Debug.Log("Fertilizer Plus Clicked", gameObject);
            if (GameObject.Find("StartUp").GetComponent<updaterScript>().fertPlusBought)
            {
                GameObject.Find("StartUp").GetComponent<updaterScript>().currentFert = 2;
                btnFertStand.interactable = true;
                btnFertPlus.interactable = false;
                btnFertGold.interactable = true;
                btnFertGoldPlus.interactable = true;
            }
            else
            {
                if (GameObject.Find("StartUp").GetComponent<updaterScript>().currency >= 150)
                {
                    GameObject.Find("StartUp").GetComponent<updaterScript>().fertPlusBought = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currency -= 150;
                    btnFertStand.interactable = true;
                    btnFertPlus.interactable = false;
                    btnFertGold.interactable = true;
                    btnFertGoldPlus.interactable = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currentFert = 2;
                }
                else
                {
                    btnInsuff.gameObject.SetActive(true);
                }
            }
        }
        else if (Button.ReferenceEquals(btnPressed, btnFertGold))
        {
            Debug.Log("Fertilizer Gold Clicked", gameObject);
            if (GameObject.Find("StartUp").GetComponent<updaterScript>().fertGoldBought)
            {
                GameObject.Find("StartUp").GetComponent<updaterScript>().currentFert = 3;
                btnFertStand.interactable = true;
                btnFertPlus.interactable = true;
                btnFertGold.interactable = false;
                btnFertGoldPlus.interactable = true;
            }
            else
            {
                if (GameObject.Find("StartUp").GetComponent<updaterScript>().currency >= 300)
                {
                    GameObject.Find("StartUp").GetComponent<updaterScript>().fertGoldBought = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currency -= 300;
                    btnFertStand.interactable = true;
                    btnFertPlus.interactable = true;
                    btnFertGold.interactable = false;
                    btnFertGoldPlus.interactable = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currentFert = 3;
                }
                else
                {
                    btnInsuff.gameObject.SetActive(true);
                }
            }
        }
        else if (Button.ReferenceEquals(btnPressed, btnFertGoldPlus))
        {
            Debug.Log("Fertilizer Gold Plus Clicked", gameObject);
            if (GameObject.Find("StartUp").GetComponent<updaterScript>().fertGoldPlusBought)
            {
                GameObject.Find("StartUp").GetComponent<updaterScript>().currentFert = 4;
                btnFertStand.interactable = true;
                btnFertPlus.interactable = true;
                btnFertGold.interactable = true;
                btnFertGoldPlus.interactable = false;
            }
            else
            {
                if (GameObject.Find("StartUp").GetComponent<updaterScript>().currency >= 600)
                {
                    GameObject.Find("StartUp").GetComponent<updaterScript>().fertGoldPlusBought = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currency -= 600;
                    btnFertStand.interactable = true;
                    btnFertPlus.interactable = true;
                    btnFertGold.interactable = true;
                    btnFertGoldPlus.interactable = false;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currentFert = 4;
                }
                else
                {
                    btnInsuff.gameObject.SetActive(true);
                }
            }
        }
        else if (Button.ReferenceEquals(btnPressed, btnPotStand))
        {
            Debug.Log("Standard Pot Clicked", gameObject);
            if (GameObject.Find("StartUp").GetComponent<updaterScript>().potStandBought)
            {
                GameObject.Find("StartUp").GetComponent<updaterScript>().currentPot = 1;
                btnPotStand.interactable = false;
                btnPotChrome.interactable = true;
                btnPotGold.interactable = true;
            }
            else
            {
                if (GameObject.Find("StartUp").GetComponent<updaterScript>().currency >= 50)
                {
                    GameObject.Find("StartUp").GetComponent<updaterScript>().potStandBought = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currency -= 50;
                    btnPotStand.interactable = false;
                    btnPotChrome.interactable = true;
                    btnPotGold.interactable = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currentPot = 1;
                }
                else
                {
                    btnInsuff.gameObject.SetActive(true);
                }
            }
        }
        else if (Button.ReferenceEquals(btnPressed, btnPotChrome))
        {
            Debug.Log("Chrome Pot Clicked", gameObject);
            if (GameObject.Find("StartUp").GetComponent<updaterScript>().potChromeBought)
            {
                GameObject.Find("StartUp").GetComponent<updaterScript>().currentPot = 2;
                btnPotStand.interactable = true;
                btnPotChrome.interactable = false;
                btnPotGold.interactable = true;
            }
            else
            {
                if (GameObject.Find("StartUp").GetComponent<updaterScript>().currency >= 300)
                {
                    GameObject.Find("StartUp").GetComponent<updaterScript>().potChromeBought = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currency -= 300;
                    btnPotStand.interactable = true;
                    btnPotChrome.interactable = false;
                    btnPotGold.interactable = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currentPot = 2;
                }
                else
                {
                    btnInsuff.gameObject.SetActive(true);
                }
            }
        }
        else if (Button.ReferenceEquals(btnPressed, btnPotGold))
        {
            Debug.Log("Gold Pot Clicked", gameObject);
            if (GameObject.Find("StartUp").GetComponent<updaterScript>().potGoldBought)
            {
                GameObject.Find("StartUp").GetComponent<updaterScript>().currentPot = 3;
                btnPotStand.interactable = true;
                btnPotChrome.interactable = true;
                btnPotGold.interactable = false;
            }
            else
            {
                if (GameObject.Find("StartUp").GetComponent<updaterScript>().currency >= 600)
                {
                    GameObject.Find("StartUp").GetComponent<updaterScript>().potGoldBought = true;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currency -= 600;
                    btnPotStand.interactable = true;
                    btnPotChrome.interactable = true;
                    btnPotGold.interactable = false;
                    GameObject.Find("StartUp").GetComponent<updaterScript>().currentPot = 3;
                }
                else
                {
                    btnInsuff.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            Debug.Log("Error in Button Click", gameObject);
        }
    }
}
