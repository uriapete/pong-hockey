using System.Diagnostics;
using System.Collections;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int scoreL {get; private set;}
    public int scoreR { get; private set; }
    int winningScore = 7;
    public Ball ballRef; //references Ball script
    

    public TextMeshProUGUI txtBoxL;
    public TextMeshProUGUI txtBoxR;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreL = 0;
        scoreR = 0;

        txtBoxL.text = scoreL.ToString();
        txtBoxR.text = scoreR.ToString();

        //Find the single instance of the Ball script in the scene.
        ballRef = FindFirstObjectByType<Ball>(); //assigns reference
        
    }




    // Update is called once per frame
    void Update()
    {

        //If a player scores, call function to add score
        if (ballRef.rightScored == true)          
        {
            AddToScore(1, "playerR");
            ballRef.rightScored = false;
        }
        else if (ballRef.leftScored == true)   
        {
            AddToScore(1, "playerL");
            ballRef.leftScored = false;
        }

        if (Input.GetKeyDown("space"))      //test: reset
        {
            GameOver();
        }
    }


    //Adds score, Updates score box, Checks if a player wins
    void AddToScore(int point, string player)
    {

        //Adds score, Updates score box
        if (player == "playerL")
        {
            scoreL += point;
            txtBoxL.text = scoreL.ToString();
        }
        else
        {
            scoreR += point;
            txtBoxR.text = scoreR.ToString();
        }


        //Checks a if player wins
        if (scoreL >= winningScore || scoreR >= winningScore)
        {
            if (player == "playerL")
            {
                txtBoxL.text = "You win!";
                txtBoxR.text = "You lose...";
            }
            else
            {
                txtBoxL.text = "You lose...";
                txtBoxR.text = "You win!";
            }

            //GameOver();
        }
    }

    //Resets the game
    void GameOver()
    {
        
            scoreL = 0;
            scoreR = 0;

            txtBoxL.text = scoreL.ToString();
            txtBoxR.text = scoreR.ToString();

    }

}
