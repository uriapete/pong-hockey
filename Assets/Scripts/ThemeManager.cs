using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class ThemeManager : MonoBehaviour
{
    public SpriteRenderer background;
    public SpriteRenderer ball;
    public SpriteRenderer paddleR;
    public SpriteRenderer paddleL;

    public static Sprite windowsxpBG;
    public static Sprite dvdLogo;
    public static Sprite goldDvdLogo;


    public Sprite[] defaultTheme = { windowsxpBG, dvdLogo, goldDvdLogo};
// Start is called once before the first execution of Update after the MonoBehaviour is created
void Start()
    {

       

        


        ChangeTheme(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeTheme(int themeId)
    {
        switch (themeId)
        {
            case 0:
                ChangeSprites(defaultTheme);
                break;
            case 1:

                break;

            default:
                ChangeSprites(defaultTheme);
                break;



        }
    }

    void ChangeSprites(Sprite[] theme)
    {
        background.sprite = theme[0];
        ball.sprite = theme[1];
        paddleL.sprite = theme[2];
        paddleR.sprite = theme[2];
    }
}
