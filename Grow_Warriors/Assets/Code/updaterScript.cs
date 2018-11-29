using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class updaterScript : MonoBehaviour {

    public int currency;
    public int currentPot;
    public int currentLight;
    public int currentFert;

    public float modifier;

    public bool lightStandBought = true;
    public bool lightEfficBought = false;
    public bool lightLampBought = false;
    public bool lightIndusBought = false;

    public bool fertStandBought = true;
    public bool fertPlusBought = false;
    public bool fertGoldBought = false;
    public bool fertGoldPlusBought = false;

    public bool potStandBought = true;
    public bool potChromeBought = false;
    public bool potGoldBought = false;

    public Text coinText;
    public Text skinText;
    public Text mainText;

    public Image potImage;
    public Image lightImage;

    public Image lightPrice1;
    public Image lightPrice2;
    public Image lightPrice3;
    public Image lightPrice4;

    public Image fertPrice1;
    public Image fertPrice2;
    public Image fertPrice3;
    public Image fertPrice4;

    public Image potPrice1;
    public Image potPrice2;
    public Image potPrice3;

    Sprite potStand;
    Sprite potChrome;
    Sprite potGold;

    Sprite lightStand;
    Sprite lightEffic;
    Sprite lightLamp;
    Sprite lightIndus;

    Sprite price1;
    Sprite price2;
    Sprite price3;
    Sprite price4;

    Sprite priceSlashed1;
    Sprite priceSlashed2;
    Sprite priceSlashed3;
    Sprite priceSlashed4;

    private void Awake()
    {
        potStand = Resources.Load<Sprite>("Pots/FlowerPot_Standard");
        potChrome = Resources.Load<Sprite>("Pots/FlowerPot_Chrome");
        potGold = Resources.Load<Sprite>("Pots/FlowerPot_Gold");

        lightStand = Resources.Load<Sprite>("Lights/Light_Standard");
        lightEffic = Resources.Load<Sprite>("Lights/Light_Efficient");
        lightLamp = Resources.Load<Sprite>("Lights/Light_Lamp");
        lightIndus = Resources.Load<Sprite>("Lights/Light_Industrial");

        price1 = Resources.Load<Sprite>("Prices/Price1");
        price2 = Resources.Load<Sprite>("Prices/Price2");
        price3 = Resources.Load<Sprite>("Prices/Price3");
        price4 = Resources.Load<Sprite>("Prices/Price4");

        priceSlashed1 = Resources.Load<Sprite>("Prices/Price1_Slashed");
        priceSlashed2 = Resources.Load<Sprite>("Prices/Price2_Slashed");
        priceSlashed3 = Resources.Load<Sprite>("Prices/Price3_Slashed");
        priceSlashed4 = Resources.Load<Sprite>("Prices/Price4_Slashed");
    }

    // Use this for initialization
    void Start () {

        // Checks to make sure the coins object is not null
        if (coinText == null) Debug.Log("Null Coins", gameObject);

        currency = 0;
        currentPot = 1;
        currentLight = 1;
        currentFert = 1;

        // Loads in the currency data from file
        if (File.Exists(Application.persistentDataPath + "/PlayerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat", FileMode.Open);

            if (file.Length == 0)
            {
                currency = 0;
                file.Close();
                return;
            }
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            currency = data.totalCurrency;
        }

    }
	
	// Update is called once per frame
	void Update () {
        // Updates the current cash text in the shop
        coinText.GetComponent<Text>().text = "CASH: $ " + currency.ToString();
        skinText.GetComponent<Text>().text = "CASH: $ " + currency.ToString();
        mainText.GetComponent<Text>().text = "$ " + currency.ToString();

        // Resets the modifier
        modifier = 1.0f;

        // Updates the currently chosen light
        switch(currentLight)
        {
            case 1:
                lightImage.GetComponent<Image>().sprite = lightStand;
                break;
            case 2:
                lightImage.GetComponent<Image>().sprite = lightEffic;
                modifier -= 0.1f;
                break;
            case 3:
                lightImage.GetComponent<Image>().sprite = lightLamp;
                modifier -= 0.25f;
                break;
            case 4:
                lightImage.GetComponent<Image>().sprite = lightIndus;
                modifier -= 0.4f;
                break;
            default:
                Debug.Log("Error in Light Image Update", gameObject);
                modifier -= 0f;
                break;
        }

        // Updates the modifier based on the fertilizer
        switch (currentFert)
        {
            case 2:
                modifier -= 0.1f;
                break;
            case 3:
                modifier -= 0.25f;
                break;
            case 4:
                modifier -= 0.4f;
                break;
            default:
                modifier -= 0f;
                break;
        }

        // Updates the currently chosen pot
        switch (currentPot)
        {
            case 1:
                potImage.GetComponent<Image>().sprite = potStand;
                modifier -= 0f;
                break;
            case 2:
                potImage.GetComponent<Image>().sprite = potChrome;
                modifier -= 0.05f;
                break;
            case 3:
                potImage.GetComponent<Image>().sprite = potGold;
                modifier -= 0.15f;
                break;
            default:
                Debug.Log("Error in Pot Image Update", gameObject);
                break;
        }

        //Light Price Updates
        if (lightStandBought) lightPrice1.GetComponent<Image>().sprite = priceSlashed1;
        else lightPrice1.GetComponent<Image>().sprite = price1;

        if (lightEfficBought) lightPrice2.GetComponent<Image>().sprite = priceSlashed2;
        else lightPrice2.GetComponent<Image>().sprite = price2;

        if (lightLampBought) lightPrice3.GetComponent<Image>().sprite = priceSlashed3;
        else lightPrice3.GetComponent<Image>().sprite = price3;

        if (lightIndusBought) lightPrice4.GetComponent<Image>().sprite = priceSlashed4;
        else lightPrice4.GetComponent<Image>().sprite = price4;

        // Fertilizer Price Updates
        if (fertStandBought) fertPrice1.GetComponent<Image>().sprite = priceSlashed1;
        else fertPrice1.GetComponent<Image>().sprite = price1;

        if (fertPlusBought) fertPrice2.GetComponent<Image>().sprite = priceSlashed2;
        else fertPrice2.GetComponent<Image>().sprite = price2;

        if (fertGoldBought) fertPrice3.GetComponent<Image>().sprite = priceSlashed3;
        else fertPrice3.GetComponent<Image>().sprite = price3;

        if (fertGoldPlusBought) fertPrice4.GetComponent<Image>().sprite = priceSlashed4;
        else fertPrice4.GetComponent<Image>().sprite = price4;

        // Pot Price Updates
        if (potStandBought) potPrice1.GetComponent<Image>().sprite = priceSlashed1;
        else potPrice1.GetComponent<Image>().sprite = price1;

        if (potChromeBought) potPrice2.GetComponent<Image>().sprite = priceSlashed3;
        else potPrice2.GetComponent<Image>().sprite = price3;

        if (potGoldBought) potPrice3.GetComponent<Image>().sprite = priceSlashed4;
        else potPrice3.GetComponent<Image>().sprite = price4;

    }
}
