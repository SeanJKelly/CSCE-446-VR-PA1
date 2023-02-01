using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackTreasures : MonoBehaviour
{
    [SerializeField] Canvas endGameScreen;
    [SerializeField] Stopwatch stopwatch;
    int currNumOfTreasures = 0;
    private void Start()
    {
        // Wait for the treasures to instantiate first
        StartCoroutine(Wait(1.0f));
    }
    
    public void decreaseTreasure()
    {
        currNumOfTreasures--;
        if(currNumOfTreasures <= 0)
        {
            stopwatch.stopStopwatch();
            ShowEndGameScreen();
        }
    }

    int GetNumOfTreasures() { return GameObject.FindGameObjectsWithTag("Treasure").Length; }
    void ShowEndGameScreen()
    {
        // Check if end game screen was supplied
        Debug.Assert(endGameScreen != null);
        endGameScreen.GetComponent<Canvas>().enabled = true;
    }

    // Helper functions
    IEnumerator Wait(float timeToWait) 
    { 
        yield return new WaitForSeconds(timeToWait);
        //Debug.Log("Num of treasures: " + GameObject.FindGameObjectsWithTag("Treasure").Length);
        currNumOfTreasures = GetNumOfTreasures();
    }
}