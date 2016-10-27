using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    int gameScore;


    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ScoreIncrease(int scoreValue) {

        gameScore += scoreValue;
        
    }
}
