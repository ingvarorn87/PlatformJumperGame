using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour {

    public float scrollSpeed = 5.0f;
    public GameObject[] challenges;
    public float frequency = 0.5f;
    float counter = 0.0f;
    public Transform challengesSpawnPoint;
    bool isGameOver = false;
    GameController myGameController;


	// Use this for initialization
	void Start () {
        GenerateRandomChallenge();
        myGameController = GameObject.FindObjectOfType<GameController>();
    }
	
	// Update is called once per frame
	void Update () {
        

        if (isGameOver)
        {
            return;
        }

        // Generate objects
        if (counter <= 0.0f)
        {
            GenerateRandomChallenge();
        }
        else
        {
            counter -= Time.deltaTime * frequency;
        }


        // scroller

        GameObject currentChild;
       for(int i = 0; i < transform.childCount; i++)
        {
            currentChild = transform.GetChild(i).gameObject;
            Scroller(currentChild);
            if (currentChild.transform.position.x <= -15.0f)
            {
                Destroy(currentChild);
            }
        }
    
	}

    void Scroller (GameObject currentChallenge)
    {
        currentChallenge.transform.position -= Vector3.right * (scrollSpeed * Time.deltaTime);
    }

    void GenerateRandomChallenge()
    {
        // creating random GameChallenge and setting the parent object
        GameObject newChallenge =
        Instantiate(challenges[Random.Range(0, challenges.Length)], challengesSpawnPoint.position, Quaternion.identity)
        as GameObject;
        newChallenge.transform.parent = transform;

        counter = 1.0f;
    }

    public void GameOver()
    {
        isGameOver = true;
        transform.GetComponent<GameController>().GameOver();
    }
    public void EasyDifficulty()
    {
        scrollSpeed = 5.0f;
        myGameController.Restart();
    }
    public void MediumDifficulty()
    {
        scrollSpeed = 7.0f;
        myGameController.Restart();
    }
    public void HardDifficulty()
    {
        scrollSpeed = 9.0f;
        myGameController.Restart();
    }
}
