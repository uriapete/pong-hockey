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


    [Header("Sprite Themes: [Background, Ball, Paddle]")]  //NOTE: ORDER THEM CORRECTLY IN EDITOR; ASSIGNS SPRITE BY ORDER IN ARRAY
   
    private Sprite[] chosenTheme;


    //sprites to apply to objects;
    [Header("Default")]
    public Sprite[] defaultTheme;

    [Header("Gold")]
    public Sprite[] goldTheme;

    [Header("Halloween")]
    public Sprite[] halloweenTheme;



   /* [Header("Sound: [Music, SFX]")]
   private SOUND[] chosenSound;

   public SOUND[] defaultSound
   public SOUND[] goldSound
   public SOUND[] halloweenSound
   */



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
                chosenTheme = defaultTheme;
                //chosenSound = defaultSound;
                break;
            case 1:
                chosenTheme = goldTheme;
                //chosenSound = goldSound;
                break;

            case 2:
                //chosenTheme = ;
                //chosenSound = ;
                break;

            case 3:
                //chosenTheme =
                //chosenSound = ;
                break;

            case 4:
                //chosenTheme = ;
                //chosenSound = ;
                break;

            default:
                chosenTheme = defaultTheme;
                //chosenSound = defaultSound;
                break;

        }

        ChangeTheme(chosenTheme);
        //ChangeTheme(chosenTheme, chosenSound);
    }

    

    public void ChangeTheme(Sprite[] theme)   //each theme is an array of sprites, so sets each sprite in order
    //chosenTheme(Sprite[] theme, SOUND[] sound)
    {
        background.sprite = theme[0];
        ball.sprite = theme[1];
        paddleL.sprite = theme[2];
        paddleR.sprite = theme[2];

        //music = sound[0]
        //SFX = sound[1]
    }
}
