using UnityEngine;

public class ThemesMenu : MonoBehaviour
{
    // Node where we'll get our list of themes and load them.
    public ThemeManager ThemeManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Takes three themes from the theme list, loads their buttons in the menu.
    void LoadThemes(int startIdx)
    {
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

        // TODO: Test prefab spawning - try spawning a ThemeButton Prefab before doing loop.
    }
}
