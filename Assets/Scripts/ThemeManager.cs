using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
<<<<<<< Updated upstream
    [Header("Renderers")]
=======
    [Header("Renderers")]   //objects themselves
>>>>>>> Stashed changes
    public SpriteRenderer background;
    public SpriteRenderer ball;
    public SpriteRenderer paddleR;
    public SpriteRenderer paddleL;

<<<<<<< Updated upstream
    [Header("Themes: [Background, Ball, Paddle]")]

=======
    [Header("Themes: [Background, Ball, Paddle]")]  //NOTE: ORDER THEM CORRECTLY IN EDITOR; ASSIGNS SPRITE BY ORDER IN ARRAY

    
    //sprites to apply to objects;
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
    public void PickTheme(int themeId)
=======
    
    public void PickTheme(int themeId)  //each theme corresponds to an int, so input int to change theme
>>>>>>> Stashed changes
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

    
<<<<<<< Updated upstream

    public void ChangeSprites(Sprite[] theme)
=======
    public void ChangeSprites(Sprite[] theme)   //each theme is an array of sprites, so sets each sprite in order
>>>>>>> Stashed changes
    {
        background.sprite = theme[0];
        ball.sprite = theme[1];
        paddleL.sprite = theme[2];
        paddleR.sprite = theme[2];
    }
}
