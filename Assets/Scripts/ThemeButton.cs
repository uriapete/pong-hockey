using UnityEngine;

public class ThemeButton : MonoBehaviour
{
    // What theme this button will load.
    public Theme Theme;

    // The manager that this button will pass its Theme to.
    // private as we won't set this in unity, will be passed to script constructor
    private ThemeManager ThemeManager;

    // TODO: Add fields for thumbnail image and thumbnail component.

    public ThemeButton(Theme theme, ThemeManager manager)
    {
        this.Theme = theme;
        this.ThemeManager=manager;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // TODO: On Start, load thumbnail onto button.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Tells the ThemeManager to change it's theme to this button's Theme.
    public void LoadTheme()
    {
        ThemeManager.ChangeTheme(Theme);
    }
}
