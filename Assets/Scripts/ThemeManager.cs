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


    [Header("Sprite Themes: [Background, Ball, PaddleR, PaddleL]")]  //NOTE: ORDER THEM CORRECTLY IN EDITOR; ASSIGNS SPRITE BY ORDER IN ARRAY
   
    private Sprite[] chosenTheme;

    // current theme selected.
    private Theme currentTheme;

    // array of themes to choose from.
    // selected in editor.
    [Header("Themes")]
    public Theme[] themes;


    //sprites to apply to objects;
    [Header("Default")]
    public Sprite[] defaultTheme;

    [Header("Gold")]
    public Sprite[] goldTheme;

    [Header("Halloween")]
    public Sprite[] halloweenTheme;

    // temporary id variable for pre-ui testing.
    private int TEMPThemeID = 0;

   /* [Header("Sound: [Music, SFX]")]
   private SOUND[] chosenSound;

   public SOUND[] defaultSound
   public SOUND[] goldSound
   public SOUND[] halloweenSound
   */



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        PickTheme(TEMPThemeID);
    }

    // Update is called once per frame
    void Update()
    {
        // switches theme on space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ++TEMPThemeID;
            TEMPThemeID%=3;
            PickTheme(TEMPThemeID);
        }
    }

    // takes a theme, implements into play
    public void PickTheme(Theme theme)
    {
        currentTheme = theme;
        ChangeTheme(currentTheme);
    }
    public void PickTheme(int themeId)  //each theme corresponds to an int, so input int to change theme
    {
        PickTheme(themes[themeId]);
    }

    // implements the provided theme.
    public void ChangeTheme(Theme theme)
    {
        background.sprite = theme.Background;
        ball.sprite = theme.Ball;
        paddleL.sprite = theme.Paddle;
        paddleR.sprite = theme.Paddle;
    }
}
