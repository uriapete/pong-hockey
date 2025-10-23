using System.Diagnostics;
using System.Collections;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;
using System.Threading;


public class GameManager : MonoBehaviour
{
    public int scoreL {get; private set;}
    public int scoreR { get; private set; }
    int winningScore = 7;
    public Ball ballRef; //references Ball script
    

    public TextMeshProUGUI txtBoxL;
    public TextMeshProUGUI txtBoxR;

    public GameObject mainMenu;
    public GameObject pauseMenu;

    private bool isPaused;
    public bool gameActive;


    // what angle will the ball be served at next?
    private float servingAngle;
    
    // base angles for serving left or right
    private readonly float baseServeAngleL = 3 * Mathf.PI / 4;
    private readonly float baseServeAngleR = -1 * Mathf.PI / 4;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //main menu -- game does not start until play
        gameActive = false;
        PauseGame();
        pauseMenu.SetActive(false);
        mainMenu.SetActive(true);

        scoreL = 0;
        scoreR = 0;

        txtBoxL.text = scoreL.ToString();
        txtBoxR.text = scoreR.ToString();

        //Find the single instance of the Ball script in the scene.
        ballRef = FindFirstObjectByType<Ball>(); //assigns reference

        RandomNumberGenerator.Create();

        // sets the starting serving angle
        // random selection of any of the 4 diagonal directions
        servingAngle = ((RandomNumberGenerator.GetInt32(8) * 2) + 1) * (Mathf.PI / 4);
        // set ball ref, will serve when ball is Ready
        ballRef.StartServeAngle = servingAngle;
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

        if (gameActive && Input.GetKeyDown("escape"))      //pause the game
        {
            if (isPaused)
            {
                ResumeGameOrPreviousPage();
            }
            else
            {
                PauseGame();
            }

        }
    }


    //Adds score, Updates score box, Checks if a player wins
    void AddToScore(int point, string player)
    {

        //Adds score, Updates score box
        // sets serving angle to the round loser's side (base angle)
        if (player == "playerL")
        {
            scoreL += point;
            txtBoxL.text = scoreL.ToString();
            servingAngle = baseServeAngleR;
        }
        else
        {
            scoreR += point;
            txtBoxR.text = scoreR.ToString();
            servingAngle = baseServeAngleL;
        }

        // this determines whether the ball goes to the up diag or down diag
        servingAngle += 2 * RandomNumberGenerator.GetInt32(2) * Mathf.PI / 4;


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
            return;
        }

        // if no one won, serve the ball
        ballRef.StartNewRound(servingAngle);
    }

    //Resets the game
    void GameOver()
    {
        
            scoreL = 0;
            scoreR = 0;

            txtBoxL.text = scoreL.ToString();
            txtBoxR.text = scoreR.ToString();

    }

    public void PauseGame()    //pause game; clock stops
    {
        isPaused = true;
        isPaused = true;
        Time.timeScale = 0f;
        pauseMenu.transform.Find("PauseMainMenu").gameObject.SetActive(true);
        pauseMenu.SetActive(true);
    }

    public void ResumeGameOrPreviousPage()    //resume game; clock resumes
    {

        gameActive = true;
        if (!pauseMenu.transform.Find("PauseSettingsMenu").gameObject.activeSelf)    //if settings menu is open, go back to main pause menu
        {
            isPaused = false;
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
        else     //if main menu is open, close pause menu and resume game
        {
            pauseMenu.transform.Find("PauseSettingsMenu").gameObject.SetActive(false);
            pauseMenu.transform.Find("PauseMainMenu").gameObject.SetActive(true);
        }
        

    }

}
