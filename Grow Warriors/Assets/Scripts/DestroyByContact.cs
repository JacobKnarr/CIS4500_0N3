using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    private Transform othertf;
    private GameController gameController;

    public GameObject playerCollision;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find Game Controller script.");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        othertf = GetComponent<Transform>();
        if (othertf.tag == "Player")
        {
            return;
        }
        Collider C = this.GetComponent<Collider>();
        Collider otherC = othertf.GetComponent<Collider>();
        Physics.IgnoreCollision(otherC, C);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }
        othertf = GetComponent<Transform>();
        if (other.tag == "Player" && this.tag != "Coin")
        {
            Instantiate(playerCollision, othertf.position, othertf.rotation);
            gameController.GameOver();
            gameController.SaveMinigameData();
        }
        if (this.tag == "Coin")
        {
            Instantiate(playerCollision, othertf.position, othertf.rotation);
            gameController.AddCurrency();
        }
        if (other.tag != "Player")
        {
            Collider C = this.GetComponent<Collider>();
            Physics.IgnoreCollision(other, C);
            return;
        }
        if (this.tag != "Coin")
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}