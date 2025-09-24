using System.Diagnostics;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score {get; private set;} 
    int winningScore = 7;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
