using UnityEngine;

public class ThemeButton : MonoBehaviour
{
    // What theme this button will load.
    public Theme Theme;

    // The manager that this button will pass its Theme to.
    // public to expl set in unity
    public ThemeManager ThemeManager;

    // Thumbnail component, sets thumbnail
    public SpriteRenderer SpriteRenderer;

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
        // if the current theme is already set to this theme, dont do anything
        if (ThemeManager.currentTheme.Equals(Theme))
        {
            return;
        }
        ThemeManager.ChangeTheme(Theme);
    }
}
