using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{

    [Header("Renderers")]   //objects themselves

    public SpriteRenderer background;
    public SpriteRenderer ball;
    public SpriteRenderer paddleR;
    public SpriteRenderer paddleL;


    [Header("Themes: [Background, Ball, Paddle]")]  //NOTE: ORDER THEM CORRECTLY IN EDITOR; ASSIGNS SPRITE BY ORDER IN ARRAY

    
    //sprites to apply to objects;
    [Header("Default")]
    public Sprite[] defaultTheme;

    [Header("Gold")]
    public Sprite[] goldTheme;

    [Header("Halloween")]
    public Sprite[] halloweenTheme;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

       

        


        PickTheme(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PickTheme(int themeId)  //each theme corresponds to an int, so input int to change theme

    {
        switch (themeId)
        {
            case 0:
                ChangeSprites(defaultTheme);
                break;
            case 1:
                ChangeSprites(goldTheme);
                break;

            case 2:
                break;

            default:
                ChangeSprites(defaultTheme);
                break;



        }
    }

    

    public void ChangeSprites(Sprite[] theme)   //each theme is an array of sprites, so sets each sprite in order
    {
        background.sprite = theme[0];
        ball.sprite = theme[1];
        paddleL.sprite = theme[2];
        paddleR.sprite = theme[2];
    }
}
