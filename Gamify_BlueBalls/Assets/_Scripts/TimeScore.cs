using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeScore : MonoBehaviour {
    public GameObject text0;
    public float timeScore;
    public bool stopTime;
    public float pointsScore;
    
    public float finalScore;

    public float maxMultiplier = 5;
    public float maxTime = 40;

    private float multiplier;

	// Use this for initialization
	void Start () {
        timeScore = 0;
        stopTime = false;
        pointsScore = ShootyScript.score;
        finalScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        //initialize the score from scoreObject somewhere here (pointsScore = scoreObject.GetComponent<scriptnaam>()."puntenscore")
        if (!stopTime) {
            timeScore += Time.deltaTime;

            multiplier = 1/timeScore / maxTime * maxMultiplier;
            finalScore = multiplier * pointsScore;
            text0.GetComponent<Text>().text = "Points: " + Mathf.RoundToInt(pointsScore);
        } else 
        //Assign stopTime from another script to true when the game is over
        if (stopTime) {

            multiplier = 1/timeScore / maxTime * maxMultiplier;
            finalScore = multiplier * pointsScore;
            text0.GetComponent<Text>().text = "Time: " + Mathf.RoundToInt(finalScore) + "\n" +
                "Points Scored: " + Mathf.RoundToInt(pointsScore) + "\n" + "Final score: " + Mathf.RoundToInt(finalScore);
        }
        if (Input.GetKeyDown(KeyCode.Space)) stopTime = true;
	}
    public void Stop() {
        stopTime = true;
    }
}
