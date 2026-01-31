using UnityEngine;
using UnityEngine.UI;

public class ThemesMenu : MonoBehaviour
{
    // Node where we'll get our list of themes and load them.
    public ThemeManager ThemeManager;

    // Prefab for buttons
    public GameObject ThemeButton;

    // list of bottons in scene
    public ThemeButton[] Buttons;

    // last page button
    public Button LastPageBtn;

    // next page button
    public Button NextPageBtn;

    // the current idx of the theme in left button
    private int CurrentStartIdx = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadThemes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // load last page
    public void LastPage(){
        LoadThemes(CurrentStartIdx-Buttons.Length);
    }

    // load next page
    public void NextPage(){
        LoadThemes(CurrentStartIdx+Buttons.Length);
    }

    // Takes three themes from the theme list, loads their buttons in the menu.
    void LoadThemes(int startIdx = 0)
    {
        CurrentStartIdx = startIdx;
        // TODO: Implement pseudocode.

        // Take ThemeManager.Themes[]
        // Take themes from Themes @ idxs: startIdx, startIdx+1, ...+2 -> themesToLoad[] (length<=3)

        // determine start position: switch (length)
            // case 0: return
            // case 1: 0,0
            // case 2: light left,
                // each button takes left or right
            // case 3: left
                // left, center, right
        // finish -> start_x

        // For each theme,idx in themesToLoad,
            // construct a ThemeButton, add theme as arg -> thmBtn
            // position in correct position (left, right, or center?) (or for 2, left or right?)
                // thmBtn.x = start_x + (idx*offset)
            // add to tree under this (ThemesMenu)
        // next
        
        // for each button on the menu...
        for (int i = 0; i < Buttons.Length; i++)
        {
            // get the button
            ThemeButton button = Buttons[i];

            // if we ran out of themes...
            if (startIdx+i >= ThemeManager.themes.Length)
            {
                // disable and skip
                button.enabled=false;
                continue;
            }

            // else, enable and set theme
            button.enabled=true;
            button.Theme=ThemeManager.themes[startIdx+i];
        }

        // if on first page, do not show last page button
        // else show
        LastPageBtn.enabled = startIdx > 0;

        // if on last page, do not show next page button
        // else show
        NextPageBtn.enabled = startIdx+Buttons.Length >= ThemeManager.themes.Length;
    }
}
