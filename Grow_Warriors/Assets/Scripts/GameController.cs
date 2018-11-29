using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
class PlayerData
{
    public int highScore;
    public int totalCurrency;
}

public class GameController : MonoBehaviour
{
    public GameObject[] collidables;
    public Vector3[] spawnValues;
    public int hazardCount;
    public float startWait;
    public float spawnWait;

    public Text scoreText;
    public Text currencyText;
    public Text gameOverText;
    public GameObject restartButton;
    public GameObject mainScreenButton;

    private Mover moveSpeed1;
    private Mover moveSpeed2;
    private bool gameOver;
    private float startTime;
    private int score;
    private int currency;

    private int highScore;
    private int totalCurrency;
    
    void Start()
    {
        score = 0;
        gameOver = false;
        gameOverText.text = "";
        restartButton.SetActive(false);
        mainScreenButton.SetActive(false);
        
        moveSpeed1 = collidables[0].GetComponent<Mover>();
        moveSpeed1.speed = 6.0f;
        moveSpeed2 = collidables[1].GetComponent<Mover>();
        moveSpeed2.speed = 6.5f;

        startTime = Time.time;

        UpdateScore();
        UpdateCurrency();
        StartCoroutine(SpawnWaves());
    }


    void Update()
    {
        if(!gameOver)
        {
            this.AddScore((int)(Time.time - startTime));
        }
    }

    IEnumerator SpawnWaves()
    {
        int spawnOption;
        int spawnOption1;
        int spawnOption2;
        int secondSpawnChance;
        int coinChance;

        GameObject hazard;
        Vector3 spawnPosition;
        Quaternion spawnRotation;

        yield return new WaitForSeconds(startWait);
        while(true)
        {
            
            for(int i = 0; i < hazardCount; i++)
            {
                spawnOption = Random.Range(0, 4);
                secondSpawnChance = Random.Range(0, 100);
                coinChance = Random.Range(0, 100);

                do
                {
                    spawnOption1 = Random.Range(0, 4);
                }
                while (spawnOption1 == spawnOption);

                do
                {
                    spawnOption2 = Random.Range(0, 4);
                }
                while (spawnOption2 == spawnOption || spawnOption2 == spawnOption1);

                spawnRotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
                hazard = collidables[(int)Mathf.Round(Random.value)];
                spawnPosition = new Vector3(spawnValues[spawnOption].x, spawnValues[spawnOption].y, spawnValues[spawnOption].z);
                
                Instantiate(hazard, spawnPosition, spawnRotation);

                if (secondSpawnChance < 33)
                {
                    hazard = collidables[(int)Mathf.Round(Random.value)];
                    spawnPosition = new Vector3(spawnValues[spawnOption1].x, spawnValues[spawnOption1].y, spawnValues[spawnOption1].z);
                    Instantiate(hazard, spawnPosition, spawnRotation);
                }

                if (coinChance > 55 && coinChance < 88)
                {
                    hazard = collidables[2];
                    spawnPosition = new Vector3(spawnValues[spawnOption2].x, spawnValues[spawnOption2].y, spawnValues[spawnOption2].z);
                    Instantiate(hazard, spawnPosition, spawnRotation);
                }

                yield return new WaitForSeconds(spawnWait);
            }

            if(spawnWait > 0.7f)
            {
                spawnWait -= 0.1f;
            }
            if(moveSpeed1.speed < 10.0f)
            {
                moveSpeed1.speed += 0.5f;
            }
            if(moveSpeed2.speed < 10.0f)
            {
                moveSpeed2.speed += 0.6f;
            }

            if(gameOver)
            {
                mainScreenButton.SetActive(true);
                restartButton.SetActive(true);
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void AddCurrency()
    {
        currency += 1;
        UpdateCurrency();
    }

    void UpdateScore()
    {
        float showScore = Mathf.Floor(score / 1000);
        scoreText.text = "Score: " + showScore;
    }

    void UpdateCurrency()
    {
        currencyText.text = "Currency: " + currency;
    }

    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnMainScene()
    {
        //Change this to go to the main scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SaveMinigameData()
    {
        LoadMinigameData();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/PlayerInfo.dat");
        PlayerData data = new PlayerData();

        if(highScore < score)
        {
            data.highScore = score;
        }
        else
        {
            data.highScore = highScore;
        }
        data.totalCurrency = totalCurrency + currency;

        Debug.Log(data.highScore);
        Debug.Log(data.totalCurrency);

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadMinigameData()
    {
        if(File.Exists(Application.persistentDataPath + "/PlayerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/PlayerInfo.dat", FileMode.Open);

            if (file.Length == 0)
            {
                highScore = 0;
                totalCurrency = 0;
                file.Close();
                return;
            }
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            highScore = data.highScore;
            totalCurrency = data.totalCurrency;
        }
    }

    Scene currentScene;
    public void NextScene()
    {
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "App")
        {
            SceneManager.LoadScene("Minigame", LoadSceneMode.Single);
            //SceneManager.UnloadSceneAsync("App");
        }
        else
        {
            SceneManager.LoadScene("App", LoadSceneMode.Single);
        }
    }
}